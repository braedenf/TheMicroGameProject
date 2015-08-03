	using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;

namespace MyGUI
{
	public enum GUIAnchor
	{
		TOP,
		TOP_LEFT,
		LEFT,
		BOTTOM_LEFT,
		BOTTOM,
		BOTTUM_RIGHT,
		RIGHT,
		TOP_RIGHT,

		CENTER
	}

	[System.Serializable]
	public abstract class GUIObject {

		[HideInInspector]
		public bool Enabled = true;

		private List<GUIObject> _children = new List<GUIObject>();
		private GUIObject _parent;

		public GUIObject Parent
		{
			get 
			{
				return _parent;
			}
		}

		public int ChildCount
		{
			get { return _children.Count; }
		}

		public Vector2 LocalPosition;
		public Vector2 Size;

		[HideInInspector]
		public bool HasBounds = true;

		public Vector2 localBounds;

		public Vector2 LocalBounds
		{
			get 
			{
				if (HasBounds)
				{
					return localBounds;
				}
				else
				{
					if (_parent != null)
					{
						return _parent.LocalBounds;
					}
					else
					{
						return new Vector2(Screen.width, Screen.height);
					}
				}
			}
			set 
			{
				localBounds = value;
			}
		}

		public GUIAnchor Anchor = GUIAnchor.TOP_LEFT;

		public Vector2 ScreenPosition
		{
			get
			{
				if (_parent != null)
				{
					return _parent.ScreenPosition + LocalPosition + GetAnchorOffset(Anchor);
				}
				else
				{
					return LocalPosition + GetAnchorOffset(Anchor);
				}
			}
		}

		public GUIObject ()
		{
			_parent = null;
		}

		public GUIObject (GUIObject parent)
		{
			_parent = parent;
		}

		public void Initialze()
		{
			initialize();
		}

		protected abstract void initialize ();

		public void Draw()
		{
			draw();
			foreach (GUIObject gui in _children)
			{
				if (gui.Enabled)
					gui.Draw();
			}
		}

		protected abstract void draw();

		public void AttachChild(GUIObject guiObject)
		{
			guiObject.SetParent(this);
			_children.Add(guiObject);
		}

		public bool HasChild(GUIObject guiObject)
		{
			return _children.Contains(guiObject);
		}

		public GUIObject ChildAt(int index)
		{
			if (index >= _children.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			else
			{
				return _children[index];
			}
		}

		public void RemoveChild(GUIObject guiObject)
		{
			for (int i = 0; i < _children.Count; i++)
			{
				if (_children[i] == guiObject)
				{
					_children[i].SetParent(null);
					_children.RemoveAt(i);
					break;
				}
			}
		}

		public void SetParent(GUIObject guiObject)
		{
			_parent = guiObject;
		}

		public static Vector2 ScreenPercentToCoord(Vector2 percent)
		{
			return new Vector2( Screen.height * ( percent.x / 100 ), Screen.height * ( percent.y / 100 ) );
		}

		public static Vector2 ScreenCoordToPercent(Vector2 coord)
		{
			return new Vector2( (coord.x / Screen.height) * 100 , (coord.y / Screen.height) * 100);
		}

		public Vector2 GetAnchorOffset(GUIAnchor anchor)
		{
			Vector2 bounds = (_parent != null) ? (GUIObject.ScreenCoordToPercent(_parent.LocalBounds)) : 
												 (GUIObject.ScreenCoordToPercent( new Vector2(Screen.width, Screen.height)));

//			Debug.Log ("bounds : " + bounds);
//			Debug.Log ( "getting anchor : " + anchor + " " + this);

			Vector2 pos = Vector2.zero;

			switch (anchor)
			{
				case GUIAnchor.TOP_LEFT:
					pos = Vector2.zero;
				break;

				case GUIAnchor.TOP:
					pos =  new Vector2(bounds.x/2, 0f);
				break;

				case GUIAnchor.TOP_RIGHT:
					pos =  new Vector2(bounds.x, 0f);
				break;

				case GUIAnchor.BOTTOM:
					pos =  new Vector2( bounds.x/2, bounds.y );
				break;
					
				case GUIAnchor.BOTTOM_LEFT:
					pos =  new Vector2( 0, bounds.y );
				break;
					
				case GUIAnchor.BOTTUM_RIGHT:
					pos =  new Vector2( bounds.x, bounds.y );
				break;

				case GUIAnchor.RIGHT:
					pos =  new Vector2( bounds.x, bounds.y/2 );
				break;

				case GUIAnchor.LEFT:
					pos =  new Vector2( 0, bounds.y/2 );
				break;

				case GUIAnchor.CENTER:
					pos =  new Vector2( bounds.x/2, bounds.y/2 );
				break;
			}

			return pos;
		}

	}

	public class DummyGUI : GUIObject
	{
		public DummyGUI()
			: base(null)
		{
			LocalBounds = new Vector2( Screen.width, Screen.height );
		}

		protected override void initialize ()
		{

		}

		protected override void draw ()
		{

		}
	}
}
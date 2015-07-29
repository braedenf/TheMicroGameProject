using UnityEngine;
using System.Collections;

namespace MyGUI
{
	[System.Serializable]
	public class TextLabel : GUIObject 
	{
		public string myText;

		public GUIStyle Style;

		public TextLabel()
			: base(null)
		{
			HasBounds = false;
		}

		protected override void initialize ()
		{

		}

		protected override void draw ()
		{
			Vector2 posiiton = GUIObject.ScreenPercentToCoord(ScreenPosition);
			Vector2 size 	 = GUIObject.ScreenPercentToCoord(Size);

			GUI.Label(new Rect(posiiton.x, posiiton.y, size.x, size.y), myText, Style);
		}
	}
}

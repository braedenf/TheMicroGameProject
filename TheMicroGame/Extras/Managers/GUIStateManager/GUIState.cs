using UnityEngine;

using System.Collections;
using System.Collections.Generic;

using MyGUI;

[System.Serializable]
public abstract class GUIState : MonoBehaviour {

	protected GUIState _parent_gui_state;

	protected GUIState _current_sub_gui_state;

	public bool HasParent
	{
		get { return _parent_gui_state != null; }
	}

	public GUIState ParentGUIState
	{
		get { return _parent_gui_state; }
	}

	public bool HasSubGUIState
	{
		get { return _current_sub_gui_state != null; }
	}

	public GUIState SubGUIState
	{
		get { return _current_sub_gui_state; }
	}

	protected GUIObject _root;

	public void Awake()
	{
		_root = new DummyGUI();

		Initalize();
		enabled = false;
	}

	public abstract void Initalize();

	public void SetSubGUIState(GUIState guiState)
	{
		if (_current_sub_gui_state != null)
		{
			_current_sub_gui_state.State_End();
			_current_sub_gui_state.enabled = false;
		}
		
		_current_sub_gui_state = guiState;
		_current_sub_gui_state.State_Start();
		_current_sub_gui_state.enabled = true;
	}

	public void _gui_state_draw_()
	{
		Draw ();
		_root.Draw();

		if (_current_sub_gui_state != null)
		{
			_current_sub_gui_state._gui_state_draw_();
		}
	}

	public void _update_gui_state_()
	{
		if (_current_sub_gui_state != null)
		{
			_current_sub_gui_state._update_gui_state_();
		}
	}

	public abstract void GUI_Update(); 

	protected abstract void Draw();

	public abstract void State_Start();
	public abstract void State_End();

}

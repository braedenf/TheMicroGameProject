using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUIStateManager : MonoSingleton<GUIStateManager> {

	private GUIState _current_gui_state;

	public GUIState initial_gui_state;

	public void SetGUIState(GUIState state)
	{
		if (_current_gui_state != null)
		{
			_current_gui_state.State_End();
			_current_gui_state.enabled = false;
		}

		_current_gui_state = state;
		_current_gui_state.State_Start();
		_current_gui_state.enabled = true;
	}

	void Awake()
	{
		SetGUIState( initial_gui_state );
	}

	void Start()
	{

	}

	void Update()
	{
		if (_current_gui_state != null)
		{
			_current_gui_state.GUI_Update();
		}
	}

	public void OnGUI()
	{
		if (_current_gui_state != null)
		{
			_current_gui_state._gui_state_draw_() ;
		}
	}


}

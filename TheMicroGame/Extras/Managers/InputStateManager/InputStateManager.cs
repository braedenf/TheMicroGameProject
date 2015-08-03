using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class InputStateManager : MonoSingleton<InputStateManager> {

	private InputState _current_gui_state;

	public InputState _initial_input_state;

	void Awake()
	{
		_current_gui_state = _initial_input_state;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (_current_gui_state != null)
		{
			_current_gui_state.Input_Update();
		}
	}

	public void SetInputState(InputState inputState)
	{
		if (_current_gui_state != null)
		{
			_current_gui_state.EndState();
			_current_gui_state.enabled = false;
		}

		_current_gui_state = inputState;
		inputState.BeginState();
		inputState.enabled = true;
	}
}

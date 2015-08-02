using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;

public enum Xbox_Controller_Button
{
	A,
	B,
	X,
	Y,
	Start,
	Back,
	Left_Stick_Click,
	Right_Stick_Click,
	Left_Trigger, 
	Right_Trigger,
	Left_Bumper,
	Right_Bumper,
	DPad_Left,
	DPad_Right,
	DPad_Down,
	DPad_Up
}

public enum Xbox_Controller_Axis
{
	Right_Stick_X,
	Right_Stick_Y,
	Left_Stick_X,
	Left_Stick_Y,
	Left_Trigger,
	Right_Trigger,
	DPad_Horizontal,
	DPad_Vertical
}

public class ControllerWatcher {

	// Use this for initialization

	protected int _controller_number;

	protected Dictionary<string, bool> _buttonStates = new Dictionary<string, bool>();
	protected List<string> _buttonKeys = new List<string>();

	protected Dictionary<string, float> _axisStates = new Dictionary<string, float>();
	protected List<string> _axisKeys = new List<string>();

	protected Dictionary<string, Xbox_Controller_Button> _genericButtonNames = new Dictionary<string, Xbox_Controller_Button>();
	protected Dictionary<string, Xbox_Controller_Axis> _genericAxisNames = new Dictionary<string, Xbox_Controller_Axis>();

	public ControllerWatcher(int number)
	{
		_controller_number = number;

		InitializeControllerButtons();
	}	 

	private void InitializeControllerButtons()
	{
		if (Application.platform == RuntimePlatform.WindowsPlayer ||
		    Application.platform == RuntimePlatform.WindowsEditor)
		{
			_buttonStates.Add ( "win_p" + _controller_number + "_xbox_a", false );
			_genericButtonNames.Add ( "win_p" + _controller_number + "_xbox_a", Xbox_Controller_Button.A );
			
			_buttonStates.Add ( "win_p" + _controller_number + "_xbox_b", false );
			_genericButtonNames.Add ( "win_p" + _controller_number + "_xbox_b", Xbox_Controller_Button.B );
			
			_buttonStates.Add ( "win_p" + _controller_number + "_xbox_x", false );
			_genericButtonNames.Add ( "win_p" + _controller_number + "_xbox_x", Xbox_Controller_Button.X );
			
			_buttonStates.Add ( "win_p" + _controller_number + "_xbox_y", false );
			_genericButtonNames.Add ( "win_p" + _controller_number + "_xbox_y", Xbox_Controller_Button.Y );
			
			_buttonStates.Add ( "win_p" + _controller_number + "_xbox_start", false );
			_genericButtonNames.Add ( "win_p" + _controller_number + "_xbox_start", Xbox_Controller_Button.Start );
			
			_buttonStates.Add ( "win_p" + _controller_number + "_xbox_back", false );
			_genericButtonNames.Add ( "win_p" + _controller_number + "_xbox_back", Xbox_Controller_Button.Back );
			
			_buttonStates.Add ( "win_p" + _controller_number + "_xbox_LB", false );
			_genericButtonNames.Add ( "win_p" + _controller_number + "_xbox_LB", Xbox_Controller_Button.Left_Bumper );
			
			_buttonStates.Add ( "win_p" + _controller_number + "_xbox_RB", false );
			_genericButtonNames.Add ( "win_p" + _controller_number + "_xbox_RB", Xbox_Controller_Button.Right_Bumper );
			
			_buttonStates.Add ( "win_p" + _controller_number + "_xbox_LeftStickClick", false );
			_genericButtonNames.Add ( "win_p" + _controller_number + "_xbox_LeftStickClick", Xbox_Controller_Button.Left_Stick_Click );
			
			_buttonStates.Add ( "win_p" + _controller_number + "_xbox_RightStickClick", false );
			_genericButtonNames.Add ( "win_p" + _controller_number + "_xbox_RightStickClick", Xbox_Controller_Button.Right_Stick_Click );
			
			//Axises
			
			_axisStates.Add ("win_p" + _controller_number + "_xbox_LeftStickAxisX", 0);
			_genericAxisNames.Add ("win_p" + _controller_number + "_xbox_LeftStickAxisX", Xbox_Controller_Axis.Left_Stick_X);
			
			_axisStates.Add ("win_p" + _controller_number + "_xbox_LeftStickAxisY", 0);
			_genericAxisNames.Add ("win_p" + _controller_number + "_xbox_LeftStickAxisY", Xbox_Controller_Axis.Left_Stick_Y);
			
			_axisStates.Add ("win_p" + _controller_number + "_xbox_RightStickAxisX", 0);
			_genericAxisNames.Add ("win_p" + _controller_number + "_xbox_RightStickAxisX", Xbox_Controller_Axis.Right_Stick_X);
			
			_axisStates.Add ("win_p" + _controller_number + "_xbox_RightStickAxisY", 0);
			_genericAxisNames.Add ("win_p" + _controller_number + "_xbox_RightStickAxisY", Xbox_Controller_Axis.Right_Stick_Y);
			
			_axisStates.Add ("win_p" + _controller_number + "_xbox_RightTrigger", 0);
			_genericAxisNames.Add ("win_p" + _controller_number + "_xbox_RightTrigger", Xbox_Controller_Axis.Right_Trigger);
			
			_axisStates.Add ("win_p" + _controller_number + "_xbox_LeftTrigger", 0);
			_genericAxisNames.Add ("win_p" + _controller_number + "_xbox_LeftTrigger", Xbox_Controller_Axis.Left_Trigger);
			
			_axisStates.Add ("win_p" + _controller_number + "_xbox_DPadHorizontal", 0);
			_genericAxisNames.Add ("win_p" + _controller_number + "_xbox_DPadHorizontal", Xbox_Controller_Axis.DPad_Horizontal);
			
			_axisStates.Add ("win_p" + _controller_number + "_xbox_DPadVertical", 0);
			_genericAxisNames.Add ("win_p" + _controller_number + "_xbox_DPadVertical", Xbox_Controller_Axis.DPad_Vertical);

			_buttonKeys = new List<string>(_buttonStates.Keys);
			_axisKeys = new List<string>(_axisStates.Keys);
		}
		else if (Application.platform == RuntimePlatform.OSXPlayer ||
		         Application.platform == RuntimePlatform.OSXEditor)
		{
			_buttonStates.Add ( "mac_p" + _controller_number + "_xbox_a", false );
			_genericButtonNames.Add ( "mac_p" + _controller_number + "_xbox_a", Xbox_Controller_Button.A );
			
			_buttonStates.Add ( "mac_p" + _controller_number + "_xbox_b", false );
			_genericButtonNames.Add ( "mac_p" + _controller_number + "_xbox_b", Xbox_Controller_Button.B );
			
			_buttonStates.Add ( "mac_p" + _controller_number + "_xbox_x", false );
			_genericButtonNames.Add ( "mac_p" + _controller_number + "_xbox_x", Xbox_Controller_Button.X );
			
			_buttonStates.Add ( "mac_p" + _controller_number + "_xbox_y", false );
			_genericButtonNames.Add ( "mac_p" + _controller_number + "_xbox_y", Xbox_Controller_Button.Y );
			
			_buttonStates.Add ( "mac_p" + _controller_number + "_xbox_start", false );
			_genericButtonNames.Add ( "mac_p" + _controller_number + "_xbox_start", Xbox_Controller_Button.Start );
			
			_buttonStates.Add ( "mac_p" + _controller_number + "_xbox_back", false );
			_genericButtonNames.Add ( "mac_p" + _controller_number + "_xbox_back", Xbox_Controller_Button.Back );
			
			_buttonStates.Add ( "mac_p" + _controller_number + "_xbox_LB", false );
			_genericButtonNames.Add ( "mac_p" + _controller_number + "_xbox_LB", Xbox_Controller_Button.Left_Bumper );
			
			_buttonStates.Add ( "mac_p" + _controller_number + "_xbox_RB", false );
			_genericButtonNames.Add ( "mac_p" + _controller_number + "_xbox_RB", Xbox_Controller_Button.Right_Bumper );
			
			_buttonStates.Add ( "mac_p" + _controller_number + "_xbox_LeftStickClick", false );
			_genericButtonNames.Add ( "mac_p" + _controller_number + "_xbox_LeftStickClick", Xbox_Controller_Button.Left_Stick_Click );
			
			_buttonStates.Add ( "mac_p" + _controller_number + "_xbox_RightStickClick", false );
			_genericButtonNames.Add ( "mac_p" + _controller_number + "_xbox_RightStickClick", Xbox_Controller_Button.Right_Stick_Click );

			_buttonStates.Add ( "mac_p" + _controller_number + "_xbox_Dpad_up", false );
			_genericButtonNames.Add ( "mac_p" + _controller_number + "_xbox_Dpad_up", Xbox_Controller_Button.DPad_Up );

			_buttonStates.Add ( "mac_p" + _controller_number + "_xbox_Dpad_down", false );
			_genericButtonNames.Add ( "mac_p" + _controller_number + "_xbox_Dpad_down", Xbox_Controller_Button.DPad_Down );

			_buttonStates.Add ( "mac_p" + _controller_number + "_xbox_Dpad_left", false );
			_genericButtonNames.Add ( "mac_p" + _controller_number + "_xbox_Dpad_left", Xbox_Controller_Button.DPad_Left );

			_buttonStates.Add ( "mac_p" + _controller_number + "_xbox_Dpad_right", false );
			_genericButtonNames.Add ( "mac_p" + _controller_number + "_xbox_Dpad_right", Xbox_Controller_Button.DPad_Right );


			//Axises
			
			_axisStates.Add ("mac_p" + _controller_number + "_xbox_LeftStickAxisX", 0);
			_genericAxisNames.Add ("mac_p" + _controller_number + "_xbox_LeftStickAxisX", Xbox_Controller_Axis.Left_Stick_X);
			
			_axisStates.Add ("mac_p" + _controller_number + "_xbox_LeftStickAxisY", 0);
			_genericAxisNames.Add ("mac_p" + _controller_number + "_xbox_LeftStickAxisY", Xbox_Controller_Axis.Left_Stick_Y);
			
			_axisStates.Add ("mac_p" + _controller_number + "_xbox_RightStickAxisX", 0);
			_genericAxisNames.Add ("mac_p" + _controller_number + "_xbox_RightStickAxisX", Xbox_Controller_Axis.Right_Stick_X);
			
			_axisStates.Add ("mac_p" + _controller_number + "_xbox_RightStickAxisY", 0);
			_genericAxisNames.Add ("mac_p" + _controller_number + "_xbox_RightStickAxisY", Xbox_Controller_Axis.Right_Stick_Y);
			
			_axisStates.Add ("mac_p" + _controller_number + "_xbox_RightTrigger", 0);
			_genericAxisNames.Add ("mac_p" + _controller_number + "_xbox_RightTrigger", Xbox_Controller_Axis.Right_Trigger);
			
			_axisStates.Add ("mac_p" + _controller_number + "_xbox_LeftTrigger", 0);
			_genericAxisNames.Add ("mac_p" + _controller_number + "_xbox_LeftTrigger", Xbox_Controller_Axis.Left_Trigger);

			_buttonKeys = new List<string>(_buttonStates.Keys);
			_axisKeys = new List<string>(_axisStates.Keys);

		}
	}

	public virtual void OnButtonChange(Xbox_Controller_Button name, bool oldState, bool newState)
	{
//		Debug.Log ( name + " " + newState );
	}

	public virtual void OnAxisChange(Xbox_Controller_Axis name, float oldValue, float newValue)
	{
//		Debug.Log ( name + " " + newValue );
	}

	public virtual void Update()
	{
		foreach (string key in _buttonKeys)
		{
			bool newValue = Input.GetButton(key);

			if (newValue != _buttonStates[key])
			{
				OnButtonChange( _genericButtonNames[key], _buttonStates[key], newValue );
				_buttonStates[key] = newValue;
				//toChangeButtons.Add ( new KeyValuePair<string, bool>( keyValue.Key, newValue ));
			}
		}

		foreach (string key in _axisKeys)
		{
			float newValue = Input.GetAxis(key);
			
			if (newValue != _axisStates[key])
			{
				OnAxisChange( _genericAxisNames[key], _axisStates[key], newValue );
				_axisStates[key] = newValue;
			}
		}
	}

}

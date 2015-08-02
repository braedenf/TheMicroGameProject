using UnityEngine;
using System.Collections;

using MyGUI;

[System.Serializable]
public class MainGUIState : GUIState {

	public TextLabel textLabel;

	public override void Initalize ()
	{
		_root.AttachChild( textLabel );
	}

	public override void State_Start ()
	{

	}

	public override void State_End ()
	{

	}

	public override void GUI_Update ()
	{

	}

	protected override void Draw ()
	{

	}

}

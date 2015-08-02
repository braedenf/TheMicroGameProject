using UnityEngine;
using System.Collections;

public abstract class InputState : MonoBehaviour {

	public void Awake()
	{
		Initialize();
		enabled = false;
	}

	public abstract void Initialize();

	public abstract void BeginState();
	public abstract void EndState();
	public abstract void ResetState();

	public abstract void Input_Update();

}

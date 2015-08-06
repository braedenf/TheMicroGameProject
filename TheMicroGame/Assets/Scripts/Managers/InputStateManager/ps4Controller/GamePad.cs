using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GamePad : MonoBehaviour 
{
	private bool m_isHAxisInUse;
	private bool m_isVAxisInUse;
	
	// Update is called once per frame
	void Update () 
	{
		//the crazy stuff you see with horisontal and vertical axis is 
		//a workaround for how the left and right joysticks do not get 
		//pressed as buttons. Therefore, GetButtonDown doesn't work as single-press.
		//anything that is an AXIS needs to be handled this way

		//HORIZONTAL
		if (Input.GetAxis ("Horizontal") != 0) {
			if (!m_isHAxisInUse) {
				m_isHAxisInUse = true;
				if (Input.GetAxis ("Horizontal") > 0) {
					//right
				} else {
					//left
				}
			}
		} 
		else {
			m_isHAxisInUse = false;
		}   
		
		//VERTICAL
		if (Input.GetAxis ("Vertical") != 0) {
			if (!m_isVAxisInUse) {
				m_isVAxisInUse = true;
				if (Input.GetAxis ("Vertical") > 0) {
					//up
				} else {
					//down
				}
			}
		} 
		else {
			m_isVAxisInUse = false;
		}
		
		//Triangle
		if (Input.GetButtonDown ("Jump")) {
		}
		//Circle
		if (Input.GetButtonDown ("Fire3")) {
		}
		//X
		if (Input.GetButtonDown ("Fire2")) {
		}
		//square
		if (Input.GetButtonDown ("Fire1")) {
		}
		
		if (Input.GetButtonDown ("L1")) {
		}
		if (Input.GetButtonDown ("R1")) {
		}
		if (Input.GetButtonDown ("L2")) {
		}
		if (Input.GetButtonDown ("R2")) {
		}

		if (Input.GetButtonDown ("PadPress")) {
		}

		if (Input.GetButtonDown ("L3")) {
		}
		if (Input.GetButtonDown ("R3")) {
		}
	}
}

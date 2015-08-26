using UnityEngine;
using System.Collections;


//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// Manages All Of The Most Distinguished And Necessiary States Within The Game 
// - Distinguishes Between The 'Exploration' State And The 'Gallery' State
public class GameManagement : MonoBehaviour 
{

	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All  Public Attributes That'll Be Run On Within The "Game Management" Class
    public Canvas canvas;

	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All  Private Attributes That'll Be Run On Within The "Game Management" Class
	private AudienceBehaviour audienceBehaviour;
	private CameraBehaviour   cameraBehaviour;

	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All Attributes And Instances That'll Be Run On Awake
	void Awake () 
	{
	
	// ----------  ----------    ----------   ---------- //
	// Defines The State Of All Necessiary Cross-Connection Codes
	if (audienceBehaviour == null)
	audienceBehaviour = this.gameObject.GetComponent <AudienceBehaviour> ();
	// ----------  ----------    ----------   ---------- //
	if (cameraBehaviour == null)
	cameraBehaviour = this.gameObject.GetComponent <CameraBehaviour> ();
	
	// ----------  ----------    ----------   ---------- //
	// References All Of The Game States That'll Be Operational On Awake
	audienceBehaviour.enabled = false; 
	canvas.enabled                    = false;
	// ----------  ----------    ----------   ---------- //
	cameraBehaviour.enabled    = true;
	
	}
	
	//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Retains An Awareness Of The Game States And Their Consistent Settings
	void Update () 
	{
	
	 if (Input.GetKeyDown (KeyCode.Z) )
	 {
	 audienceBehaviour.enabled = true; 
	 canvas.enabled                    = true;
	 // ----------  ----------    ----------   ---------- //
	 cameraBehaviour.enabled    = false;
	 }
	 
	 
	 if (Input.GetKeyDown (KeyCode.X) )
	 {
	 audienceBehaviour.enabled = false; 
	 canvas.enabled                    = false;
	 // ----------  ----------    ----------   ---------- //
	 cameraBehaviour.enabled    = true;
	 }
	
	
	}
}

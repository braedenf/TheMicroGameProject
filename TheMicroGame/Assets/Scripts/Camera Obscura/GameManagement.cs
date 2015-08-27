using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// Manages All Of The Most Distinguished And Necessiary States Within The Game 
// - Distinguishes Between The 'Exploration' State And The 'Gallery' State
public class GameManagement : MonoBehaviour 
{

	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All  Public Attributes That'll Be Run On Within The "Game Management" Class

	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All  Private Attributes That'll Be Run On Within The "Game Management" Class
	private AudienceBehaviour audienceBehaviour;
	private CameraBehaviour   cameraBehaviour;
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All  Public Enum That Represents All Differing Game States
	public enum GameState 
    {
    gallery       = 1,
    discovery   = 2,
    }
    
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All Public GameState Attributes
    public GameState gameState;


	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All Attributes And Instances That'll Be Run On Awake
	void Awake () 
	{
	
	// ----------  ----------    ----------   ---------- //
	// Defines The State Of All Necessiary Cross-Connection Codes
	if (this.gameObject.GetComponent <AudienceBehaviour> () != null)
	audienceBehaviour = this.gameObject.GetComponent <AudienceBehaviour> ();
	else 
	Mathematics.Logged ("Crikey, It Looks Like",  this.gameObject.name, "Is Missing The AudienceBehaviour Code");
	// ----------  ----------    ----------   ---------- //
	if (this.gameObject.GetComponent <CameraBehaviour> () != null)
	cameraBehaviour = this.gameObject.GetComponent <CameraBehaviour> ();
	else 
	Mathematics.Logged ("Crikey, It Looks Like", this.gameObject.name, "Is Missing The CameraBehaviour Code");
	
	// ----------  ----------    ----------   ---------- //
	// Defines The Default Game State Present Within The Waking Moments
	gameState  =  GameState.gallery | GameState.discovery;
	// ----------  ----------    ----------   ---------- //
	gameState ^= GameState.gallery;
	
	}
	
	//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Retains An Awareness Of The Game States And Their Consistent Settings
	void Update () 
	{
	
	// ----------  ----------    ----------   ---------- //
	// Toggles The Game State Depending On Audience Interaction
	 if (Input.GetKeyDown (KeyCode.Return) )
	 {
	 gameState ^= GameState.gallery;
	 gameState ^= GameState.discovery; 
	 }
	 
	// ----------  ----------    ----------   ---------- //
	// References Whether The Gallery State Has Been Activated
	// - Expresses All Necessiary Gallery Attributes
	 if (gameState == GameState.gallery)
	 audienceBehaviour.enabled = true;
     else
     audienceBehaviour.enabled = false;
     
     // ----------  ----------    ----------   ---------- //
	// References Whether The Discovery State Has Been Activated
	// - Expresses All Necessiary Discovery Attributes
	 if (gameState == GameState.discovery)
	 cameraBehaviour.enabled = true;
     else
     cameraBehaviour.enabled = false;

	 }
	
	
	
}

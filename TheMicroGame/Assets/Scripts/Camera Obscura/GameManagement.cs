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
   public string discovery = "discovery";
   public string gallery     = "gallery";


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
	// Defines The  Attributes Of All Necessiary Game State Lists 
	GameObject [ ] attributes = GameObject.FindGameObjectsWithTag (discovery);
	foreach (GameObject attribute in attributes)
	GameDirectory.discovery.Add (attribute);
	// ----------  ----------    ----------   ---------- //
	GameObject [ ] atrocities = GameObject.FindGameObjectsWithTag (gallery);
	foreach (GameObject atrocity in atrocities)
	GameDirectory.gallery.Add (atrocity);
	

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
	//  Exists The Application Depending On Audience Interaction
	if (Input.GetKeyDown (KeyCode.Escape) )
	Application.Quit ();
	
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
	 {
	 foreach (GameObject attribute in GameDirectory.gallery)
	 attribute.SetActive (true);
	 }
	 else
	 foreach (GameObject attribute in GameDirectory.gallery)
	 attribute.SetActive (false);
     
     // ----------  ----------    ----------   ---------- //
	// References Whether The Discovery State Has Been Activated
	// - Expresses All Necessiary Discovery Attributes
	 if (gameState == GameState.discovery)
	 {
	 foreach (GameObject attribute in GameDirectory.discovery)
	 attribute.SetActive (true);
	 }
     else
	 foreach (GameObject attribute in GameDirectory.discovery)
	 attribute.SetActive (false);


	 }
	
	
	
}
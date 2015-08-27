using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// Manages The Over-Arching Audience Behaviour Relating To Basic Interactive Functions
// - The Operation Of The 'Gallery' State Management 
// - The Useability Of All 'Gallery' Attributes And Functions
public class AudienceBehaviour : MonoBehaviour 
{

	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All  Public Attributes That'll Be Run On Within The "Audience Behaviour" Class
	public Canvas canvas;
	// ----------  ----------    ----------   ---------- //
	public float acceleration;

	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All  Private Attributes That'll Be Run On Within The "Audience Behaviour" Class
	private int counter;
	// ----------  ----------    ----------   ---------- //
	private float momentum;
	private float time;
	// ----------  ----------    ----------   ---------- //
	private Vector3 visited; 
	private Vector3 central;
	private Vector3 hidden;

	
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All Attributes And Instances That'll Be Run On Disable
	// - Causes The Gallery Interface To Become Visual
	void OnDisable ()
 	{  canvas.enabled = false;  }

	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All Attributes And Instances That'll Be Run On Enable
	void OnEnable () 
	{
		
	// ----------  ----------    ----------   ---------- //
	// Defines The Locations Of All Necessiary 'Vector3' Attributes
	visited  = new Vector3 ( (Screen.width / 2.00f) , Screen.height + (Screen.height / 2.00f) , 0.00f);
	central = new Vector3 ( (Screen.width / 2.00f) , (Screen.height / 2.00f) , 0.00f);
	hidden = new Vector3 ( (Screen.width / 2.00f) , 0.00f - (Screen.height / 2.00f) , 0.00f);
		
	// ----------  ----------    ----------   ---------- //
	// Defines The State Of All Selected Attributes On Awake
	counter = (int) (GameDirectory.photographic.Count - 1.00f);
	// ----------  ----------    ----------   ---------- //
	if (GameDirectory.photographic.Count > (int) 0.00f)
	counter = (int) Mathematics.limitation (counter, 0.00f, (GameDirectory.photographic.Count - 1) );
	else
	counter = (int) 0.00f;
	
	// ----------  ----------    ----------   ---------- //
	// References Whether Any Necessiary Attributes May Be Missing
	if (acceleration == null)
	Mathematics.Logged ("Core Blimey Son, It Looks Like You're Missing Positional Interface Attributes");
	
	// ----------  ----------    ----------   ---------- //
	// Causes The Gallery Interface To Become Visual
	if (canvas == null)
	Mathematics.Logged ("Crikey, It Looks Like AudienceBehaviour Is Missing The Canvas Attribute");
	// ----------  ----------    ----------   ---------- //\
	canvas.enabled = true;
	
	
	// ----------  ----------    ----------   ---------- //
	//  Manuevers The Selected Photograph To Be Present Within The Interface  | Central
	Vector3 position  = (GameDirectory.photographic [counter].representation.position);
	GameDirectory.photographic [counter].representation.position = central;
	
	// ----------  ----------    ----------   ---------- //
	// Incrementally Goes Through The List Of Captured Photographes 
	// And Positions Them Suitably Within The 'Gallery' Interface Depending On Audience Interaction
	for (int item = (int) 0.00f;   item != GameDirectory.photographic.Count;  item ++)
	{  
	
	// ----------  ----------    ----------   ---------- //
	// Accesses Its Latest 3Dimensional Position On The Interface
	Vector3 orientation  = (GameDirectory.photographic [item].representation.position);

	// ----------  ----------    ----------   ---------- //
	//  Manuevers The Selected Photograph To Be Present Within The Interface  | Hidden
	if (item != counter)
	GameDirectory.photographic [item].representation.position = hidden;
	
	}
	
	} 
	
	
	//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Progressively Retains A Systematic Influence On How The Gallery Is Expressed
	void Update () 
	{
	
	
	
	// ----------  ----------    ----------   ---------- //
	// Toggles The Counter State Depending On Certain Audience Interactions
	// ----------  ----------    ----------   ---------- //	
	if (Input.GetKeyDown (KeyCode.DownArrow) )
	counter --;
    // ----------  ----------    ----------   ---------- //
    if (Input.GetKeyDown (KeyCode.UpArrow) ) 
	counter ++;
	// ----------  ----------    ----------   ---------- //
	if (GameDirectory.photographic.Count > (int) 0.00f)
	counter = (int) Mathematics.limitation (counter, 0.00f, (GameDirectory.photographic.Count - 1) );
	else
	counter = (int) 0.00f;
	
	
	
	// ----------  ----------    ----------   ---------- //
	// Progressively References Whether The Gallery Has Developed In Dimension
	// Expresses What "GameDirectory.photogtraphic" List Item Should Now Be Represented On Screen
	for (int item = (int) 0.00f;   item != GameDirectory.photographic.Count;  item ++)
	{  
	
	// ----------  ----------    ----------   ---------- //
	// Accesses Its Latest 3Dimensional Position On The Interface
	Vector3 orientation  = (GameDirectory.photographic [item].representation.position);
	
	// ----------  ----------    ----------   ---------- //
	// Designs A Sense Of Momentum For The Photographic Components
	momentum = acceleration * Time.deltaTime;
	
	// ----------  ----------    ----------   ---------- //
	//  Manuevers The Selected Photograph To Be Present Within The Interface  | Central
	if (item == counter)
	{	
	if (GameDirectory.photographic [item].representation.position != central);
	GameDirectory.photographic [item].representation.position = Vector3.MoveTowards (orientation, central, momentum);
	}
	
	// ----------  ----------    ----------   ---------- //
	//  Manuevers The Selected Photograph To Be Present Within The Interface  | Hidden
	if (item < counter)
	{	
	if (GameDirectory.photographic [item].representation.position  != hidden);
	GameDirectory.photographic [item].representation.position = Vector3.MoveTowards (orientation, hidden, momentum);
	}
	
	// ----------  ----------    ----------   ---------- //
	//  Manuevers The Selected Photograph To Be Present Within The Interface  | Hidden
	if (item > counter)
	{	
	if (GameDirectory.photographic [item].representation.position != visited);
	GameDirectory.photographic [item].representation.position = Vector3.MoveTowards (orientation, visited, momentum);
	}
	
	
    }
	
	
	}

}
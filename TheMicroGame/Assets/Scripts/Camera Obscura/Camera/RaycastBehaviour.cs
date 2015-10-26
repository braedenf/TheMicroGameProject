using UnityEngine;
using System.Collections;
using System.Collections.Generic;



//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// Fires A Raycast From Your Camera Position And Attempts To Decipher Whether There's Any Selectable Creatures Abroad
public class RaycastBehaviour : MonoBehaviour 
{

	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All  Public Attributes That Can Be Manipulated By The Game Designer
	public Camera camera; 
	// ----------  ----------    ----------   ---------- //
	[ Range (0, 1000) ] public float visibility;
	// ----------  ----------    ----------   ---------- //
	public List <string> distinction = new List <string> ();
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All  Private Attributes That Can Be Manipulated By The Code
	public GameObject creature;
		
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All Necessiary Qualities On Awake
	void Awake () 
	{
	
	// ----------  ----------    ----------   ---------- //
	// Checks Whether A Suitable Camera Has Been Selected
	if (!camera)
	camera = Camera.main;
	
	// ----------  ----------    ----------   ---------- //
	// Checks Whether The Distinction List Possesses Any Tags
	if (distinction.Count == 0)
	Mathematics.Logged ("Possibly Define Some Creature Tags For The RaycastBehaviour Code");
	
	}
	
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Progressively Checks Whether The Camera Raycast Has Discovered Any Selectable Creatures
	void Update () 
	{
	
	// ----------  ----------    ----------   ---------- //
	// Defines All Necessiary Attributes For The Creature Discovery Process
	creature = null;
	
	// ----------  ----------    ----------   ---------- //
	// Defines All Necessiary Attributes For The Physics Raycast 
	RaycastHit hit;
	
	// ----------  ----------    ----------   ---------- //
	// Defines The Raycast Direction
	Ray raycast = camera.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0) );
	
	// ----------  ----------    ----------   ---------- //
	// Defines A Raycast From The Camera Position And Orientation
    Physics.Raycast (raycast, out hit, visibility);
   
    // ----------  ----------    ----------   ---------- //
    // Deciphers Whether It's Managed To Hit Any Distinguished Creatures
    if (hit.transform != null)
    { 
    foreach (string tag in distinction)
    {
    
    // ----------  ----------    ----------   ---------- //
    if (hit.transform.gameObject.tag == tag)
    {
    Activation   (hit.transform.gameObject);
    return;
    }
    else
    Deactivation   ();
    
    }  
    }
    
     // ----------  ----------    ----------   ---------- //
     // Proceeds With The Deactivation Code If No Creature Is Discovered
     if (hit.transform == null)
     Deactivation ();
    
	}
	
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Progressively Reacts To The Raycast If A Creature Has Been Discovered
	void Activation (GameObject _raycast)
	{
		
	// ----------  ----------    ----------   ---------- //
	// Defines The Creature That Was Discovered
	creature = _raycast;
	
	// ----------  ----------    ----------   ---------- //
    Mathematics.Logged ("Creature Discovered");
	}
	
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Progressively Reacts To The Raycast If A Creature Has Been Discovered
	void Deactivation ()
	{
		
	// ----------  ----------    ----------   ---------- //
	// Defines The Creature That Was Discovered
	creature = null;
	
	// ----------  ----------    ----------   ---------- //
    Mathematics.Logged ("Nothing To See Here, Move Along Now");
	
	}
	
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;



//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// Fires A Raycast From Your Camera Position And Attempts To Decipher Whether There's Any Selectable Creatures Abroad
public class RaycastBehaviour : MonoBehaviour 
{

	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All  Public Attributes That Can Be Manipulated By The Game Designer
	public Camera    camera; 
	public Animator  animate;
	// ----------  ----------    ----------   ---------- //
	[ Range (0, 5)    ] public float speed;
	[ Range (0, 1000) ] public float visibility;
	// ----------  ----------    ----------   ---------- //
	public List <string> distinction = new List <string> ();
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All  Private Attributes That Can Be Manipulated By The Code
	[HideInInspector] public GameObject creature;
	// ----------  ----------    ----------   ---------- //
	private int       counter;
	// ----------  ----------    ----------   ---------- //
	private string    name;
	
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All Necessiary Qualities On Awake
	void OnEnable () 
	{
	
	// ----------  ----------    ----------   ---------- //
	// Checks Whether A Suitable Camera Has Been Selected
	if (!camera)
	camera = Camera.main;
	
	// ----------  ----------    ----------   ---------- //
	// Checks Whether The Distinction List Possesses Any Tags
	if (distinction.Count == 0)
	Mathematics.Logged ("Possibly Define Some Creature Tags For The RaycastBehaviour Code");
	
	// ----------  ----------    ----------   ---------- //
	// Checks Whether The Following Attributes Are Attributed To Anything
	if (animate == null)
	Mathematics.Logged ("Possibly Define An Animation For The RaycastBehaviour Code");

    // ----------  ----------    ----------   ---------- //
	// Defines The Animation Transistion Speed
	animate.speed = 0.00f;

	}
	
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Progressively Checks Whether The Camera Raycast Has Discovered Any Selectable Creatures
	void Update () 
	{
	
	// ----------  ----------    ----------   ---------- //
	// Defines All Necessiary Attributes For The Creature Discovery Process
	creature = null;
	
	// ----------  ----------    ----------   ---------- //
	// Defines The Animation Transistion Of The Raycast Image
	if (counter < GameDirectory.photographic.Count)
	{
    animate.Play ("Transistion", -1, 0); 
    animate.speed = speed;
    }
    
  
	
	// ----------  ----------    ----------   ---------- //
	// Analyzes The Length Of The Photography List Each Progressive Frame
	counter = GameDirectory.photographic.Count;
	

	// ----------  ----------    ----------   ---------- //
	// Defines A Raycast From The Camera Position And Orientation
	RaycastHit hit;
	Ray        raycast = camera.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0) );
	// ----------  ----------    ----------   ---------- //
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
	
	}
	
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Progressively Reacts To The Raycast If A Creature Has Been Discovered
	void Deactivation ()
	{
		
	// ----------  ----------    ----------   ---------- //
	// Defines The Creature That Was Discovered
	creature = null;

	}
	
}

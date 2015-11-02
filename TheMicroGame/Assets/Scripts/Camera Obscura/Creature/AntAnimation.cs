using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// Manipulates The Creatures Animations And Organizes Them To Remain Synced With One Another
public class AntAnimation : MonoBehaviour 
{

	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All  Public Attributes That Can Be Manipulated By The Game Designer
	[Range (1, 60) ] public int      framerate;
	// ----------  ----------    ----------   ---------- //
	[Range (0, 10) ] public float    speed;
	[Range (1, 10) ] public float    acceleration;
	[Range (0, 1) ]  public float    approximate;
	// ----------  ----------    ----------   ---------- //
	public bool                      hardboiled;

	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines A Class For The Pollination Process
	[System.Serializable]
	public class Pollination 
	{	
	[HideInInspector]
	public  bool                      gather;
	public  bool                      active;
	public  string                    collectable;
	public  GameObject                parent;	
	}
	// ----------  ----------    ----------   ---------- //
	public Pollination                pollinate; 
	
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines A Fresh List For All Transistions
	public List <float> intersection = new List <float> ();
	
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All  Private Attributes That Can Be Manipulated By The System
	private Animation      animation;
	// ----------  ----------    ----------   ---------- //
	private string         name;
	// ----------  ----------    ----------   ---------- //
	private Vector2        current;
	// ----------  ----------    ----------   ---------- //
	private float          distance;
	// ----------  ----------    ----------   ---------- //
	private int            quantity;	
	private int            zero;
	// ----------  ----------    ----------   ---------- //
	private GameObject     mother;
	// ----------  ----------    ----------   ---------- //
	private bool           progression;
	// ----------  ----------    ----------   ---------- //
	[HideInInspector] public string behaviour;
	// ----------  ----------    ----------   ---------- //
	private List <GameObject> index;
	
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines A Class For The Animation State Frames
	[System.Serializable]
	public class beetlejuice
	{	
	public bool    rythm;
	public Vector2 transistion;
	public Vector2 loop;
	}
	
	// ----------  ----------    ----------   ---------- //
	public beetlejuice walk;
	public beetlejuice idle;
	public beetlejuice gather;
	public beetlejuice attack;
	public beetlejuice flight;
		
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All  Public Enum That'll Represent All Differing Animation States
	public enum Motion
	{	
		walk          = 1,
		idle          = 2,
		attack        = 4, 
		gather        = 8,	
		flight        = 16	
	}
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All Public Enum Attributes That Can Be Manipulated By The Game Designer
	public Motion motion;
	
	
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Manages All Necessiary Attributes And Qualities On Awake
	void Awake () 
	{
	
	// ----------  ----------    ----------   ---------- //
	// Checks Whether A Suitable Animation Has Been Selected
	animation = this.gameObject.GetComponent <Animation> ();
	
	
	// ----------  ----------    ----------   ---------- //
	// Defines The Name Of The Animation File
	foreach (AnimationState state in animation)
	name     = state.name;

	// ----------  ----------    ----------   ---------- //
	// Calculates The Time ALternative For Each Respective Frame
	for (int interger   = 0; interger < intersection.Count; interger ++)
	{
    intersection [interger] = (intersection [interger] / framerate);
	intersection [interger] = (float) Math.Round (intersection [interger], 2);
    }
    
    
	// ----------  ----------    ----------   ---------- //
	// Selects The Default Behaviour State For Awake
	behaviour        = motion.ToString ();
	
	// ----------  ----------    ----------   ---------- //
	// Starts The Specified Creature Animation At A Selected Timeframe
	animation[name].speed = speed;
	animation.Play (name);
	
	}
	
	
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Progressively Goes Through The Creature Animations And Manages Any Necessiary Changes
	void Update () 
	{
	
	
	// ----------  ----------    ----------   ---------- //
	// Defines All "Motion" Enum Animation Transistions
	if ( (motion & Motion.walk)   == Motion.walk)
	Interference (walk.loop, walk.transistion, walk.rythm, Motion.walk);
	// ----------  ----------    ----------   ---------- //
	if ( (motion & Motion.idle)   == Motion.idle)
	Interference (idle.loop, idle.transistion, idle.rythm, Motion.idle);
	// ----------  ----------    ----------   ---------- //
	if ( (motion & Motion.gather) == Motion.gather)
	Interference (gather.loop, gather.transistion, gather.rythm, Motion.gather);
	// ----------  ----------    ----------   ---------- //
	if ( (motion & Motion.flight) == Motion.flight)
	Interference (flight.loop, flight.transistion, flight.rythm, Motion.flight);
	// ----------  ----------    ----------   ---------- //
	if ( (motion & Motion.attack) == Motion.attack)
	Attack (attack.loop, attack.transistion, Motion.attack);
	
	
	// ----------  ----------    ----------   ---------- //
	// This Acts As An Exception When Considering Looped Animation Transistions
	if (animation [name].time >= animation [name].length - approximate)
	animation [name].time      = 0.00f;
	
	
	// ----------  ----------    ----------   ---------- //
	// Gathers Pollen And Similar Such Goods From Nearby Surroundings
	Garther ();
	
	}
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Progressively Manipulates The Creature Attack Animation
	void Attack (Vector2 loop, Vector2 transistion, Motion mute)
	{
	
	// ----------  ----------    ----------   ---------- //
	// Calculates The Time ALternative For Each Respective Frame
    loop                = Mathematics.Framerate (framerate, loop);
	transistion         = Mathematics.Framerate (framerate, transistion);

	
	// ----------  ----------    ----------   ---------- //
    // Defines The Basic Transistion For The Attack Animation
    // - Checks Whether The Animation Has Reached A 'T-Pose' Frame 
    if (progression == false)
	if (animation [name].time < transistion.x || animation [name].time > transistion.y + approximate)
	{
	foreach (float intersect in intersection)
	{	
	if (animation [name].time > intersect && animation [name].time < intersect + approximate) 
	{
    animation [name].time = transistion.x;
    progression           = true;
    }
    }
    
    
	// ----------  ----------    ----------   ---------- //
    if (animation [name].time > loop.x && animation [name].time < loop.y)
	behaviour            = mute.ToString ();
    
	}

	// ----------  ----------    ----------   ---------- //
	if (progression == true)
	if (animation [name].time > transistion.y && animation [name].time < transistion.y + approximate) 
	{
	animation [name].time = loop.x;
	progression           = false;
    }
	
	}
	
	

	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Progressively Manipulates The Creature Animation Transistions 
	void  Interference (Vector2 loop, Vector2 transistion, bool rythm, Motion mute)
	{
	
	
	// ----------  ----------    ----------   ---------- //
	// Calculates The Time ALternative For Each Respective Frame
    loop                = Mathematics.Framerate (framerate, loop);
	transistion         = Mathematics.Framerate (framerate, transistion);
	
	
	// ----------  ----------    ----------   ---------- //
    // Defines All Transistions For The Standardized Animations
    // - Checks Whether The Animation Has Reached A 'T-Pose' Frame 
    if (rythm == false)
    {
	if (animation [name].time < loop.x || animation [name].time > loop.y + approximate)
	{
	foreach (float intersect in intersection)
	{	
	if (animation [name].time > intersect && animation [name].time < intersect + approximate) 
    animation [name].time = loop.x;
    }
	}
	}
			
	// ----------  ----------    ----------   ---------- //
	// Defines All Transistions For The Standardized Animations
    // - Checks Whether The Animation Has Reached A 'T-Pose' Frame 
	if (rythm == true)
	{
	if (animation [name].time < loop.x || animation [name].time > loop.y + approximate)
	{
	foreach (float intersect in intersection)	
	if (animation [name].time > intersect && animation [name].time < intersect + approximate) 
    animation [name].time     = transistion.x + approximate;
	}
    }
    
	
	// ----------  ----------    ----------   ---------- //
	//  Begins The Specified Creature Animation At The Selected Timeframe
	//  -  Loops The Specified Creature Animation If The Animation Has Run Its Course
	if (hardboiled == false)
	if (animation [name].time > loop.y  &&  animation [name].time < loop.y + approximate)
	{
	animation [name].time  = loop.x;
	}
	
	// ----------  ----------    ----------   ---------- //
	// Skips Immidiately To The Selected Animation If 'Hardboiled' Remains Active
	if (hardboiled == true)
	if (animation [name].time < loop.x || animation [name].time > loop.y)
	animation [name].time  = loop.x;
	
	
	// ----------  ----------    ----------   ---------- //
	// Defines The Behavioural Animation Of The Creature 
	if (animation [name].time > loop.x && animation [name].time < loop.y)
	behaviour              = mute.ToString ();
	
	// ----------  ----------    ----------   ---------- //
	animation [name].speed = speed;
	animation.Play (name);
	
	
	}
	
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Progressively Goes Through The Creature Animations And Manages Any Necessiary Changes
	void Garther ()
	{
	
	// ----------  ----------    ----------   ---------- //
	// Defines All Necessiary Attributes


	// ----------  ----------    ----------   ---------- //
	// Analyzes All Known Collectable(s) And Deciphers Which One May Be The Closest To Collect Pollen From
	if (pollinate.active)   {
	if (!pollinate.gather)  {
	if (behaviour       == Motion.gather.ToString () )
	{
	
	// ----------  ----------    ----------   ---------- //
	// Determines The Nearest Pollen Generator
	foreach (GameObject generator in GameObject.FindGameObjectsWithTag ("Pollenate").ToList () )
    {  
    // ----------  ----------    ----------   ---------- //       
    if (distance == zero)
    distance      = Vector3.Distance (transform.position, generator.transform.position);
    // ----------  ----------    ----------   ---------- //
    if (Vector3.Distance (transform.position, generator.transform.position) <= distance)
    {
    distance      = Vector3.Distance (transform.position, generator.transform.position);
    mother        = generator;   
    }
    }
    
    // ----------  ----------    ----------   ---------- //
    // Instantiates A Seedling Alongside The Creature
    Vector3     position            =  pollinate.parent.transform.position;
    Quaternion  rotation            =  pollinate.parent.transform.rotation;
    GameObject  seedling            =  mother.GetComponent <Pollinate> ().pollen;
	// ----------  ----------    ----------   ---------- //
    seedling                        =  Instantiate (seedling, position, rotation) as GameObject;
    // ----------  ----------    ----------   ---------- //
    seedling.transform.SetParent   (pollinate.parent.transform);
    seedling.transform.position     = new Vector3 (seedling.transform.position.x - 0.5f, seedling.transform.position.y - 0.25f, seedling.transform.position.z);
    
    
	// ----------  ----------    ----------   ---------- //
	pollinate.gather                =  true;
    }   
    }
    }
    

    
    }
	

	
}

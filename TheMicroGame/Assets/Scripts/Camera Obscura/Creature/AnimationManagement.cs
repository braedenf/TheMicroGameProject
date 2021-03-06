﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// Manipulates The Creatures Animations And Organizes Them To Remain Synced With One Another
public class AnimationManagement : MonoBehaviour 
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
	// ----------  ----------    ----------   ---------- //
	public List <Vector2> animate      = new List <Vector2> (5);
	public List <Vector2> intersection = new List <Vector2> (5);
	public List <Vector2> obscure      = new List <Vector2> (5);
	public List <Vector2> transistion  = new List <Vector2> (5);
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All  Private Attributes That Can Be Manipulated By The System
	private Animation      animation;
	// ----------  ----------    ----------   ---------- //
	private string         name;
	// ----------  ----------    ----------   ---------- //
	private Vector2        current;
	// ----------  ----------    ----------   ---------- //
	private int            quantity;
	
	// ----------  ----------    ----------   ---------- //
	[HideInInspector] public string behaviour;
	
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All  Public Enum That'll Represent All Differing Animation States
	public enum Motion
	{	
		walk          = 1,
		idle          = 2,
		flight        = 4, 
		gather        = 8		
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
	// Defines The Amount Of Pre-Specified Animations
	quantity    = animate.Count;
	
	// ----------  ----------    ----------   ---------- //
	// Calculates The Framerate To Seconds Ratio Of Each Animation
	for (int interger  = 0; interger < animate.Count; interger ++)
	animate [interger] = Mathematics.Framerate (framerate, animate [interger]);
	
	// ----------  ----------    ----------   ---------- //
	// Calculates The Framerate To Seconds Ratio Of Each Transistion
	for (int interger  = 0; interger < intersection.Count; interger ++)
	intersection [interger] = Mathematics.Framerate (framerate, intersection [interger]);
	
	// ----------  ----------    ----------   ---------- //
	// Calculates The Framerate To Seconds Ratio For Obscure Animations
	for (int interger  = 0; interger < obscure.Count; interger ++)
	obscure [interger]  = Mathematics.Framerate (framerate, obscure [interger]);
	
	// ----------  ----------    ----------   ---------- //
	// Calculates The Framerate To Seconds Ratio For Transistion Animations
	for (int interger  = 0; interger < transistion.Count; interger ++)
	transistion [interger]  = Mathematics.Framerate (framerate, transistion [interger]);
	
	// ----------  ----------    ----------   ---------- //
	// Calculates All The Interluding Animation Transistions
	int   count  = animate.Count;
	float length = (float) Math.Round (animation [name].length, 1);
	// ----------  ----------    ----------   ---------- //
	for (int interger  = 0; interger < (count + 1); interger++)
	{
	if (interger       == 0)
	animate.Add ( new Vector2 (0, animate [interger].x) );
	// ----------  ----------    ----------   ---------- //
	if (interger       != 0)
	animate.Add ( new Vector2 (animate [interger - 1].y, animate [interger].x) );
	// ----------  ----------    ----------   ---------- //
	if (interger       == count)
	animate.Add ( new Vector2 (animate [interger - 1].y, length) );
	}
	
	// ----------  ----------    ----------   ---------- //
	// Selects The Default Behaviour State For Awake
	behaviour        = motion.ToString ();
	
	// ----------  ----------    ----------   ---------- //
	// Starts The Specified Creature Animation At A Selected Timeframe
	animation[name].time = animate [1].x;
	animation[name].speed = speed;
	animation.Play (name);
	
	}
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Progressively Goes Through The Creature Animations And Manages Any Necessiary Changes
	void Update () 
	{
	
	// ----------  ----------    ----------   ---------- //
	// Defines The Current Animation State In Comparision To The Needed Animation State
	for (int interger = 0; interger < quantity; interger++)
	if (animation [name].time > animate [interger].x && animation [name].time < animate [interger].y)
	current = animate [interger];

	
	// ----------  ----------    ----------   ---------- //
	// Defines All "Motion" Enum Animation Transistions
	if ( (motion & Motion.walk)   == Motion.walk)
	Metamorphosis (animate [0], transistion [0]);
	// ----------  ----------    ----------   ---------- //
	if ( (motion & Motion.idle)   == Motion.idle)
	Metamorphosis (animate [1], transistion [1]);
	// ----------  ----------    ----------   ---------- //
	if ( (motion & Motion.flight) == Motion.flight)
	Metamorphosis (animate [2], transistion [2]);
	// ----------  ----------    ----------   ---------- //
	if ( (motion & Motion.gather) == Motion.gather)
	Metamorphosis (animate [3], transistion [3]);
	
	// ----------  ----------    ----------   ---------- //
	// This Acts As An Exception When Considering Looped Animation Transistions
	if (animation [name].time >= animation [name].length - approximate)
	animation [name].time      = 0.00f;
	
	
	}
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Progressively Manipulates The Creature Animation Transistions
	void Metamorphosis (Vector2 vertex, Vector2 transistion)
	{
	
	// ----------  ----------    ----------   ---------- //
	// Defines All Necessiary Attributes
	float minimum     = vertex.x;
	float maximum     = vertex.y;
	
	// ----------  ----------    ----------   ---------- //
	// Captures The Index Of Both Current And Desired Animation States
	int index         = animate.IndexOf (current);
	int desire        = animate.IndexOf (vertex);
	
	
	// ----------  ----------    ----------   ---------- //
	// Deciphers The Behaviour State Of The Current Animation
	if (current == vertex)
	behaviour        = motion.ToString ();
	
	// ----------  ----------    ----------   ---------- //
	// Defines All Transistions For Obscure Animation Transistions 
	foreach (Vector2 obscurity in obscure)
	{
	if (vertex      == obscurity)
	{
    // ----------  ----------    ----------   ---------- //
	foreach (Vector3 intersect in intersection)	
	if (animation [name].time > intersect.x && animation [name].time < intersect.x + approximate)
    animation [name].time  = transistion.x + approximate;   
    }
	}
	
	// ----------  ----------    ----------   ---------- //
	// Defines All Transistions For The Standardized Animations
	if (animation [name].time < minimum || animation [name].time > maximum)
	{
	// ----------  ----------    ----------   ---------- //
	foreach (Vector3 intersect in intersection)	
	if (animation [name].time > intersect.x && animation [name].time < intersect.x + approximate)
    animation [name].time  = minimum;    
	}
	
	
	// ----------  ----------    ----------   ---------- //
	//  -  Begins The Specified Creature Animation At The Selected Timeframe
	//  -  Loops The Specified Creature Animation If The Animation Has Run Its Course
	if (hardboiled == false)
	if (animation [name].time > maximum  &&  animation [name].time < maximum + approximate)
	animation [name].time  = minimum;
	
	
	// ----------  ----------    ----------   ---------- //
	// Skips Immidiately To The Selected Animation If 'Hardboiled' Remains Active
	if (hardboiled == true)
	if (animation [name].time < minimum || animation [name].time > maximum)
	animation [name].time  = minimum;
	
	
	// ----------  ----------    ----------   ---------- //
	animation [name].speed = speed;
	animation.Play (name);
	
	}
	
	
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// Manipulates The Creatures Animations And Organizes Them To Remain Synced With One Another
public class AnimationManagement : MonoBehaviour 
{

	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All  Public Attributes That Can Be Manipulated By The Game Designer
	[Range (0, 60) ] public int      framerate;
	// ----------  ----------    ----------   ---------- //
	[Range (0, 10) ] public float    speed;
	// ----------  ----------    ----------   ---------- //
	public List <Vector2> animate = new List <Vector2> ();
	
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All  Private Attributes That Can Be Manipulated By The System
	private Animation      animation;
	// ----------  ----------    ----------   ---------- //
	private string         name;
	// ----------  ----------    ----------   ---------- //
	private List <Vector2> transistion = new List <Vector2> ();
	
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All  Public Enum That'll Represent All Differing Animation States
	public enum Motion
	{	
		walk          = 1,
		idle          = 2,
		flight        = 3, 
		gather        = 4		
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
	// Calculates The Framerate To Seconds Ratio Of Each Animation
	for (int interger  = 0; interger < animate.Count; interger ++)
	animate [interger] = Mathematics.Framerate (framerate, animate [interger]);
	
	// ----------  ----------    ----------   ---------- //
	// Defines All The Interluding Animation Transistions

	
	// ----------  ----------    ----------   ---------- //
	// Starts The Specified Creature Animation At A Selected Timeframe
	Mathematics.Logged (animation [name].length);
	animation[name].time = animate [2].x;
	animation[name].speed = speed;
	animation.Play (name);
	
	}
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Progressively Goes Through The Creature Animations And Manages Any Necessiary Changes
	void Update () 
	{
	
	// ----------  ----------    ----------   ---------- //
	// Defines All "Motion" Enum Animation Transistions
//	if ( (motion & Motion.walk)   == Motion.walk)
//	Metamorphosis (walk);
//	// ----------  ----------    ----------   ---------- //
//	if ( (motion & Motion.idle)   == Motion.idle)
//	Metamorphosis (idle);
//	// ----------  ----------    ----------   ---------- //
//	if ( (motion & Motion.flight) == Motion.flight)
//	Metamorphosis (flight);
//	// ----------  ----------    ----------   ---------- //
//	if ( (motion & Motion.gather) == Motion.gather)
//	Metamorphosis (gather);
	
	}
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Progressively Manipulates The Creature Animation Transistions
	void Metamorphosis (Vector2 vertex)
	{
	
	// ----------  ----------    ----------   ---------- //
	// Begins The Specified Creature Animation At The Selected Timeframe
	animation [name].time  = vertex.x;
	animation [name].speed = speed;
	animation.Play (name);
	
	// ----------  ----------    ----------   ---------- //
	// Removes Any Possible "Motion" Enum Animation States
	motion  &= ~ Motion.flight;
	}
	
	
}

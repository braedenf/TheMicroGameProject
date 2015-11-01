using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// Deciphers The Motion Of The Specified Creature And Attempts To Set The Most Effective 
public class MotionAwareness : MonoBehaviour 
{

	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All  Public Attributes That Can Be Manipulated By The Game Designer
	public bool          awareness;
	public float         speed;

	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All  Private Attributes That Can Be Manipulated By The System
	private AntAnimation animation;
	private MoveObject   movement;
	// ----------  ----------    ----------   ---------- //
	private float        time;
	// ----------  ----------    ----------   ---------- //
	private int          zero;
	
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      //
	// Defines A Selective Class For All Needed Animation Transistions
	[System.Serializable]
	public class         transistion
	{	
	public string        animation;
	public float         time;
	}
	// ----------  ----------    ----------   ---------- //
	public List <transistion> motion = new List <transistion> ();
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Manages All Necessiary Attributes And Qualities On Awake
	void Awake () 
	{
	
	// ----------  ----------    ----------   ---------- //
	// Checks Whether A Suitable Animation Has Been Selected
	animation = this.gameObject.GetComponent <AntAnimation> ();
	movement  = this.gameObject.GetComponent <MoveObject> ();
	
	}
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Progressively Goes Through The Creature Animations And Manages Any Necessiary Changes
	void Update () 
	{
	
	// ----------  ----------    ----------   ---------- //
	// Determines All Needed Attributes
	 string term               = this.gameObject.name.ToString ();
	
	// ----------  ----------    ----------   ---------- //
	// Sets The Animation State Depending On Spline Triggers
	// This Is Determined By The Name Of The Selected GameObject (Set By The Spline System)
//	if (this.gameObject.name != animation.motion.ToString ())
//	animation.motion          = (AntAnimation.Motion) System.Enum.Parse ( typeof (AntAnimation.Motion), term);
	
	// ----------  ----------    ----------   ---------- //
	// Determines The Momentum Of The Selected Spline
	// Pauses The Linear Motion Unti The Creature Animation Has Occurred
	foreach (transistion index in motion)	
	if      (index.animation   == term)
	{	
	time                       += Time.deltaTime;  
	// ----------  ----------    ----------   ---------- //
	if (time                    < index.time)
	movement.speed              = 0.00f;
	// ----------  ----------    ----------   ---------- //
	else
	{
	movement.speed              = speed;	
	this.gameObject.name        = "walk";
	}
	}
	
    
	
	}
}

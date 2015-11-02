
using UnityEngine;
using SplineTool;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(FollowSpline))]
public class MoveObject : MonoBehaviour
{

	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All  Public Attributes That Can Be Manipulated By The Game Designer
    #region variables
    [Range (0, 10)  ]  public float   speed;
	[Range (0, 10)  ]  public float   orientation;
	[Range (0, 100) ]  public float   clamp;
	[Range (0, 10)  ]  public float   approximate;
	// ----------  ----------    ----------   ---------- //
    public Vector3 motion;
	// ----------  ----------    ----------   ---------- //
	public  SplineWindow         sploot;
    
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All  Private Attributes That Can Be Manipulated By The System
	private Vector3    creature;
	private Vector3    point;
	// ----------  ----------    ----------   ---------- //
	private Quaternion rotation;
	private Quaternion axis;
	private Quaternion history;
	private Quaternion contempory;
	// ----------  ----------    ----------   ---------- //
	private float      transistion;
	private float      transistor;
	private float      moment;
	private float      velocity;
	private float      time;
	private float      sand;
	// ----------  ----------    ----------   ---------- //
	private int     zero;
	// ----------  ----------    ----------   ---------- //
	private bool    awake;
	// ----------  ----------    ----------   ---------- //
	private AntAnimation         animation;
	
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines A Public Class That Holds Positional Information About The Animation Transistion Triggers
	[System.Serializable]
	public class Transistion 
	{
	[Range (0, 100) ]  public int   point; 
	[Range (0, 100) ]  public int   branch; 
	[Range (0, 100) ]  public float percentage;
	// ----------  ----------    ----------   ---------- //
	public Color  color;
	public AntAnimation.Motion animation;
	// ----------  ----------    ----------   ---------- //
	[Range (0, 100) ]   public float speed;
	[Range (0, 100) ]   public float pause;
	}
	
	
	// ----------  ----------    ----------   ---------- //
	public Transistion        start;
	public List <Transistion> node = new List <Transistion> ();
	// ----------  ----------    ----------   ---------- //
	private Transistion       pause = new Transistion ();
 
 
    #endregion
    
    
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Determines All Necessiary Attributes Needed On Awake
	void Awake ()
	{
	
	
	// ----------  ----------    ----------   ---------- //
	// Determines The Start Position Of The Spline Animation
	FollowSpline follow                 = this.gameObject.GetComponent <FollowSpline> ();
	// ----------  ----------    ----------   ---------- //
	if (sploot               != null)	
	{
	follow.note                         = (int) Mathematics.limitation (start.point,  zero,  sploot.spline.Length - 1);
	follow.branch                       = (int) Mathematics.limitation (start.branch, zero, sploot.spline.GetSubwaysLength (follow.note) - 1);
	follow.percentage                   = start.percentage / 100.00f;
     
	// ----------  ----------    ----------   ---------- //
	follow.enabled                      = true;
	}
	
	// ----------  ----------    ----------   ---------- //
	// Determines The Certain Speed Attributes For The Animation
	pause.speed              = speed;
	pause.pause              = zero;	
	
	
	}
    

	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Connects With This Creatures Registered Spline And Calculates All Necessiary Spline Animations 
    public void Move (Vector3 position, Spline spline)
    {
	
		// ----------  ----------    ----------   ---------- //
		// Calculates The Direction Between The Creature And The Spline Point Position
		Vector3 direction               = position - this.transform.position;
		float   magnitude               = direction.magnitude;
		// ----------  ----------    ----------   ---------- //
		direction                       = direction.normalized;
		     
		// ----------  ----------    ----------   ---------- //
		// Determines Certain Attribute Values On Awake
		if (!awake)
		{
	
		// ----------  ----------    ----------   ---------- //
		rotation                        = transform.rotation;
		axis                            = Quaternion.LookRotation (direction, motion);
		// ----------  ----------    ----------   ---------- //
		point                           = position;
		creature                        = transform.position;	
		// ----------  ----------    ----------   ---------- //
		velocity                        = speed;
		// ----------  ----------    ----------   ---------- //
		animation                       = this.gameObject.GetComponent <AntAnimation> ();
		// ----------  ----------    ----------   ---------- //
		awake                           = true;
		}
        
        // ----------  ----------    ----------   ---------- //
        // Determines The Creature Orientation Along The Spline
		if (transistor >= moment)
        {       
        rotation                        = transform.rotation;
		// ----------  ----------    ----------   ---------- //
		if (direction                  != Vector3.zero)
		axis                            = Quaternion.LookRotation (direction, motion);
	    // ----------  ----------    ----------   ---------- //
	    transistor                      = zero;
		// ----------  ----------    ----------   ---------- //
//		Mathematics.Logged ("Spline Rotation Reached");  
        }
        
		// ----------  ----------    ----------   ---------- //
		// Clamps The Creature Rotation Between Certain Parameters
		if (direction                  != Vector3.zero)
		contempory                      = Quaternion.LookRotation (direction, motion);
		// ----------  ----------    ----------   ---------- //
		if (Quaternion.Angle (history, contempory) >= clamp)
		{
		moment                          = zero;
		// ----------  ----------    ----------   ---------- //
//		Mathematics.Logged ( "Spline Rotation Exceeded Clamp" + Quaternion.Angle (rotation, axis) ); 
		} 
		else
		moment                          = 0.2f;
        
		// ----------  ----------    ----------   ---------- //
		// Manuevers The Selected Creature Rotation Along The Spline Over An Interval Of Time
		transistor                     += Time.deltaTime;
		transform.rotation              = Quaternion.Lerp (rotation, axis, transistor * orientation);

	    // ----------  ----------    ----------   ---------- //
	    // Dictates The Creature Position Along The Spline
        if (transform.position - point  == Vector3.zero)
        {    
        point                           = position;
        creature                        = transform.position;
		// ----------  ----------    ----------   ---------- //
		transistion                     = zero;
		// ----------  ----------    ----------   ---------- //
//        Mathematics.Logged ("Spline Point Reached");  
        }

		// ----------  ----------    ----------   ---------- //
		// Manuevers The Selected Creature Position Along The Spline Over An Interval Of Time
		transistion                   += Time.deltaTime;
		// ----------  ----------    ----------   ---------- //
		if (velocity                   > zero)
        transform.position             = Vector3.Lerp (creature, point, transistion * velocity);
       
        
		
		// ----------  ----------    ----------   ---------- //
		// Traces The Former Rotational Quaternion Of The Spline Position
		if (direction                  != Vector3.zero)
		history                         = Quaternion.LookRotation (direction, motion);
		
		
		
		// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
		// Deciphers The Position Of Certain Animation Triggers As Set By The Game Designer
		
		
		// ----------  ----------    ----------   ---------- //
		// Draws A Representative Symbol On The Spline For Each Defined Animation Trigger
		// Sets The Selected Animation That's Attributed To The Discovered Spline
		foreach (Transistion transit in node)
		{
			
			// ----------  ----------    ----------   ---------- //
			// Determines All Necessiary Attributes Needed
			float   percentage  =   transit.percentage / 100.00f;
			int     place       =   (int) Mathematics.limitation (transit.point, zero, sploot.spline.Length - 1);
			int		branch      =   (int) Mathematics.limitation (transit.branch, zero, sploot.spline.GetSubwaysLength (place) - 1);
			// ----------  ----------    ----------   ---------- //
			Vector3 note        =   sploot.spline.GetPointAtTime (percentage, place, branch);
			
			// ----------  ----------    ----------   ---------- //
		    Vector3 maximum     = Vector3.zero + (Vector3.one / approximate);
			Vector3 minimum     = Vector3.zero - (Vector3.one / approximate);
			float   distance    = Vector3.Distance (transform.position, note);
	
		    // ----------  ----------    ----------   ---------- //
		    // Determines Certain Distance Approxizations Between The Creature And The Animation Trigger
			// Determines The Set Motion Of The Animation, As Determined By The Current Creature Animation Behaviour
		    if (distance        >= minimum.x && distance  <= maximum.x)
			if (distance        >= minimum.y && distance  <= maximum.y)
			if (distance        >= minimum.z && distance  <= maximum.z)
		    animation.motion     = transit.animation;
		
			// ----------  ----------    ----------   ---------- //
			// Determines The Speed Of The Animation
			if (transit.pause        > zero)
			if (animation.motion    == transit.animation)
			if (animation.behaviour == transit.animation.ToString () )
			{
			pause.speed              = transit.speed;
			pause.pause              = transit.pause;	
			// ----------  ----------    ----------   ---------- //	
			pause.animation          = transit.animation;
			}
			
		}
		
		// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
		// Deciphers The Momentum Of Certain Animations As They're Concievably Triggered
		
		// ----------  ----------    ----------   ---------- //
		// Deciphers Whether The Momentum Is In Dire Wish Of Some Change
		if (pause.animation         != null )
		if (animation.motion        == pause.animation)
		{		
		time                       += Time.deltaTime;
		// ----------  ----------    ----------   ---------- //
		if (time                    < pause.pause)
		velocity                    = Mathf.Lerp (speed, pause.speed, time * 2.00f);
		// ----------  ----------    ----------   ---------- //
		else 
		{
		time                        = zero;		
		animation.motion            = AntAnimation.Motion.walk;
		}		
		}
		
		// ----------  ----------    ----------   ---------- //
		// Transistions Back Into A Pre-Determined Motion 
		if (pause.animation         != null )
		if (animation.behaviour     != pause.animation.ToString () )
		{
		sand                        += Time.deltaTime;
        velocity                     = Mathf.Lerp (pause.speed, speed, sand * 3.00f);    
        }
		// ----------  ----------    ----------   ---------- //
		else
		sand                         = zero;
        
	
		     
        }
    
    
    
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Draws A Series Of Visual Gizmos To Represent The Spline Animation Triggers
	[ExecuteInEditMode]
	void OnDrawGizmos ()
	{
	
	// ----------  ----------    ----------   ---------- //
	// Positions The Creature Along The Selected Start Position
	if (!Application.isPlaying)
	if (sploot               != null)
	{
	float  _percentage        =    start.percentage / 100.00f;
	int    _point             =   (int) Mathematics.limitation (start.point,  zero,  sploot.spline.Length - 1);
	int	   _branch            =   (int) Mathematics.limitation (start.branch, zero,  sploot.spline.GetSubwaysLength (_point) - 1);	
	// ----------  ----------    ----------   ---------- //
	Vector3 _position         =   sploot.spline.GetPointAtTime (_percentage, _point, _branch);
	// ----------  ----------    ----------   ---------- //
	this.transform.position   =   _position;
    }

	// ----------  ----------    ----------   ---------- //
	// Draws A Representative Symbol On The Spline For Each Defined Animation Trigger
	if (sploot               != null)	
	foreach (Transistion transit in node)
	{
	
	// ----------  ----------    ----------   ---------- //
	// Determines All Necessiary Attributes Needed
	float   percentage  =   transit.percentage / 100.00f;
	int     point       =   (int) Mathematics.limitation (transit.point,  zero,  sploot.spline.Length - 1);
	int		branch      =   (int) Mathematics.limitation (transit.branch, zero, sploot.spline.GetSubwaysLength (point) - 1);
	
	
	// ----------  ----------    ----------   ---------- //
	Vector3 position    =   sploot.spline.GetPointAtTime (percentage, point, branch);
	
	// ----------  ----------    ----------   ---------- //
	// Draws A Sphere Representing The Trigger Position
	Gizmos.color        = transit.color;
	Gizmos.color        = new Color (Gizmos.color.r, Gizmos.color.g, Gizmos.color.b, 1.0f);
	Gizmos.DrawSphere (position, 3);
	
	}
	
	}
	

}

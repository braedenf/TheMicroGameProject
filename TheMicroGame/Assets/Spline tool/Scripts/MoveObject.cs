
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
	// ----------  ----------    ----------   ---------- //
	private int     zero;
	// ----------  ----------    ----------   ---------- //
	private bool    awake;
	// ----------  ----------    ----------   ---------- //
	public SplineWindow         sploot;
	public AntAnimation         animation;
	
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines A Public Class That Holds Positional Information About The Animation Transistion Triggers
	[System.Serializable]
	public class Transistion 
	{
	[Range (0, 100) ]  public int   point; 
	[Range (0, 100) ]  public float percentage;
	// ----------  ----------    ----------   ---------- //
	public Color  color;
	public AntAnimation.Motion animation;
	// ----------  ----------    ----------   ---------- //
	[Range (0, 100) ]   public float pause;
	}
	
	
	// ----------  ----------    ----------   ---------- //
	public List <Transistion> node = new List <Transistion> ();
 
 
 
    #endregion
    
    

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
			int     place       =   transit.point;
			place               =   (int) Mathematics.limitation (place, zero, sploot.spline.Length - 1);
			// ----------  ----------    ----------   ---------- //
			Vector3 note        =   sploot.spline.GetPointAtTime (percentage, place, zero);
			
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
		    animation.motion        = transit.animation;
		
			
		}
	
		     
        }
    
    
    
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Draws A Series Of Visual Gizmos To Represent The Spline Animation Triggers
	void OnDrawGizmos ()
	{
	
	// ----------  ----------    ----------   ---------- //
	// Draws A Representative Symbol On The Spline For Each Defined Animation Trigger
	foreach (Transistion transit in node)
	{
	
	// ----------  ----------    ----------   ---------- //
	// Determines All Necessiary Attributes Needed
	float   percentage  =   transit.percentage / 100.00f;
	int     point       =   transit.point;
	point               =   (int) Mathematics.limitation (point, zero, sploot.spline.Length - 1);
	// ----------  ----------    ----------   ---------- //
	Vector3 position    =   sploot.spline.GetPointAtTime (percentage, point, zero);
	
	// ----------  ----------    ----------   ---------- //
	// Draws A Sphere Representing The Trigger Position
	Gizmos.color        = transit.color;
	Gizmos.DrawSphere (position, 1);
	}
	
	}
	

}

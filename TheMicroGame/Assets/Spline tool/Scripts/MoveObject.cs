// Copyright (c) 2014 Raed Abdullah
// moves the object along the spline with no physics

using UnityEngine;
using SplineTool;

[RequireComponent(typeof(FollowSpline))]
public class MoveObject : MonoBehaviour
{
    #region variables
    public float speed = 5;
    public Vector3 motion;

    /// <summary>
    /// if true the object will turn his z axis ( front ) to the headed position 
    /// else the object will not be affected with the position
    /// </summary>
    public bool lookRotation;
    #endregion

    /// <summary>
    /// Moving along the spline 
    /// </summary>
    /// <param name="pos">target position this object will move to</param>
    public void Move(Vector3 position)
    {
        if (position - transform.position == Vector3.zero) return;
		// ----------  ----------    ----------   ---------- //
		// Calculates The Direction Between The Creature And The Spline Point Position
		Vector3 direction = position - this.transform.position;
		float   magnitude = direction.magnitude;
		// ----------  ----------    ----------   ---------- //
        direction         = direction / magnitude;
        

         // ----------  ----------    ----------   ---------- //
		Vector3 perception = Vector3.RotateTowards (Vector3.right, direction, 1.0f, 1.0f);
		transform.rotation = Quaternion.LookRotation (perception, motion);
		


	    // ----------  ----------    ----------   ---------- //
        if (lookRotation)
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
      

		// ----------  ----------    ----------   ---------- //
		// Orientates The Character Rotation To Match The Spline 
//        if (lookRotation) 
//		transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation ((position - transform.position).normalized), 1.0f);

        
    }
}

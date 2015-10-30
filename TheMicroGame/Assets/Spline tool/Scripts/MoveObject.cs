// Copyright (c) 2014 Raed Abdullah
// moves the object along the spline with no physics

using UnityEngine;
using SplineTool;

[RequireComponent(typeof(FollowSpline))]
public class MoveObject : MonoBehaviour
{
    #region variables
    public float speed = 5;

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
    public void Move(Vector3 pos)
    {
        if (pos - transform.position == Vector3.zero) return;
      
	   // ----------  ----------    ----------   ---------- //
       if (lookRotation)
       transform.Translate(Vector3.forward * speed * Time.deltaTime);
        

		// ----------  ----------    ----------   ---------- //
		// Orientates The Character Rotation To Match The Spline 
        if (lookRotation) 
		transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation ((pos - transform.position).normalized), 1.0f);

        
    }
}

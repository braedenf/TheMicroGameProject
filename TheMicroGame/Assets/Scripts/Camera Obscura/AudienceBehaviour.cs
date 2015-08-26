using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// Manages The Over-Arching Audience Behaviour Relating To Basic Interactive Functions
// - The Operation Of The 'Gallery' State Management 
// - The Useability Of All 'Gallery' Attributes And Functions
public class AudienceBehaviour : MonoBehaviour 
{

	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All  Public Attributes That'll Be Run On Within The "Audience Behaviour" Class
	public float topward; 
	public float downward;
	public float center;
	// ----------  ----------    ----------   ---------- //
	public float acceleration;
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All  Private Attributes That'll Be Run On Within The "Audience Behaviour" Class
	private int count;
	// ----------  ----------    ----------   ---------- //
	private List <float> time = new List <float> (1); 
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All Attributes And Instances That'll Be Run On Awake
	void OnEnable () 
	{
		
	// ----------  ----------    ----------   ---------- //
	// Defines The State Of All Selected Attributes
	if (GameDirectory.photographic.Count != null)
	count = (int) (GameDirectory.photographic.Count - 1.00f);
	
	// ----------  ----------    ----------   ---------- //
	// Incrementally Goes Through The List Of Captured Photographes 
	// And Positions Them Suitably Within The 'Gallery' Interface Depending On Audience Interaction
	for (int item = (int) 0.00f;  item <= (int) (GameDirectory.photographic.Count - 1); item ++)
	{  
	
	// ----------  ----------    ----------   ---------- //
	//  Manuevers The Selected Photograph To Be Present Within The Interface  If So Required
	if (item == count)
	{
	Vector3 orientation  = (GameDirectory.photographic [item].position);
	GameDirectory.photographic [item].position = new Vector3 (orientation.x, center, orientation.z);
	}
	
	 // ----------  ----------    ----------   ---------- //
	// Manuevers The Selected Photograph Downwards If It's Not Designated To Be Present Within The Interface
	if (item != count)
	{
	Vector3 orientation  = (GameDirectory.photographic [item].position);
	GameDirectory.photographic [item].position = new Vector3 (orientation.x, downward, orientation.z);
	}
	
	}
	
	} 
	
	
	//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Progressively Retains A Systematic Influence On How The Gallery Is Expressed
	void Update () 
	{

	// ----------  ----------    ----------   ---------- //
	// Progressively References Whether The Gallery Has Developed In Dimension
	//  - Distinguishes Whether Selected Button Has Been Pressed Down
	// - Count Represents The "GameDirectory.photogtraphic" List Item That Should Now Be Represented On Screen
	if ( Input.GetKeyDown (KeyCode.RightArrow) )
	{
	if ( count < (int) (GameDirectory.photographic.Count - 1.00f) )
    count ++;
	// ----------  ----------    ----------   ---------- //
    print ("gallery" + "    " + count);
	}
	
	// ----------  ----------    ----------   ---------- //
	if ( Input.GetKeyDown (KeyCode.LeftArrow) )
	{
	if ( count > (int) 0.00f )
    count -= (int) 1.00f;
	// ----------  ----------    ----------   ---------- //
	print ("gallery" + "    " + count);
	}
	
	// ----------  ----------    ----------   ---------- //
	// Consistently Retains The Boundaries Of The Count Attribute
	if (count <= (int) 0.00f)
	count       = (int) 0.00f;
	
	
	// ----------  ----------    ----------   ---------- //
	// Maintains A List That's Equatable To The Lerp Motion Of The Selected Photographes
    while ( time.Count != GameDirectory.photographic.Count)
    time.Add (0.00f);
	
	
	// ----------  ----------    ----------   ---------- //
	// Incrementally Goes Through The List Of Captured Photographes 
	// And Positions Them Suitably Within The 'Gallery' Interface Depending On Audience Interaction
	for (int item = (int) 0.00f;  item < (int) (GameDirectory.photographic.Count); item ++)
	{  
    
   
	
    // ----------  ----------    ----------   ---------- //
	// Manuevers The Selected Photograph Upwards If It's Not Designated To Be Present Within The Interface
	if (item > count)
	{
	// ----------  ----------    ----------   ---------- //
	if (GameDirectory.photographic [item].position.y != topward)
	{
	
	if (time [item] <= 1.00f)
	time [item] += (Time.deltaTime / acceleration);
	// ----------  ----------    ----------   ---------- //
	Vector3 orientation  = (GameDirectory.photographic [item].position);
	Vector3 destination  = new Vector3 (orientation.x, topward, orientation.z);
	GameDirectory.photographic [item].position = Vector3.Lerp (orientation, destination, time [item]);
    }
	}
	
	
    // ----------  ----------    ----------   ---------- //
	// Manuevers The Selected Photograph Downwards If It's Not Designated To Be Present Within The Interface
	if (item < count)
	{
	// ----------  ----------    ----------   ---------- //
	if (GameDirectory.photographic [item].position.y != downward)
	{
	
	if (time [item] <= 1.00f)
	time [item] += (Time.deltaTime / acceleration);
	// ----------  ----------    ----------   ---------- //
	Vector3 orientation  = (GameDirectory.photographic [item].position);
	Vector3 destination  = new Vector3 (orientation.x, downward, orientation.z);
	GameDirectory.photographic [item].position = Vector3.Lerp (orientation, destination, time [item]);
    }
	}
	
		
    // ----------  ----------    ----------   ---------- //
	//  Manuevers The Selected Photograph To Be Present Within The Interface  If So Required
	if (item == count)
	{
	// ----------  ----------    ----------   ---------- //
	if (GameDirectory.photographic [item].position.y != center)
	{
	
	if (time [item] <= 1.00f)
	time [item] += (Time.deltaTime / acceleration);
	// ----------  ----------    ----------   ---------- //
	Vector3 orientation  = (GameDirectory.photographic [item].position);
	Vector3 destination  = new Vector3 (orientation.x, center, orientation.z);
	GameDirectory.photographic [item].position = Vector3.Lerp (orientation, destination, time [item]);
    }
	}
	
	
	
	}
}

}
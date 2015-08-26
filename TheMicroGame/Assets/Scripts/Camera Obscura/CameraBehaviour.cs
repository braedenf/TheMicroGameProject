using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// Manages The Over-Arching Organization And Attributes Of The Specified Audience Behaviour Relating To The Camera
public class CameraBehaviour : MonoBehaviour 
{
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All  Public Attributes That'll Be Run On Within The "Camera Obscura" Class
	public Image   visual; 
    public string     button = "space";
	// ----------  ----------    ----------   ---------- //
	public List <Sprite> photographic = new List <Sprite> (1); 
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All  Private Attributes That'll Be Run On Within The "Camera Obscura" Class
	private CameraObscura camera; 
	// ----------  ----------    ----------   ---------- //
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All Attributes And Instances That'll Be Run On Awake
	void Awake () 
	{
	
	// ----------  ----------    ----------   ---------- //
	// Sets A Fresh Cross-Dimensional Link To The "Camera Obscura" Class
	camera = new CameraObscura ();
	
	}
	
	//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Progressively Publishes A Photograph Whilst Remaining Responsive To The Audiences Will
	void Update ()
	{
	// ----------  ----------    ----------   ---------- //
	// - Publishes A Photograph And Attaches It To The 'CameraObscura' Discoverability List
	// - Converts To A Sprite File (To Make It Useable Within The Audience Interface)
    if (Input.GetKeyDown (button) )
    {
   
		
    	// print ("Photograph taken" + camera.discoverablity.Count); 
		// ----------  ----------    ----------   ---------- //
		camera.screenshot      = camera.discoverablity.Count;
		// ----------  ----------    ----------   ---------- //]
		int             item            = (int) (camera.discoverablity.Count - 1.00f);
		Sprite        sprite          = SpriteDesigner.conversion ( camera.discoverablity [item] );
		// ----------  ----------    ----------   ---------- //
		photographic.Add  (sprite);
		// ----------  ----------    ----------   ---------- //
		Sprite texture              = photographic [ (int) (photographic.Count - 1.00f) ];
		visual.sprite                 = texture;
      }

}

}

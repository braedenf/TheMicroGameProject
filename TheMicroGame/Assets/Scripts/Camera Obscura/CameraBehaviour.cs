using UnityEngine;
using System.Collections;


//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// Manages The Over-Arching Organization And Attributes Of The Specified Audience Behaviour Relating To The Camera
public class CameraBehaviour : MonoBehaviour 
{

	private int counter; 
	
	//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Progressively Publishes A Photograph Whilst Remaining Responsive To The Audiences Will
	void Update ()
	{
	
	// ----------  ----------    ----------   ---------- //
    if (Input.GetKeyDown ("space") )
    {
    	print ("Photograph taken"); 
		CameraManagement.CameraObscura camera = new CameraManagement.CameraObscura ();
		camera.screenshot = counter;
		counter ++;	
     }
}
}

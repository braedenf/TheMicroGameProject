using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// Manages The Over-Arching Organization And Attributes Of The Camera Obscura 
// - Captures A Static Photograph Of The Camera View
public class CameraManagement : MonoBehaviour 
{

// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// Defines All Attributes And Instances That'll Be Run On Within The Camera Obscura Class
public class CameraObscura 
{

	// ----------  ----------    ----------   ---------- //
	// Defines All Public Attributes Utilized Within The Following Code
	public List <string> discoverablity = new List <string> (); 
	// ----------  ----------    ----------   ---------- //
 
	
	// ----------  ----------    ----------   ---------- //
	//  Captures A Screenshot And Positions It Within The Public Screenshot List Library
	public int screenshot
	{ 
	set
	{
	Application.CaptureScreenshot ("Assets/Screenshots/screenshot" + value + ".png");
	discoverablity.Add ("screenshot" + value + ".png"); 
	}
	}
	
	
	}
	
	
}
	
	

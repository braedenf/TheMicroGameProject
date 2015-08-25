using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// Manages The Over-Arching Organization And Attributes Of The Camera Obscura 
// - Captures A Static Photograph Of The Camera View
public class CameraObscura 
{

	// ----------  ----------    ----------   ---------- //
	// Defines All Public Attributes Utilized Within The Following Code
	public List <Texture2D> discoverablity  = new List <Texture2D> (); 
	// ----------  ----------    ----------   ---------- //
 
	
	// ----------  ----------    ----------   ---------- //
	//  Captures A Screenshot And Positions It Within The Public Screenshot List Library
	public int screenshot
	{ 
	set
	{
	 Texture2D texture  = new Texture2D ( Screen.width, Screen.height, TextureFormat.RGB24, false );
	  texture.ReadPixels ( new Rect ( 0, 0, Screen.width, Screen.height), 0, 0 );
	  texture.Apply ();
	  // ----------  ----------    ----------   ---------- //
	 discoverablity.Add (texture); 
	}
	}
	
	
	
	}
	
	
	

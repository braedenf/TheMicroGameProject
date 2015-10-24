using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CaptureCamera : MonoBehaviour {
	
	

	public List <Texture2D> screenshot = new List <Texture2D> ();
	
	
	// Update is called once per frame
	void Update () 
	{
		
	
		Texture2D texture  = new Texture2D ( Screen.width, Screen.height, TextureFormat.RGB24, false );
		texture.ReadPixels ( new Rect ( 0, 0, Screen.width, Screen.height), 0, 0 );
		texture.Apply (); 
		// ----------  ----------    ----------   ---------- //
		screenshot.Add (texture); 
	}
}

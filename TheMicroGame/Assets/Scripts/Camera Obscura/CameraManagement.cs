using UnityEngine;
using System.Collections;

// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// Manages The Over-Arching Organization And Attributes Of The Camera Obscura 
// - Captures A Static Photograph Of The Camera View
public class CameraManagement : MonoBehaviour 
{

	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All Public Attributes Utilized Within The Following Code
	int screenshot;
	// ----------  ----------    ----------   ---------- //
	public Camera camera;
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All Attributes And Instances That'll Be Run Progressively Through Each Following Frame 
	void Update () 
	{
	
	// ----------  ----------    ----------   ---------- //
	// Captures A Static Photograph Of The Camera View When The Audience Interacts With The System 
	if (Input.GetKeyDown ("space" ) )
	{
	 // ----------  ----------    ----------   ---------- //
	 print ( "screenshot printed" + "     " + screenshot); 
	
	// ----------  ----------    ----------   ---------- //
	// Sets Which Camera Will Be Capturing The Screenshot
			Camera camOV = camera;
			
			RenderTexture currentRT = RenderTexture.active;
			
				RenderTexture.active = camOV.targetTexture;
				camOV.Render();
				Texture2D imageOverview = new Texture2D(camOV.targetTexture.width, camOV.targetTexture.height, TextureFormat.RGB24, false);
				imageOverview.ReadPixels(new Rect(0, 0, camOV.targetTexture.width, camOV.targetTexture.height), 0, 0);
				imageOverview.Apply();
				
				RenderTexture.active = currentRT;
				
				
				// Encode texture into PNG
				byte[] bytes = imageOverview.EncodeToPNG();
				
				// save in memory
				string filename = ( "screenshot printed" + "     " + screenshot); 
				string path      =  ( Application.persistentDataPath + "/screenshots/" + filename );
				
				System.IO.File.WriteAllBytes(path, bytes);
	}
	
	}
	
}
	
	

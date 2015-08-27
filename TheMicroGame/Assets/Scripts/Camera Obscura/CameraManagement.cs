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
 
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	//  Captures A Screenshot From The Lead Camera And Positions It Within The Public Screenshot List Library
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
	
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Analyses The Selected Creature And Establishes An Appropriate Score For The Photograph It's Present Within
	public int scoreboard (GameObject creature, Camera camera)
	{
	
	Transform   transform = creature.transform;
	Renderer   render    = creature.GetComponent <Renderer> ();
	Mesh         mesh      = creature.GetComponent <MeshFilter> ().mesh;
	Vector3 []  vertices  = mesh.vertices;
	int              count    = mesh.vertexCount;
	// ----------  ----------    ----------   ---------- //
	Plane [ ]    planes = GeometryUtility.CalculateFrustumPlanes (camera);
	// ----------  ----------    ----------   ---------- //
	int             length          =  (planes.GetLength (0) - 1);
	int             percentage =  (int) 0.00f;
	int             score           =  (int) 0.00f;
	
	// ----------  ----------    ----------   ---------- //
	// References Whether An Individual Mesh Vertice Is Visible To The Selected Camera
	// - Calculates The Score Percentage System For The Taken Photograph
	foreach (Vector3 vertice in vertices)
	{
	for (int item = 0; item < length; item ++)
	{	
	
	// ----------  ----------    ----------   ---------- //
	// - Overides The For Loop Process If Vertice Is Invisible
	if (planes [item].GetDistanceToPoint (transform.TransformPoint (vertice) )  < 0) 
	{
	percentage ++;
	item = planes.GetLength (0);
	}
	
	}
	}

	
	// ----------  ----------    ----------   ---------- //
	// Applies The Selected Percentage To The Photographic Score
	score = count - percentage;
	return score;
	
	} 
	
	
	
	
	
	}
	
	
	

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
	public List <Vector3> visibility (GameObject creature, Camera camera)
	{
	
	Transform   transform   = creature.transform;
	Renderer    render      = creature.GetComponent <Renderer> ();
	Mesh        mesh        = creature.GetComponent <MeshFilter> ().mesh;
	int         count       = mesh.vertexCount;
	// ----------  ----------    ----------   ---------- //
	var         vertices	= mesh.vertices.ToList ();
	// ----------  ----------    ----------   ---------- //
	Plane [ ]   planes      = GeometryUtility.CalculateFrustumPlanes (camera);
	// ----------  ----------    ----------   ---------- //
	int         length      =  (planes.GetLength (0) - 1);
	int         percentage  =  (int) 0.00f;
	int         score       =  (int) 0.00f;
	
	// ----------  ----------    ----------   ---------- //
	// References Whether An Individual Mesh Vertice Is Visible To The Selected Camera
	// - Calculates The Score Percentage System For The Taken Photograph
	for (int vertex = 0; vertex <= (vertices.Count - 1.00f); vertex ++)
	{
	
	for (int item   = 0; item   <= length; item ++)
	{	
	
	// ----------  ----------    ----------   ---------- //
	Vector3 vertice = vertices [vertex];
	
	// ----------  ----------    ----------   ---------- //
	// - Overides The For Loop Process If Vertice Is Invisible
	// - Removes The Invisible Vertex From The "Vertex" List
	if (planes [item].GetDistanceToPoint (transform.TransformPoint (vertice) )  < 0) 
	{
	vertices.RemoveAt  (vertex);
	// ----------  ----------    ----------   ---------- //
	vertex           -= (int) 1.00f;
	item              = planes.GetLength (0);
	}
	
	}
	}

	// ----------  ----------    ----------   ---------- //
	// Returns The Remaining Visible Vertices
	return vertices;
	
	} 
	
	
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Analyzes Which Vertices Remain Visible By Utilizing Raycast Collision
	public List <Vector3> raycast (List <Vector3> vertices, Camera camera, GameObject attribute)
	{
	
	// ----------  ----------    ----------   ---------- //
	RaycastHit collision;
		
	Vector3    central    = new Vector3 (Screen.width / 2.00f, Screen.height / 2.00f, 0.00f);	
	Vector3    origin     =	camera.ScreenToWorldPoint (central);
	// ----------  ----------    ----------   ---------- //
	// Progressively Goes Through Each Vertice And Deciphers Whether It's Immidiatly Visible
	for (int vertex = 0; vertex <= (vertices.Count - 1.00f); vertex ++)
	{	
	

     Vector3 destination = vertices [vertex];
     
	// ----------  ----------    ----------   ---------- //
	// Casts A Ray In The Direction Of The Specified Vertice
	// - Establishes Whether It's Aligned With The Selected Gameobject
	if (Physics.Linecast (origin, destination, out collision))
	{
	
	// ----------  ----------    ----------   ---------- //
	if (collision.transform.name != attribute.transform.name)
	{

Debug.Log ("cgg");
	vertices.RemoveAt (vertex);
	// ----------  ----------    ----------   ---------- //
	vertex           -= (int) 1.00f;
	
	}	
	
	}
	
	}
	
	// ----------  ----------    ----------   ---------- //
	// Returns The Remaining Visible Vertices
	return vertices;
	}
	
	
	
	}
	
	
	

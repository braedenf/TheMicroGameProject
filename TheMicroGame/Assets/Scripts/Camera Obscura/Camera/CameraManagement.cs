﻿using UnityEngine;
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
	public int screenshot (Texture texture)
	{ 
	
//	  Texture2D texture  = new Texture2D ( Screen.width, Screen.height, TextureFormat.RGB24, false );
//	  texture.ReadPixels ( new Rect ( 0, 0, Screen.width, Screen.height), 0, 0 );
//	  texture.Apply (); 
	  // ----------  ----------    ----------   ---------- //
		Texture2D mute = new Texture2D ( Screen.width, Screen.height, TextureFormat.RGB24, false );
	  mute.ReadPixels ( new Rect ( 0, 0, texture.width, texture.height), 0, 0 );
	  mute.Apply ();
	  discoverablity.Add ( mute ); 
//	  
	  return discoverablity.Count;
	
	}
	
	
	
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Analyses The Selected Creature And Establishes An Appropriate Score For The Photograph It's Present Within
	public List <Vector3> visibility (GameObject creature, Camera camera)
	{
	
	Transform      transform               = creature.transform;
	// ----------  ----------    ----------   ---------- //
	Plane [ ]       planes                 = GeometryUtility.CalculateFrustumPlanes (camera);
	// ----------  ----------    ----------   ---------- //
	int             length                 =  (planes.GetLength (0) - 1);
	// ----------  ----------    ----------   ---------- //
	var  points                            = creature.GetComponent <MeshFilter> ().mesh.vertices.ToList ();
	

	// ----------  ----------    ----------   ---------- //
	// References Whether An Individual Mesh Vertice Is Visible To The Selected Camera
	// - Calculates The Score Percentage System For The Taken Photograph
	for (int vertex = 0; vertex < (points.Count); vertex ++)
	{
	
	for (int item   = 0; item   < length; item ++)
	{	
	
	// ----------  ----------    ----------   ---------- //
	Vector3 vertice = points [vertex];
	
	// ----------  ----------    ----------   ---------- //
	// - Overides The For Loop Process If Vertice Is Invisible
	// - Removes The Invisible Vertex From The "Vertex" List
	if (planes [item].GetDistanceToPoint (transform.TransformPoint (vertice) )  < 0) 
	{
	points.RemoveAt  (vertex);
	// ----------  ----------    ----------   ---------- //
	vertex           -= (int) 1.00f;
	item              = planes.GetLength (0);
	}
	
	}
	}

	// ----------  ----------    ----------   ---------- //
	// Returns The Remaining Visible Vertices
	return points;
	
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
	for (int vertex  = 0; vertex <= (vertices.Count - 1.00f); vertex ++)
	{	
	
	Vector3 destination = attribute.transform.TransformPoint (vertices [vertex]);
	
	// ----------  ----------    ----------   ---------- //
	// Casts A Ray In The Direction Of The Specified Vertice
	// - Establishes Whether It's Aligned With The Selected Gameobject
	if (Physics.Linecast (origin, destination, out collision))
	{
	

	// ----------  ----------    ----------   ---------- //
	if (collision.transform.name != attribute.transform.name)
	{
	
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
	
	
	//-----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Analyzes The Texture Pixels And Converts Them Into A Grayscale Format
	public Texture2D Borderline (Texture2D texture, float border)
	{
	
	// ----------  ----------    ----------   ---------- //
	// Defines All Possible Attributes
	var   pixels     = texture.GetPixels ();
	Color color;
	
		
	// ----------  ----------    ----------   ---------- //
	// Defines The Border Dimensions
	border          = (Screen.width / 100.00f) * border;
		
	
	// ----------  ----------    ----------   ---------- //
	// Defines The Visual Affects Within The Texture
	for (int height = 0; height < texture.height; height ++) 
	for (int width  = 0; width < texture.width; width ++) 
	if (width  < border || width > (texture.width  - border) || height  < border || height > (texture.height  - border) )
	{
	color             = Color.white;
	texture.SetPixel (width, height, color);
	}
	
	// ----------  ----------    ----------   ---------- //
	// Applies The Pixel Changes To The Texture
	texture.Apply ();
		
	// ----------  ----------    ----------   ---------- //
	// Returns A Grayscale Texture
	return texture;
	
	} 
	
	//-----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
    // Analyzes The Texture Pixels And Converts Them Into A Grayscale Format
    public Texture2D Grayscale (Texture2D texture, float grain, float tear, float shadow, float light)
    {
		
		// ----------  ----------    ----------   ---------- //
		// Defines All Possible Attributes
		var   pixels     = texture.GetPixels ();
		Color color;
		
		// ----------  ----------    ----------   ---------- //
		// Defines The Visual Affects Within The Texture
		for (int height = 0; height < texture.height; height ++) 
		{	
		for (int width  = 0; width < texture.width; width ++) 
		{
		
		// ----------  ----------    ----------   ---------- //
        // Manipulates The Texture Contrast Depending On The Discovered Color Hues
        // - Deciphers Whether A Certain Pixel Should Be Darker, Or Lighter
        var   pixel       = texture.GetPixel (width, height);
        float distinction = (pixel.r + pixel.b + pixel.g);

		// ----------  ----------    ----------   ---------- //
        if (distinction   < 1.50f)
        pixel             = new Color (pixel.r - shadow, pixel.g - shadow, pixel.b - shadow);
        else
		pixel             = new Color (pixel.r + light,  pixel.g + light,  pixel.b + light);


	    // ----------  ----------    ----------   ---------- //
	    // Calculates The Screen Tearing On A Pixel-By-Pixel Basis
		float screen = (texture.height - height) / tear;


		// ----------  ----------    ----------   ---------- //
		// Calculates A Certain Quantity Of Graininess On A Pixel-By-Pixel Basis
		float red   = pixel.r + Random.Range (- grain, grain) + screen;
		float green = pixel.g + Random.Range (- grain, grain) + screen;
		float blue  = pixel.b + Random.Range (- grain, grain) + screen;
		// ----------  ----------    ----------   ---------- //
		color       = new Color (red, green, blue);
		

        // ----------  ----------    ----------   ---------- //
        // Sets The Pixel Colour
		texture.SetPixel (width, height, color);
		
		
		// ----------  ----------    ----------   ---------- //
		// Progressively Converts All Pixels To Grayscale
		var grayscale = texture.GetPixel (width, height).grayscale;
		color         = new Color (grayscale, grayscale, grayscale);
		// ----------  ----------    ----------   ---------- //
		texture.SetPixel (width, height, color);
		
		}
		}
		
	// ----------  ----------    ----------   ---------- //
	// Applies The Pixel Changes To The Texture
	texture.Apply ();
		
	
	// ----------  ----------    ----------   ---------- //
	// Returns A Grayscale Texture
	return texture;
	
	}

	
	}
	

﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// Instantiates Fresh Transistion Images Along A Vertical Axis For 'Gallery' Interface
public class Transistion : MonoBehaviour 
{


	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All Public Attributes That'll Be Manipulated By The Game Designer
	[ Range (0, 100) ] public float      seperation;
	// ----------  ----------    ----------   ---------- //
	public GameObject instance;
	public GameObject illustration;
	// ----------  ----------    ----------   ---------- //
	public Transform  parent;
	
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All Private Attributes That'll Be Manipulated By The System
	private int       zero;
	private int       count;
	private int       discover = 0;
	
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All Necessiary Attributes And Qualities On Enable
	void OnEnable () 
	{
	
	// ----------  ----------    ----------   ---------- //
	// Deciphers Whether An "Instance" Has Been Selected
	if (!instance)
	Debug.Log ("You Should Possibly Select An 'Instance' For The Transistion Code");
	
	// ----------  ----------    ----------   ---------- //
	// Deciphers The "Instance" Parent
	parent = instance.transform.parent;
	
	}
	
	
	
	//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Progressively Instantiates Fresh Transistion Images Depending On Taken Photographes
	void Update () 
	{
	
	// ----------  ----------    ----------   ---------- //
	// Deciphers Whether A Fresh Photograph Has Been Taken And Applies It To The Interface
	Capture ();
	
	// ----------  ----------    ----------   ---------- //
	// Manuvers The List Of Images Depending On Certain Interactions From The Audience Members
	Manuver ();
	
	// ----------  ----------    ----------   ---------- //
	// Refines The List Count After Each Respective Code Call
	count    = GameDirectory.photographic.Count;
	
	}
	
	
	
	//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Deciphers Whether A Fresh Photograph Has Been Taken And Applies It To The Interface
	void Capture () 
	{
	
	// ----------  ----------    ----------   ---------- //
	// Defines All Necessiary Attributes For The 'Transistion' Instantiation 
	float       distance;
	Vector3     seperate;
	GameObject  instantiate;
	
	// ----------  ----------    ----------   ---------- //
	// Instantiates A Fresh Transistion If A Photograph Has Been Taken
	if (count < GameDirectory.photographic.Count)
	{	
	// ----------  ----------    ----------   ---------- //
	// Defines The Quantity Of Sprites Within The Sprite List
	int counter       = GameDirectory.photographic.Count - 1;
	
	// ----------  ----------    ----------   ---------- //
	// Calculates The Position Depending On Screen Height
	// Sets The Heirachy Position Within The 'Gallery' Interface
	distance          = (seperation / 100.00f) * Screen.height * count;
	seperate          = instance.transform.position;
	// ----------  ----------    ----------   ---------- //
	seperate.y        = instance.transform.position.y - distance;
	
	// ----------  ----------    ----------   ---------- //
	// Instantiates A Fresh Transistion
	instantiate       = Instantiate (instance, seperate, instance.transform.rotation) as GameObject;
	instantiate.transform.SetParent (parent, true);
	
	// ----------  ----------    ----------   ---------- //
	// Attempts Retain A Sense Of Similarity Between Each Instantiation
	Vector3     scale = instance.transform.localScale;
	// ----------  ----------    ----------   ---------- //
	instantiate.transform.localScale = scale;
	
	// ----------  ----------    ----------   ---------- //
	// Gives The Image Attribute The Latest Captured Photograph Texture
	instantiate.GetComponent <Image> ().enabled = true;
	instantiate.GetComponent <Image> ().sprite  = GameDirectory.photographic [counter].sprite;

	}
	
	}
	
		
	//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Manuvers The List Of Images Depending On Certain Interactions From The Conducter
	void Manuver ()
	{
	
	// ----------  ----------    ----------   ---------- //
	// Defines The Quantity Of Sprites Within The Sprite List
	int counter       = GameDirectory.photographic.Count - 1;
	
	// ----------  ----------    ----------   ---------- //
	// Manuvers Through The Image Interface At All Whim Of The Conducter
	if (Input.GetKeyDown (KeyCode.DownArrow) )
	if (discover < counter)
	{
	float distance  = (seperation / 100.00f) * Screen.height;
	Vector3 point   = parent.transform.position;
	// ----------  ----------    ----------   ---------- //
	parent.transform.position = new Vector3 (point.x, point.y + distance, point.z);
	
	// ----------  ----------    ----------   ---------- //
	discover ++;
	}
	
	
	// ----------  ----------    ----------   ---------- //
	if (Input.GetKeyDown (KeyCode.UpArrow) )
	if (discover > zero)
	{
	float distance  = (seperation / 100.00f) * Screen.height;
	Vector3 point   = parent.transform.position;
	// ----------  ----------    ----------   ---------- //
	parent.transform.position = new Vector3 (point.x, point.y - distance, point.z);
	
	// ----------  ----------    ----------   ---------- //
	discover --;
	}
	

	// ----------  ----------    ----------   ---------- //
	// Attributes The Selected Sprite To The Illustration Image
	if (GameDirectory.photographic.Count       != zero)
	illustration.GetComponent <Image> ().sprite = GameDirectory.photographic [discover].sprite;

	
	}
	
	
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// A Code File Comprised Of All The Static Attributes Necessiary For Game Management
//  -  Possesses A Static List Composed Of Captured Photographes
public static class GameDirectory 
{

	//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	//  A Static List Comprised Exclusively From 'Audience' Captured Photographes
	//  - public static List <RectTransform> photographic = new List <RectTransform> (1); 
	public static List <Photography> photographic = new List <Photography> ();
	
	public static List <GameObject> discovery        = new List <GameObject> ();
	public static List <GameObject> gallery          = new List <GameObject> ();
	
	
	//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// A Public Class Container Designed To Possess All Necessiary 'Photography' Attributes
	// Comprised Exclusively From 'Audience' Captured Photographes
	public class Photography 
	{
	public RectTransform    representation;
	public int              scoreboard; 
	}
	

	
}

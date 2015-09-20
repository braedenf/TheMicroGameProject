using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      //
// Maintains All Serialiazble "Narrative" Assets 
public static class NarrativeManagement
{


	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      //
	// Defines All  Public Attributes That'll Be Run On Within The "Narrative Management" Class
	public static List <Narrative> narrative = new List <Narrative> ();
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Stores All Necessiary "Narrative" Assets Within A Nested List System 
	public static bool Load ()
	{
	
	// ----------  ----------    ----------   ---------- //
	// Imports All "Narrative" Assets From The Resource Folder
	// Note To Self : Remember This Syntax, Because It Actually Makes Sense
	var asset  = Resources.LoadAll("Narrative", typeof(Narrative)).Cast <Narrative>();
	narrative  = asset.ToList ();
	
	// ----------  ----------    ----------   ---------- //
	Mathematics.Logged ("Narrative Count", narrative.Count);
	
	// ----------  ----------    ----------   ---------- //
	bool accomplished   = false;
	
	// ----------  ----------    ----------   ---------- //
	if (narrative.Count > 0)
	return accomplished = true;
	else
	return accomplished = false;
	
	}
	
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Attempts To Decipher Which Narrative Is Best Suited The Captured Photograph
	// - Progressively Goes Through The "Narrative" Script
	// - Returns The Necessiary "Narrative" Script If Discovered
	// - Returns "Null" If The Necessiary "Narrative Script Wasn't Discovered
	public static Narrative Depiction (string creature, string state, string interaction)
	{
	
	// ----------  ----------    ----------   ---------- //
	foreach (Narrative item in narrative) 
	{
	// ----------  ----------    ----------   ---------- //
	if (creature == item.creature && state == item.state && interaction == item.interaction)
	return item;
	}
	
	// ----------  ----------    ----------   ---------- //
	return null;
	
	}
	

	
	
	
	
}

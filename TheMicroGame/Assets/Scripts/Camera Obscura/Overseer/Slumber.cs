using UnityEngine;
using System.Collections;

// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// Manages All Necessiary Attributes On Game Awake
// - Gathers Up All The Differing "Narrative" Attributes And Compiles Them Into A List
public class Slumber : MonoBehaviour
{

	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All Attributes And Instances That'll Be Run On Awake 
	void Awake () 
	{
	
	// ----------  ----------    ----------   ---------- //
	// Nullifies All Static Attributes On Awake
	CreatureManagement.creatures.Clear ();
	NarrativeManagement.narrative.Clear ();
	GameDirectory.discovery.Clear ();
	GameDirectory.photographic.Clear ();
	GameDirectory.gallery.Clear ();
	
	
	// ----------  ----------    ----------   ---------- //
	// Defines And Accesses The "NarrativeManagement" Script And Loads All Necessiary Narratives
	bool narrative = NarrativeManagement.Load (); 
	if (narrative  == false)
	Mathematics.Logged ("It May Be Rather Lovely To Shove Some Narrative Assets Into The Resource Folder");
	
	}
	
}

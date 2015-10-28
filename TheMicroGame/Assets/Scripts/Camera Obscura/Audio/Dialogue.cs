using UnityEngine;
using System.Collections;

//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// Defines And Calls All Necessiary Character Dialogue
public class Dialogue : MonoBehaviour 
{

	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All Private Attributes That'll Be Manipulated By The System
	private int counter;
	// ----------  ----------    ----------   ---------- //
	private FMOD.Studio.EventInstance dialogue;
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All Attributes And Instances That'll Be Run On Awake
	void Awake () 
	{
	
	// ----------  ----------    ----------   ---------- //
	// Sets The 'GameDirectory' Photography List Length
	counter = GameDirectory.photographic.Count;
	
	}
	
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All Attributes And Instances That'll Be Progressively Run Each Frame
	void Update () 
	{
	
	// ----------  ----------    ----------   ---------- //
	// Runs A Fresh Audio Dialogue If A Fresh Photograph Has Been Captured
	if (GameDirectory.photographic.Count > counter)
	{
	
	// ----------  ----------    ----------   ---------- //
	// Defines All Necessiary Attributes
	int    count       = (int) (GameDirectory.photographic.Count - 1.00f);
	string transistion = GameDirectory.photographic [count].transistion;
	
    // ----------  ----------    ----------   ---------- //
	dialogue = FMOD_StudioSystem.instance.GetEvent ("event:/Male/" + transistion);
    dialogue.start ();
			
	}
	
	// ----------  ----------    ----------   ---------- //
	// Sets The 'GameDirectory' Photography List Length
	counter = GameDirectory.photographic.Count;
	
	}
}

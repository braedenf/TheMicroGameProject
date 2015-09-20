using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// Manages The Over-Arching Organization And Attributes Of The Specified Creatures States And 'Artificial Intelligence'
public class StateManagement : MonoBehaviour 
{

	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All  Public Attributes That'll Be Run On Within The "StateManagement" Class
	public string creature; 
	public string state; 
	public string interaction;

	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All Attributes And Instances That'll Be Run On Awake
	void Awake () 
	{
	
	// ----------  ----------    ----------   ---------- //
	// Attaches The Specified Creature To The 'Creature Management' Creature List
	CreatureManagement.Heirachy creatureManagement   =  new CreatureManagement.Heirachy ();
	creatureManagement.creature                      =  this.gameObject;
	
	}
	
	
	
}

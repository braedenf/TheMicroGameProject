using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// Manages The Over-Arching Organization And Attributes Of The Specified Creatures States And 'Artificial Intelligence'
public class StateManagement : MonoBehaviour 
{

	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All  Public Attributes That Can Be Manipulated By The Game Designer
	public string creature; 
	public string state; 
	public string interaction;
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All  Private Attributes That Can Be Manipulated By The System
	private AnimationManagement animation;

	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All Attributes And Instances That'll Be Run On Awake
	void Awake () 
	{
	
	// ----------  ----------    ----------   ---------- //
	// Attaches The Specified Creature To The 'Creature Management' Creature List
	CreatureManagement.Heirachy creatureManagement   =  new CreatureManagement.Heirachy ();
	creatureManagement.creature                      =  this.gameObject;
	
	// ----------  ----------    ----------   ---------- //
	// Defines All Necessiary Attributes
	animation                                        = this.gameObject.GetComponent <AnimationManagement> ();
		
	}
	
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Progressively Updates On Each Consecutive Frame
	void Update () 
	{
	
	// ----------  ----------    ----------   ---------- //
	// Deciphers What The Creature Behaviour State Is
	if (animation.behaviour != null)
	state                                           = animation.behaviour;
	
	}
	
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// Manages The Over-Arching Organization And Attributes Of All Creatures Within The Game Realm 
// - Possessing A List Of All Creatures Within The Game Realm
public class CreatureManagement : MonoBehaviour 
{

	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All Attributes And Instances That'll Be Run On Awake
	public class Heirachy
	{ 
	
		// ----------  ----------    ----------   ---------- //
		// Defines All Public Attributes Utilized Within The Following Code
	    public List <GameObject> creatures = new List <GameObject> (); 
	
		// ----------  ----------    ----------   ---------- //
		// Defines An Attribute That'll Actively Attach Fresh Creatures To The Creatures List
	    public GameObject creature
	    { 
	    set  
	    { 
	    creatures.Add (value);  
	    print ( creatures [creatures.Count - 1].name); 
	    }
				
	    } 
	
	}
	

	
	
}

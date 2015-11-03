using UnityEngine;
using System.Collections;
using System.Collections.Generic;


// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// Manages The Over-Arching Organization And Attributes Of All Creatures Within The Game Realm 
// - Possessing A List Of All Creatures Within The Game Realm
public class CreatureManagement
{

	// ----------  ----------    ----------   ---------- //
	// Defines All Public Attributes Utilized Within The Following Code
	public static List <GameObject> creatures = new List <GameObject> (1); 

	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All Attributes And Instances That'll Be Run On Within The Heirachy Class
	public class Heirachy
	{ 
	
		// ----------  ----------    ----------   ---------- //
		// Defines An Attribute That'll Actively Attach Fresh Creatures To The Creatures List
	    public GameObject creature
	    { 
	    
	    set  
	    { 
	    creatures.Add (value);  
	     Debug.Log ( creatures [creatures.Count - 1].name); 
	    }	
	    	
	    } 
	
	}
	
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Calculates The Visiblity Of All Creatures Represented Within The Realm
	// - Calculates The Vicinity Of All Visible Creatures
	public static GameObject visiblity (Camera camera)
	{
	
	GameObject creature = null;
	float      vicinity = Mathf.Infinity;
	
	// ----------  ----------    ----------   ---------- //
	// Progressively Goes Through Each Creature And Deciphers Which Is In The Nearest Vicinity
	foreach (GameObject item in creatures)
	{
	
	bool    render   = item.GetComponent <Renderer> ().isVisible;
	
	// ----------  ----------    ----------   ---------- //
	if (render == true)
	{
	
	float distance = Vector3.Distance (camera.transform.position, item.transform.position);
	
	// ----------  ----------    ----------   ---------- //
	if (distance <= vicinity)
	{
	creature = item;
	vicinity = distance;
	}
	
	}
	}
	
	// ----------  ----------    ----------   ---------- //
	// Returns The Closest And Most Visible Creature
	return creature;
	}

	
	
}

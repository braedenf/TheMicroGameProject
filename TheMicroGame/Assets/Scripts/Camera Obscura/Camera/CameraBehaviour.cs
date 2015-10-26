using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// Manages The Over-Arching Organization And Attributes Of The Specified Audience Behaviour Relating To The Camera
public class CameraBehaviour : MonoBehaviour 
{
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All  Public Attributes That'll Be Run On Within The "Camera Obscura" Class
	public Canvas          canvas;
	public Canvas          tutorial;
	public RectTransform   display;
	// ----------  ----------    ----------   ---------- //
	public Camera          vision;
	// ----------  ----------    ----------   ---------- //
	public bool            raycast;

	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All  Private Attributes That'll Be Run On Within The "Camera Obscura" Class
	private CameraObscura camera; 
	// ----------  ----------    ----------   ---------- //
	private int counter;
	// ----------  ----------    ----------   ---------- //
	private List <Sprite> photographic = new List <Sprite> (1); 
	
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All Attributes And Instances That'll Be Run On Awake
	void Awake () 
	{
	
	// ----------  ----------    ----------   ---------- //
	// Sets A Fresh Cross-Dimensional Link To The "Camera Obscura" Class
	camera = new CameraObscura ();
	
	// ----------  ----------    ----------   ---------- //
	// References Whether The Necessiary Attributes Have Been Selected 
	if (canvas == null)
	print ("apply the camera interface here");
	if (display == null)
	print ("apply the photograph prefabrication here");
	
	}
	
	
	
	//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Progressively Publishes A Photograph Whilst Remaining Responsive To The Audiences Will
	void Update ()
	{
	
	// ----------  ----------    ----------   ---------- //
	// - Publishes A Photograph And Attaches It To The 'CameraObscura' Discoverability List
	// - Converts To A Sprite File (To Make It Useable Within The Audience Interface)
	// - Attaches A Visual Component To The Audience Interface With The Incorporated Sprite
    if (Input.GetMouseButtonDown (0)  )
	StartCoroutine ("Photography");
    
    }
    
    
    
    //  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// - Publishes A Photograph And Attaches It To The 'CameraObscura' Discoverability List
	// - Converts To A Sprite File (To Make It Useable Within The Audience Interface)
	// - Attaches A Visual Component To The Audience Interface With The Incorporated Sprite
	IEnumerator Photography () 
	{
    
		// ----------  ----------    ----------   ---------- //
		// Waits Until The Frame Has Been Processed Before Progressing The Photography 
		yield return new WaitForEndOfFrame();
    
        // ----------  ----------    ----------   ---------- //
		// Attaches A Fresh Class To The Static "Photographic" List
		GameDirectory.photographic.Add (new GameDirectory.Photography ());
		
		// ----------  ----------    ----------   ---------- //
		// Defines The Creature(s) That'll Be Captured Within The Photograph
		// Defines Whether The Creature Will Be Selected Through 'Visibility' Or 'Raycast'
		GameObject creature;
		// ----------  ----------    ----------   ---------- //
		if (raycast == false) 
		creature = CreatureManagement.visiblity (vision);
		else
		creature = this.gameObject.GetComponent <RaycastBehaviour> ().creature;
		
		
    	
		// ----------  ----------    ----------   ---------- //
		// Captures A Screenshot From The Active Camera 
		// Converts To A Sprite File (To Make It Useable Within The Audience Interface)
		camera.screenshot           = camera.discoverablity.Count;
		// ----------  ----------    ----------   ---------- //]
		int             item        = (int) (camera.discoverablity.Count - 1.00f);
		Sprite        sprite        = SpriteDesigner.conversion ( camera.discoverablity [item] );
		// ----------  ----------    ----------   ---------- //
		photographic.Add  (sprite);
		// ----------  ----------    ----------   ---------- //
		Sprite texture              = photographic [ (int) (photographic.Count - 1.00f) ];
		
		
		// ----------  ----------    ----------   ---------- //
		// Due To The Step-By-Step Shenangins - This Process May Become A Little Finnicky,
		// So Consistent Care Should Be Retained When Handelling This Code
		// Attaches The Visual Component To A Staticallly Available List Function
	    var representation     = Instantiate (display);
		var distinction        = representation.transform.GetChild (1).GetChild (0);
		// ----------  ----------    ----------   ---------- //
		representation.transform.SetParent (canvas.transform, false);
		// ----------  ----------    ----------   ---------- //
        distinction.GetComponent <Image> ().sprite   =   photographic  [ (int) (photographic.Count - 1.00f) ];
		// ----------  ----------    ----------   ---------- //
        GameDirectory.photographic [counter].representation  = representation;
        
        
		// ----------  ----------    ----------   ---------- //
		// Calculates The Score That Should Be Attributed To The Selected Photograph
		// - Calculates The Visisble Percentage Of The Creature Mesh Vertices
		if (creature != null)
		{
		
		// ----------  ----------    ----------   ---------- //
		float difference       = creature.GetComponent <MeshFilter> ().mesh.vertices.Length;
		List <Vector3> vertice = camera.visibility (creature, vision);
		
		// ----------  ----------    ----------   ---------- //
		// Calculates The Remaining Visiblity Of The Mesh Within The Active Viewport
		vertice                = camera.raycast (vertice, vision, creature);
		
		// ----------  ----------    ----------   ---------- //
		// Transfers The Calculated Photograph Percentage And Positions It Alongside The Photograph
		float count            = Mathematics.Percentage (vertice.Count, difference); 
		count                  = (int) count * 10;
		// ----------  ----------    ----------   ---------- //
        distinction            = representation.transform.GetChild (2);
		// ----------  ----------    ----------   ---------- //
        distinction.GetComponent <Text> ().text  = (count + "   " + "pts");
		// ----------  ----------    ----------   ---------- //
		GameDirectory.photographic [counter].scoreboard = (int) count;
		}


		// ----------  ----------    ----------   ---------- //
        // Defines The "Narrative" Audio Recording That'll Play In Response To The Photographic Discovery
        // - Accesses The Creature StateManager Script And Gathers All Necessiary Attributes
        if (creature != null)
        {
        StateManagement management = creature.GetComponent <StateManagement> ();
		// ----------  ----------    ----------   ---------- //
        GameDirectory.photographic [counter].creature     =  management.creature;
		GameDirectory.photographic [counter].state        =  management.state;
		GameDirectory.photographic [counter].interaction  =  management.interaction;
		// ----------  ----------    ----------   ---------- //
	    Narrative     narrative                           = NarrativeManagement.Depiction (management.creature, management.state, management.interaction);
	    // ----------  ----------    ----------   ---------- //
	    GameDirectory.photographic [counter].text         =  narrative.text;
		GameDirectory.photographic [counter].audio        =  narrative.audio;
		// ----------  ----------    ----------   ---------- //
		Mathematics.Logged (narrative.text);
		}
	
		
		// ----------  ----------    ----------   ---------- //
		// Progresssively Links The Counter With The Current Length Of The "GameDirectory.photographic" List
		counter ++;
		
		
		

}

}

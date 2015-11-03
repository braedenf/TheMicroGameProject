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
	public Canvas          tutorial;
	// ----------  ----------    ----------   ---------- //
	public Camera          vision;
	// ----------  ----------    ----------   ---------- //
	public bool            raycast;
	public bool            grayscale;
	public bool            borderline;
	// ----------  ----------    ----------   ---------- //
	[ Range (0, 10)    ] public float buffer;
	[ Range (0, 1)     ] public float grain;
	[ Range (0, 1)     ] public float shadow;
	[ Range (0, 1)     ] public float light;
	[ Range (1, 10000) ] public float tear;
	[ Range (0, 100)   ] public float border;
	// ----------  ----------    ----------   ---------- //
	public Texture texture;
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All  Private Attributes That'll Be Run On Within The "Camera Obscura" Class
	private CameraObscura camera; 
	// ----------  ----------    ----------   ---------- //
	private int counter;
	private int zero;
	// ----------  ----------    ----------   ---------- //
	private float time;
	// ----------  ----------    ----------   ---------- //
	public List <Sprite> photographic = new List <Sprite> (1); 
	
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All Attributes And Instances That'll Be Run On Awake
	void Awake () 
	{
	
	// ----------  ----------    ----------   ---------- //
	// Sets The Photograph Buffer For Awake
	time  = buffer;
	
	// ----------  ----------    ----------   ---------- //
	// Sets A Fresh Cross-Dimensional Link To The "Camera Obscura" Class
	camera = new CameraObscura ();
	
	// ----------  ----------    ----------   ---------- //
	// Defines The Fresh Render Texture Dimensions
	texture.width  = Screen.width;
	texture.height = Screen.height;
	
	
	}
	
	
	
	//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Progressively Publishes A Photograph Whilst Remaining Responsive To The Audiences Will
	void Update ()
	{
	
	// ----------  ----------    ----------   ---------- //
	// - Publishes A Photograph And Attaches It To The 'CameraObscura' Discoverability List
	// - Converts To A Sprite File (To Make It Useable Within The Audience Interface)
	// - Attaches A Visual Component To The Audience Interface With The Incorporated Sprite
	time        += Time.deltaTime;
	// ----------  ----------    ----------   ---------- //
	if (time    >= buffer)
    if (Input.GetAxis ("Capture") != zero )
	{
	StartCoroutine ("Photography");
	time         = zero;
	}
    
    }
    
    
    
    //  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// - Publishes A Photograph And Attaches It To The 'CameraObscura' Discoverability List
	// - Converts To A Sprite File (To Make It Useable Within The Audience Interface)
	// - Attaches A Visual Component To The Audience Interface With The Incorporated Sprite
	IEnumerator Photography () 
	{
    
		FMOD.Studio.EventInstance dialogue = FMOD_StudioSystem.instance.GetEvent ("event:/SoundFX/cameraSnap");
		dialogue.start ();
    
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
//		camera.screenshot           = camera.discoverablity.Count;
        camera.screenshot (texture);

		
		// ----------  ----------    ----------   ---------- //
		// Converts The Screenshot Into A Grayscale Capture
		int             item         = (int) (camera.discoverablity.Count - 1.00f);	
		// ----------  ----------    ----------   ---------- //
		if (grayscale               == true)
		camera.discoverablity [item] = camera.Grayscale  (camera.discoverablity [item], grain, tear, shadow, light);
		if (borderline               == true)
		camera.discoverablity [item] = camera.Borderline (camera.discoverablity [item], border);
		
		// ----------  ----------    ----------   ---------- //
		// Converts To A Sprite File (To Make It Useable Within The Audience Interface)
		Sprite        sprite        = SpriteDesigner.conversion ( camera.discoverablity [item] );
		// ----------  ----------    ----------   ---------- //
		photographic.Add                             (sprite);
		// ----------  ----------    ----------   ---------- //
		GameDirectory.photographic [counter].sprite  = sprite;
		

			
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
//			Debug.Log  (vertice.Count);
		// ----------  ----------    ----------   ---------- //
		// Transfers The Calculated Photograph Percentage And Positions It Alongside The Photograph
		float count            = Mathematics.Percentage (vertice.Count, difference); 
		count                  = (int) count * 10;
		// ----------  ----------    ----------   ---------- //
		GameDirectory.photographic [counter].scoreboard = (int) count;
		}


//        Debug.Log (GameDirectory.photographic [counter].scoreboard);
		// ----------  ----------    ----------   ---------- //
		// Figures Out Whether The Creature Is Visible
		if (GameDirectory.photographic [counter].scoreboard <= 250.00f)
		creature  = null;

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
	    Narrative     narrative                           = NarrativeManagement.Depiction (management.creature, management.state, management.interaction, GameDirectory.photographic [counter].scoreboard);
	    // ----------  ----------    ----------   ---------- //
	    if (narrative == null)
	    Debug.Log ("null Exception");
	    // ----------  ----------    ----------   ---------- //
	    if (narrative != null)
	    GameDirectory.photographic [counter].transistion  =  narrative.transistion;
	    GameDirectory.photographic [counter].text         =  narrative.text;
	    
	    
	    if (narrative.destructable)
		NarrativeManagement.narrative.Remove (narrative);
		}
		// ----------  ----------    ----------   ---------- //
		else
		{
		Narrative     narrative                           = NarrativeManagement.Depiction (null, null, null, 0.00f);
	    // ----------  ----------    ----------   ---------- //
	    if (narrative != null)
	    GameDirectory.photographic [counter].transistion  =  narrative.transistion;
	    GameDirectory.photographic [counter].text         =  narrative.text;
	    
		}
        
       
		// ----------  ----------    ----------   ---------- //
		// Progresssively Links The Counter With The Current Length Of The "GameDirectory.photographic" List
		counter ++;
		
}

}

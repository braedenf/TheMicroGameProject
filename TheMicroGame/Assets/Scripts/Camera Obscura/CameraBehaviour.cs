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
	public RectTransform display;
	// ----------  ----------    ----------   ---------- //
	public Camera         vision;
	public GameObject creature;
	// ----------  ----------    ----------   ---------- //
    public string  button = "space";
	// ----------  ----------    ----------   ---------- //
	public List <RectTransform> visualization = new List <RectTransform> (1); 
	
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
    if (Input.GetKeyDown (button) )
    {
    
		// ----------  ----------    ----------   ---------- //
		// Attaches A Fresh Class To The Static "Photographic" List
		GameDirectory.photographic.Add (new GameDirectory.Photography ());
    	
    	
		// ----------  ----------    ----------   ---------- //
		// Captures A Screenshot From The Active Camera 
		// Converts To A Sprite File (To Make It Useable Within The Audience Interface)
		camera.screenshot      = camera.discoverablity.Count;
		// ----------  ----------    ----------   ---------- //]
		int             item            = (int) (camera.discoverablity.Count - 1.00f);
		Sprite        sprite          = SpriteDesigner.conversion ( camera.discoverablity [item] );
		// ----------  ----------    ----------   ---------- //
		photographic.Add  (sprite);
		// ----------  ----------    ----------   ---------- //
		Sprite texture              = photographic [ (int) (photographic.Count - 1.00f) ];
		
		
		// ----------  ----------    ----------   ---------- //
		// Due To The Step-By-Step Shenangins - This Process May Become A Little Finnicky,
		// So Consistent Care Should Be Retained When Handelling This Code
		// Attaches The Visual Component To A Staticallly Available List Function
	    var representation = Instantiate (display);
		var distinction        = representation.transform.GetChild (1).GetChild (0);
		// ----------  ----------    ----------   ---------- //
		representation.transform.SetParent (canvas.transform, false);
		// ----------  ----------    ----------   ---------- //
        distinction.GetComponent <Image> ().sprite   =   photographic  [ (int) (photographic.Count - 1.00f) ];
		// ----------  ----------    ----------   ---------- //
        GameDirectory.photographic [counter].representation  = representation;
        
        
		// ----------  ----------    ----------   ---------- //
		// Calculates The Score That Should Be Attributed To The Selected Photograph
		// - Calculates The Visisble Percentage Of The Mesh Vertices
		float difference   = creature.GetComponent <MeshFilter> ().mesh.vertexCount;
		float count          = camera.scoreboard (creature, vision);
		count                  = Mathematics.Percentage (count, difference); 
		count                  = (int) count * 10;
		// ----------  ----------    ----------   ---------- //
		// Mathematics.Logged ("Percentage Captured", count);
		// ----------  ----------    ----------   ---------- //
        distinction            = representation.transform.GetChild (2);
		// ----------  ----------    ----------   ---------- //
        distinction.GetComponent <Text> ().text  = ("Score" + "  " + count);
		// ----------  ----------    ----------   ---------- //
		GameDirectory.photographic [counter].scoreboard = (int) count;
		
		
		// ----------  ----------    ----------   ---------- //
		// Progresssively Links The Counter With The Current Length Of The "GameDirectory.photographic" List
		counter ++;
        
      }

}

}

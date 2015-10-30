using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      //
// Transistions The "Gallery" Hinterland
public class Hinterland : MonoBehaviour 
{

	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All Public Attributes That'll Be Manipulated By The Game Designer
	[ Range (0, 10) ] public float      momentum;
	[ Range (0, 10) ] public float      buffer;
	// ----------  ----------    ----------   ---------- //
	public AnimationCurve              acceleration;
	// ----------  ----------    ----------   ---------- //
    public GameObject                  illustration;
    


	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All Private Attributes That'll Be Manipulated By The System
	private RectTransform  dimension;
	// ----------  ----------    ----------   ---------- //
	private GameManagement management;
	// ----------  ----------    ----------   ---------- //
	private Vector2        position;
	// ----------  ----------    ----------   ---------- //
	private float          time;
	private float          pause;
	// ----------  ----------    ----------   ---------- //
	private string         state;
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All Necessiary Attributes And Qualities On Enable
	void OnEnable () 
	{
	
	// ----------  ----------    ----------   ---------- //
	// Checks Whether 'Illustration' Is Attributed To A GameObject
	if (!illustration)
	Debug.Log ("You May Wish To Give The 'Hinterland' Code A Suitable GameObject");
	
	// ----------  ----------    ----------   ---------- //
	// Attributes A Suitable RectTransform To 'Dimension' - Plus Other Such Shenanagins
	dimension  = illustration.GetComponent <RectTransform> ();
	position   = dimension.sizeDelta;
	
	// ----------  ----------    ----------   ---------- //
	// Defines The Game Management Connection
	management = GameObject.FindGameObjectWithTag ("Management").GetComponent <GameManagement> ();
	
	// ----------  ----------    ----------   ---------- //
	// Sets The Basic Width Of The Suitable 'RectTransform"
	dimension.sizeDelta = new Vector2 (0.00f, dimension.sizeDelta.y);
	
	}
	
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All Attributes And Instances That'll Be Progressively Run Each Frame
	void Update () 
	{
    
	// ----------  ----------    ----------   ---------- //
	// Reverts The Time Attribute If The Game State Remains Different To The Animation State
	if (state != management.gameState.ToString ())
	{
	time       = 0.00f;
	pause      = 0.00f;
	}
	// ----------  ----------    ----------   ---------- //
	state      = management.gameState.ToString ();
    
    
	// ----------  ----------    ----------   ---------- //
    // Animates The Illustration Into Existence If The Over-Arching Game State Equals "Gallery"
    if (management.gameState == GameManagement.GameState.gallery)
    {
    
    // ----------  ----------    ----------   ---------- //
    // (Occasionally) Buffers The Animation
    if (pause < buffer)
    pause                       += Time.deltaTime;
    
    // ----------  ----------    ----------   ---------- //
    // Animates Over A Certain Interval Of Time
    if (pause                   >= buffer)
    {
    if (dimension.sizeDelta.x   != position.x)
    {
    time                        += Time.deltaTime * momentum;
    float transition             = Mathf.Lerp (0.00f, position.x, acceleration.Evaluate (time) );
    dimension.sizeDelta          = new Vector2 (transition, dimension.sizeDelta.y);
    }
    }
    
    }
    
    
    // ----------  ----------    ----------   ---------- //
    // Animates The Illustration Out Of Existence If The Over-Arching Game State Equals "Discovery"
    if (management.gameState == GameManagement.GameState.discovery)
    {
    
    // ----------  ----------    ----------   ---------- //
    // Animates Over A Certain Interval Of Time
    if (dimension.sizeDelta.x   != 0.00f)
    {
    time                        += Time.deltaTime * momentum;
	float transition             = Mathf.Lerp (position.x, 0.00f, acceleration.Evaluate (time) );
    dimension.sizeDelta          = new Vector2 (transition, dimension.sizeDelta.y);
    }
    
     
    }
	
	}
}

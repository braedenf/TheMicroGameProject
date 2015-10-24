 using UnityEngine;
using System.Collections;
using System.Collections.Generic;


// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// Designs A 2Dimensional Grid Of Nodes
public class GridDirectory : MonoBehaviour 
{

	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All Public Attributes That'll Be Acccessiable For The Game Designer
	public Transform  creature;
	// ----------   ----------    ----------   ---------- //
	public LayerMask  obstacle;
	public Vector2    dimension;
	// ----------   ----------    ----------   ---------- //
	public float      radius;
	public float      distance;
	// ----------   ----------    ----------   ---------- //
	public List <Node> path;
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines All Private Attributes That'll Be Acccessiable For The Game Designer
	Node [,]       grid;
	// ----------   ----------    ----------   ---------- //
	private float  diameter;
	// ----------   ----------    ----------   ---------- //
	private int    dimensionX, dimensionY;
	private int    zero;
	
	//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------  // 
	// Defines All Qualities Deemed Necessiary On Awake
	// - Defines The Dimensions Of The Grid Interface
	void Awake ()
	{
		// ----------   ----------    ----------   ---------- //
		// Calculates The Grid Diameter
		diameter   = radius * 2.00f;
		
		// ----------   ----------    ----------   ---------- //
		// Calculates The Necessiary Quantity Of Nodes Within The Grid
		dimensionX = (int) (dimension.x / diameter);
		dimensionY = (int) (dimension.y / diameter);
		
		// ----------   ----------    ----------   ---------- //
		// Selectively Calls All Necessiary Functions
		GridDesigner ();
	
	}
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines A Fresh Grid System On Awake
	void GridDesigner ()
	{
		
	// ----------   ----------    ----------   ---------- //
	// Defines All Necessiary Embedded Attributes
	Vector3 corner = transform.position - (Vector3.right * dimension.x / 2.00f) - (Vector3.forward * dimension.y / 2.00f);
	
	// ----------   ----------    ----------   ---------- //
	// Defines A Fresh Grid System
	grid = new Node [dimensionX,dimensionY];
		
		
	// ----------   ----------    ----------   ---------- //
	// Progressively Designs A Fresh Grid System Along The Specified Axis
	for (int horizontal = zero; horizontal < dimensionX; horizontal ++)
	{
	// ----------   ----------    ----------   ---------- //
	for (int vertical  = zero; vertical < dimensionY; vertical ++)
	{
		
	Vector3 width    = Vector3.right   * (horizontal * diameter + radius);
	Vector3 height   = Vector3.forward * (vertical   * diameter + radius);
	Vector3 point    = corner + width  + height;
	
	// ----------   ----------    ----------   ---------- //
	// Checks Whether The Instantiated Node Will Be Clear To Walk On
	bool    walkable = !(Physics.CheckSphere (point, radius, obstacle) );
	
    // ----------   ----------    ----------   ---------- //
	// Instantiates A Fresh Node
	grid [horizontal, vertical] = new Node (walkable, point, horizontal, vertical);
	}	
	}
	
	}
	
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Draws Visual Representations Of Certain Attribues
	// - Draws A Visual Representation Of The Grid Boundaries
	void OnDrawGizmos ()
	{
	
	// ----------   ----------    ----------   ---------- //
	// Calculates A Visual Representation Of The Grid Boundaries
	Vector3 size   = new Vector3 (dimension.x, transform.position.y, dimension.y);
	Gizmos.DrawWireCube (transform.position, size);
	
	// ----------   ----------    ----------   ---------- //
	// Calculates A Visual Representation Of The Grid 
	// Calculates The Creature Position
	if (grid != null)
	{
	
	// ----------   ----------    ----------   ---------- //
	foreach (Node node in grid)
	{
	if (node.walkable == true)
	Gizmos.color      = Color.white;
	else
	Gizmos.color      = Color.red;
	// ----------   ----------    ----------   ---------- //
	if (path != null && path.Contains (node) )
	Gizmos.color      = Color.black;
	// ----------   ----------    ----------   ---------- //
	Gizmos.DrawCube (node.position, Vector3.one * (diameter - distance) ); 
	
	}
	}
	
	}
	
	
	
	 // -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Defines The Grid Position Of Certain Wandering Creatures 
	// - Calculates The Positional Percentage Of The Selected Creature
	public Node Position (Vector3 position) 
	{
	
	float horizontal = (position.x + dimension.x / 2.00f) / dimension .x;
	float vertical   = (position.z + dimension.y / 2.00f) / dimension.y;
	// ----------   ----------    ----------   ---------- //
	horizontal       = Mathematics.limitation (horizontal, zero, 1.00f);
	vertical         = Mathematics.limitation (vertical,   zero, 1.00f);
	// ----------   ----------    ----------   ---------- //
	int width        = (int) ( (dimensionX - 1) * horizontal);
	int height       = (int) ( (dimensionY - 1) * vertical);
	
	// ----------   ----------    ----------   ---------- //
	return  grid [width, height];
	
	}
	
	
	// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Gets The All Of The Nearest Neighbours Around The Selected Node
	// - Checks For Adjacent Nodes
	public List <Node> Neighbour (Node node)
	{
	
	List <Node> neighbours = new List <Node> ();
	
	// ----------   ----------    ----------   ---------- //
	// Progressively Runs Through All Possible Neighbours To See Whether They're Available
	for (int horizontal = -1; horizontal <= 1; horizontal ++)
	{
	for (int vertical = -1;   vertical   <= 1; vertical ++)
	{
	// ----------   ----------    ----------   ---------- //
	if (horizontal == zero && vertical == zero)
	continue;
	
	// ----------   ----------    ----------   ---------- //
	int possibleX   = node.horizontal + horizontal;
	int possibleY   = node.vertical   + vertical;
	// ----------   ----------    ----------   ---------- //
	if (possibleX >= zero && possibleX < dimensionX && possibleY >= zero && possibleY < dimensionY)
	neighbours.Add (grid [possibleX, possibleY] );
	
	}
	}
	
	// ----------   ----------    ----------   ---------- //
	// Returns The List Of Neighbours
	return neighbours;  
	
	}
	
	
	
}
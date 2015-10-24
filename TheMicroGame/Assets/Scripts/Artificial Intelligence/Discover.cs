using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
public class Discover : MonoBehaviour 
{

// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// Defines All Public Attributes That'll Be Acccessiable For The Game Designer
public GridDirectory grid;
// ----------   ----------    ----------   ---------- //
public Transform     seeker, target;

// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// Defines All Private Attributes That'll Be Acccessiable For The System
private int zero;

//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------  // 
// Defines All Qualities Deemed Necessiary On Awake
void Awake ()
{

// ----------   ----------    ----------   ---------- //
// Defines All Necessiary Attributes
if (grid == null)
grid      = this.gameObject.GetComponent <GridDirectory> ();

}


//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------  // 
// Defines All Qualities Deemed Necessiary On Update
void Update ()
{

Wander (seeker.position, target.position);

}

// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// Stores Information On The Creature Start And Target Position
void Wander (Vector3 position, Vector3 target)
{

// ----------   ----------    ----------   ---------- //
// Defines The Necessiary Positions Of The Creature
Node start  = grid.Position (position);
Node finish = grid.Position (target);
// ----------   ----------    ----------   ---------- //
List <Node>    available   = new List <Node> ();
HashSet <Node> unavailable = new HashSet <Node> ();

// ----------   ----------    ----------   ---------- //
// Attaches The Start Node To The 'Available' List 
available.Add (start);


// ----------   ----------    ----------   ---------- //
// Iterates Through The Node List Whilst 'Available' Nodes Still Remain
while (available.Count > zero)
{

Node current = available [zero];
// ----------   ----------    ----------   ---------- //
// Progressively Checks The Distance Costs Between Each 'Available' Code
for (int interger = 1; interger < available.Count; interger ++)
{
if (available [interger].Cost < current.Cost)
current = available [interger];
// ----------   ----------    ----------   ---------- //
if (available [interger].Cost == current.Cost && available [interger].hCost < current.hCost)
current = available [interger];
}

// ----------   ----------    ----------   ---------- //
// Removes The Current Node
available.Remove (current);
unavailable.Add  (current);

// ----------   ----------    ----------   ---------- //
// Deciphers Whether The Current Node Equals The Target Positon
if (current == finish)
{
Retrace (start, finish);
return;
}

// ----------   ----------    ----------   ---------- //
// Checks The Adjacent Neighbours Of The Current Node To See Whether Any May Possess A Desirable Position
foreach (Node neighbour in grid.Neighbour (current) )
{

// ----------   ----------    ----------   ---------- //
// Returns If The Neighbour Isn't Accessable
if (!neighbour.walkable || unavailable.Contains (neighbour) ) 
continue;

// ----------   ----------    ----------   ---------- //
// Deciphers The Distance Between The Current And Neighbour Nodes
// Calculates The Neighbour Cost 
// Attaches It To The 'Available' List If Deemed Applicable
int movement = current.gCost + Distance (current, neighbour); 
// ----------   ----------    ----------   ---------- //
if (movement < neighbour.gCost || !available.Contains (neighbour) ) 
{ 
neighbour.gCost  = movement;
neighbour.hCost  = Distance  (neighbour, finish);
neighbour.parent = current;

 if (!available.Contains (neighbour) )
 available.Add (neighbour);

}

}


}

}



// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// Retraces The Path Taken From The Start Position To The Target Position
void Retrace (Node start, Node target)
{

List <Node> path = new List <Node> ();
// ----------   ----------    ----------   ---------- //
Node current     = target;

// ----------   ----------    ----------   ---------- //
while (current  != start)
{
path.Add (current);
current          = current.parent;
}
  
// ----------   ----------    ----------   ---------- //
path.Reverse ();
  
 grid.path = path;
  
}

// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// Calculates The Distance Between The Selected Code And The Target
int Distance (Node node, Node target)
{
int distanceX = Mathf.Abs (node.horizontal - target.horizontal);
int distanceY = Mathf.Abs (node.vertical   - target.vertical);

// ----------   ----------    ----------   ---------- //
if (distanceX > distanceY)
return (14 * distanceY) + (10 * (distanceX - distanceY) );
else
return (14 * distanceX) + (10 * (distanceY - distanceX) );

}


}

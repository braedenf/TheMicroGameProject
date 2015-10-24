using UnityEngine;
using System.Collections;

// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// Encompasses All Necessiary Attributes Linked With The Grid System
// - Documents Whether The Selected Node Is Accessable 
// - Documents The Node World Position
public class Node  
{

// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// Defines All Public Attributes That'll Be Acccessiable For The Game Designer
public bool     walkable; 
public Vector3  position;
// ----------   ----------    ----------   ---------- //
public int      horizontal;
public int      vertical;
public int      gCost; 
public int      hCost;
// ----------   ----------    ----------   ---------- //
public Node     parent;


// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// A Storage Class For The Following 'Node' Information
public Node (bool _walkable, Vector3 _position, int _horizontal, int _vertical )
{
walkable   = _walkable;
position   = _position;
horizontal = _horizontal;
vertical   = _vertical;
}

// -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// Calculates The Cost Of Each Node
public int Cost 
{
// ----------   ----------    ----------   ---------- //
get
{ return gCost + hCost; }

}
	
}

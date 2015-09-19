using UnityEngine;
using System.Collections;


//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// The "Scriptable Object" Script 
// - Beneficial For Any Necessiary Additions That May Arise

[System.Serializable]
public class Narrative : ScriptableObject
{

public string    creature; 
public string    state; 
public string    interaction;
// ----------  ----------    ----------   ---------- //
[Multiline] public string    text;
// ----------  ----------    ----------   ---------- //
public AudioClip audio;

}

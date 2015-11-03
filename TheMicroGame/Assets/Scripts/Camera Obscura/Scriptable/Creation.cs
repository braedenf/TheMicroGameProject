using UnityEngine;
using System.Collections;
using UnityEditor;

//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// Publishes A Built Version Of The "Narrative" Scriptable Object
// To Be Utilized For The Narrative Interface
public class Creation
{

[MenuItem ("Assets/Create/Narrative") ]

//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// Publishes A Built Version Of The "Narrative" Scriptable Object
public static void Create ()
{

Narrative asset = ScriptableObject.CreateInstance <Narrative> ();
// ----------  ----------    ----------   ---------- //
AssetDatabase.CreateAsset (asset, "Assets/Narrative.asset");
AssetDatabase.SaveAssets ();
// ----------  ----------    ----------   ---------- //
EditorUtility.FocusProjectWindow ();
// ----------  ----------    ----------   ---------- //

Selection.activeObject = asset;

}
	
}

﻿using UnityEngine;
using System.Collections;
using System.Text;


//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
//  Possesses All Of The Awkward Yet Slightly Appreciated Noggins And Code
// - Logged | An Attribute Dedicated To Making Prettier "Debug.Log" Functions
public class Mathematics
 {


//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// Allows For The Ability To Compile And Publish A More Aesthetically Pleasing "Debug.Log"
public static string Logged (params object [] data)
{

StringBuilder stringBuilder = new StringBuilder ();
// ----------  ----------    ----------   ---------- //
for (int item  = 0; item < data.Length; item++)
{
stringBuilder.Append(data[item].ToString());
stringBuilder.Append("   ");
}

// ----------  ----------    ----------   ---------- //
string text = stringBuilder.ToString();
Debug.Log( text );
return text;
}




}

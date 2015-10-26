using UnityEngine;
using System.Collections;
using System.Text;
using System;

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



//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// Calculates The Statistical  Difference Between Two Differing Numbers
public static float Percentage (float count, float difference)
{
float percentage;
// ----------  ----------    ----------   ---------- //
percentage = count / difference;
percentage = percentage * 100.00f;
// ----------  ----------    ----------   ---------- //
return percentage;
}



//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
//  Buffers The Selected Attribute Between A Maximum And Minimum Attribute
public static float limitation (float value, float minimum, float maximum)
{

if (value <= minimum)
value = minimum;
// ----------  ----------    ----------   ---------- //
if (value >= maximum) 
value = maximum;
	
return value;
}


//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
// Calculates The Appropriate Framerate Of The Specified Animation Transistion,
public static Vector2 Framerate (int framerate, Vector2 animation)
{

	// ----------  ----------    ----------   ---------- //
	// Converts The Animation Time Into An Applicable Framerate
	animation.x = (animation.x / framerate);
	animation.x = (float) Math.Round (animation.x, 1);
	// ----------  ----------    ----------   ---------- //
	animation.y = (animation.y / framerate);
	animation.y = (float) Math.Round (animation.y, 1);
    // ----------  ----------    ----------   ---------- //
    return animation;
}



}

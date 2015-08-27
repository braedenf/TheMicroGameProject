using UnityEngine;
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



// ----------  ----------    ----------   ---------- //
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



}

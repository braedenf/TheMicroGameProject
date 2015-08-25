using UnityEngine;
using System.Collections;


//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
//  Converts Traditional 'Texture2D' files Into Sprite Files
public class SpriteDesigner
{

	//  -----------------     ----------------     ----------------     ----------------    ----------------     ----------------      // 
	// Converts The Selected 'Texture2D' Into A Functionable Sprite File
	public static Sprite conversion (Texture2D texture)
	{

	 Sprite sprite = Sprite.Create (texture, new Rect (0, 0, texture.width, texture.height), new Vector2 (0.5f , 0.5f), 100);
		
	 return sprite;
	}
}

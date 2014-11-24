using UnityEngine;
using System.Collections;

public class JumpBar : MonoBehaviour {

	float progress  = 0; 
	Vector2 pos ;
	Vector2 size ;
	 Texture2D progressBarEmpty ;
	 Texture2D progressBarFull ;


	void Start()
	{

		 pos = new Vector2(20,40);
		 size = new Vector2(60,20);
	}
	void  OnGUI() {
		GUI.DrawTexture(new Rect(pos.x, pos.y, size.x, size.y), progressBarEmpty);
		GUI.DrawTexture(new Rect(pos.x, pos.y, size.x * Mathf.Clamp01(progress), size.y), progressBarFull); 

		progressBarEmpty = new Texture2D(128,128,TextureFormat.ARGB32,false);
		progressBarFull = new Texture2D(128,128,TextureFormat.ARGB32,false);
	
		SetTextureColor(Color.red,progressBarEmpty);

		SetTextureColor(Color.white,progressBarFull);

	}



	void SetTextureColor(Color color,Texture2D texture)
	{

		var fillColorArray = texture.GetPixels();
		
		for(var i = 0; i < fillColorArray.Length; ++i)
		{
			fillColorArray[i] = color;
		}
		
		texture.SetPixels(fillColorArray);
		
		texture.Apply();


	}
	
	void Update() 
	{
		progress = Time.time * 0.05f; 
	}
}

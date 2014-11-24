using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


	public float Yforce;
	public float Xforce;

	float initTime;
	float touchTime;

	float constantInit = 40 ;

	bool jump;

	bool isHoldDown ;



	float progress  = 0; 
	Vector2 pos ;
	Vector2 size ;
	Texture2D progressBarEmpty ;
	Texture2D progressBarFull ;


	void Start () {
	
		pos = new Vector2(20,40);
		size = new Vector2(60,20);

		progressBarEmpty = new Texture2D(128,128,TextureFormat.ARGB32,false);
		progressBarFull = new Texture2D(128,128,TextureFormat.ARGB32,false);

		SetTextureColor(Color.red,progressBarEmpty);
		
		SetTextureColor(Color.white,progressBarFull);

		isHoldDown = false;

	
	}
	
	// Update is called once per frame
	void Update () {

		if(isHoldDown)
		{
			progress = (Time.time-initTime); 

		}
	
		if (Input.GetMouseButtonDown (0)) 
		{
			initTime = Time.time;

			isHoldDown = true;

		}

		if(Input.GetMouseButtonUp(0))
		{
			touchTime = (Time.time-initTime)*constantInit;


			jump = true;

			isHoldDown = false;
			GetComponent<AudioSource>().Play();

			GetComponent<Animator>().SetBool("anim_jump",true);
		}

	
	}



	void FixedUpdate()
	{
		if(jump)
		{
			transform.rigidbody2D.AddForce(new Vector2(touchTime*Xforce,Yforce*touchTime));

			jump = false;
		}


	}

	void  OnGUI() {
		GUI.DrawTexture(new Rect(pos.x, pos.y, size.x, size.y), progressBarEmpty);
		GUI.DrawTexture(new Rect(pos.x, pos.y, size.x * Mathf.Clamp01(progress), size.y), progressBarFull); 
		
	
		

		
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
}

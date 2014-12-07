using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


	public float Yforce;
	public float Xforce;

	float initTime;
	float touchTime;



	bool jump;

	bool isHoldDown ;



	public float progress  = 0; 
	Vector2 pos ;
	Vector2 size ;
	Texture2D progressBarEmpty ;
	Texture2D progressBarFull ;

	static public float touchTimeScale = 2;




	float jumpBarOffset ;

	float jumpBarWidthOffset;

	float jumpBarWidth;

	float jumpBarHeight;


	void Start () {
	
		//pos = new Vector2(Screen.width*0.8f,0);
		jumpBarWidth = Screen.width*0.11f;
		jumpBarHeight = Screen.height*0.04f;
		size = new Vector2(jumpBarWidth,jumpBarHeight);

		progressBarEmpty = new Texture2D(128,128,TextureFormat.ARGB32,false);
		progressBarFull = new Texture2D(128,128,TextureFormat.ARGB32,false);

		jumpBarOffset = Screen.height*0.15f;
		jumpBarWidthOffset = Screen.width*0.05f;
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

			Debug.Log ("Real touch time: "+(Time.time-initTime));
			touchTime = (Time.time-initTime)*touchTimeScale;


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

			Debug.Log("Touch Time: "+touchTime);
			Debug.Log("Force: "+touchTime*Xforce+" "+Yforce*touchTime);
			transform.rigidbody2D.AddForce(new Vector2(touchTime*Xforce,(400*touchTime+480)/1.4f));

			jump = false;
		}


	}

	void  OnGUI() {


		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		GUI.DrawTexture(new Rect(pos.x-jumpBarWidthOffset, Screen.height-pos.y - jumpBarOffset, size.x, size.y), progressBarEmpty);
		GUI.DrawTexture(new Rect(pos.x-jumpBarWidthOffset, Screen.height- pos.y- jumpBarOffset, size.x * Mathf.Clamp01(progress), size.y), progressBarFull); 
		
	
		

		
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

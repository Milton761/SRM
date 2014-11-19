using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


	public float Yforce;
	public float Xforce;

	float initTime;
	float touchTime;

	float constantInit = 40 ;

	bool jump;



	float pixelToLiveRatio;
	int maxWidth = 250;
	// Use this for initialization
	void Start () {
	

		pixelToLiveRatio = maxWidth/touchTime;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetMouseButtonDown (0)) 
		{
			initTime = Time.time;
		}

		if(Input.GetMouseButtonUp(0))
		{
			touchTime = (Time.time-initTime)*constantInit;
			jump = true;
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
}

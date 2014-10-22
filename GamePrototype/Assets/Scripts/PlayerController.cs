using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour {

	public float speed = 0.1F;
	public float radius;
	float rotationspeed = (2 * Mathf.PI) / 5;
	float angle ;
	
	float initialForce = 3;
	public float attractionForce ;
	public float perimeterForce ;
	bool clickPressed = false;
	
	float prevent_holding_circle_radius = 1.1f;
	
	int perpendicularOrientation;

	public static bool isMoving;
	
	//Vector3 last_pos;
	
	// Use this for initialization
	void Start () 
	{
	
		isMoving = false;
		//transform.rigidbody2D.AddForce(new Vector2(0,initialForce));
		//transform.rigidbody2D.velocity = new Vector2(0,initialForce);
	
	}
	

	void Update()
	{


		if(Input.GetMouseButtonDown(0))
		{
			//Prevent click holding
			if(clickPressed==false)
			{
				Debug.Log("Click Pressed");
				clickPressed = true;
				angle = GetAngleFromPosition();

				if(isMoving==false)
				{
					isMoving = true;
					foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Obstacle"))
					{
						obj.GetComponent<SpawnScript>().StartSpawning();
					}
					TimerScore.StartTimer();
				}

				perpendicularOrientation = GetPerpendicularVectorOrientation();
				Debug.LogWarning("New Angle: "+angle);
			}
				
			
		}
		if(Input.GetMouseButtonUp(0))
		{
			Debug.Log("Click Released");
			clickPressed = false;
		}


		//if (clickPressed)
			//			HandleMovement ();
		
		
		
	}
	
	void FixedUpdate()
	{
		if(clickPressed)
		{
			
			
			
			var dist = Mathf.Abs(transform.position.z - Camera.main.transform.position.z);
			var mousevec = Input.mousePosition;
			mousevec.z = dist;
			
			
			//Get click position
			var mousePos = Camera.main.ScreenToWorldPoint(mousevec);
			var distvector = mousePos - transform.position ;
			
			//Distance from player to Click position
			float distance = Vector3.Magnitude(distvector);
			
			distvector.Normalize();
			if(distance>prevent_holding_circle_radius)
			{
			
			
				
				
				var perpendicular = new Vector2(-distvector.y,distvector.x) * perpendicularOrientation;
				
				//Inside Circle Radius
				
				Vector2 velocity = new Vector2(attractionForce*distvector.x,attractionForce*distvector.y);
				
				//	if(distance<=circle_radius)
				velocity+= perpendicular*perimeterForce ;
				

				transform.rigidbody2D.velocity= velocity;
				
				
				//	transform.rotation.SetLookRotation(new Vector3(velocity.x,velocity.y,0));
				float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg-90;
				
				
				transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.AngleAxis(angle, Vector3.forward),Time.time*rotationspeed);
				//transform.rigidbody2D.velocity= new Vector2(attractionForce*distvector.x,attractionForce*distvector.y);
				//transform.rigidbody2D.AddForce(perpendicular*perimeterForce);
				//transform.rigidbody2D.AddForce(new Vector2(attractionForce*distvector.x,attractionForce*distvector.y));
				
				
			}
			
		
			
		}
	
	}


	int GetPerpendicularVectorOrientation()
	{
	
		var dist = Mathf.Abs(transform.position.z - Camera.main.transform.position.z);
		var mousevec = Input.mousePosition;
		mousevec.z = dist;
		
		
		//Get click position
		var mousePos = Camera.main.ScreenToWorldPoint(mousevec);
		var distvector = mousePos - transform.position ;
		
		if(distvector.x<=0)
		{
			return -1;
			
		}
		
		
		return 1;
	}
	float GetAngleFromPosition()
	{
	
		float x = transform.position.x;
		var dist = Mathf.Abs(transform.position.z - Camera.main.transform.position.z);
		var mousevec = Input.mousePosition;
		mousevec.z = dist;
		
		
		
		var mousePos = Camera.main.ScreenToWorldPoint(mousevec);
		var distvector = mousePos - transform.position ;
		
		var r = Vector3.Magnitude(distvector) ;


		if (r== 0)
						return 0;

		float val =  (x - mousePos.x) / r;
		Debug.LogWarning ("val: " + val+" "+x+" "+r);
		return Mathf.Acos (val);
	
	}
	void HandleMovement()
	{

		var dist = Mathf.Abs(transform.position.z - Camera.main.transform.position.z);
		var mousevec = Input.mousePosition;
		mousevec.z = dist;



		var mousePos = Camera.main.ScreenToWorldPoint(mousevec);
		var distvector = mousePos - transform.position ;
	
		radius = Vector3.Magnitude(distvector) ;


		//Debug.LogWarning ("angle: " + angle);
		//Debug.LogWarning("pos: "+transform.position+" ");
		//Debug.LogWarning("radius: "+radius+" ");
		
		
		if (mousePos.x < transform.position.x) 
		{
			//Left movement
			angle -= rotationspeed*Time.deltaTime;
			
			
		}
		else
		{
			//Right movement
			
			angle -= rotationspeed*Time.deltaTime;
		}
		
		
		var posx = mousePos.x+Mathf.Cos (angle)*radius;
		var posy = mousePos.y+Mathf.Sin (angle)*radius;
		Vector3 vec = new Vector3(posx,posy,0);
		
		transform.position = vec;
		
		
		
	}
	
	
	
}

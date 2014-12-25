using UnityEngine;
using System.Collections;
using System;

public class PlayerController2 : MonoBehaviour {
	

	
	float rotationspeed = (2 * Mathf.PI) / 5;
	float angle ;
	

	public float attractionForce ;
	public float initialForce ;
	bool clickPressed = false;
	
	
	
	int perpendicularOrientation;
	
	public static bool isMoving;
	
	
	Vector3 leftPivot;
	Vector3 rightPivot;
	
	
	
	//Vector3 last_pos;
	
	// Use this for initialization
	void Start () 
	{
		Debug.Log ("Starting Player Controller");
		isMoving = false;
		
		
		leftPivot = new Vector3(AspectUtility.screenWidth*0.1f,AspectUtility.screenHeight*0.5f,0);
		
		rightPivot = new Vector3(AspectUtility.screenWidth*0.9f,AspectUtility.screenHeight*0.5f,0);
		
		transform.rigidbody2D.velocity = new Vector2(transform.rigidbody2D.velocity.x,transform.rigidbody2D.velocity.y+1*initialForce);
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
				
			
				
				perpendicularOrientation = GetPerpendicularVectorOrientation();
				Debug.LogWarning("New Angle: "+angle);
				
				
				
				
				
				
			}
			
			
		}
		if(Input.GetMouseButtonUp(0))
		{
			Debug.Log("Click Released");
			clickPressed = false;
			
			
		}
		
		
	
		
		
		
	}
	
	void FixedUpdate()
	{
		if(clickPressed)
		{
			
			
			Vector3 pivot;
			if(perpendicularOrientation<0)
			{
				pivot = leftPivot;
			
			}
			else
			{
				pivot = rightPivot;
			
			}
			
			Debug.Log ("Pivot: "+pivot);
			
		
			
			//Get click position
			var pivotPos = Camera.main.ScreenToWorldPoint(pivot);
			var distvector = pivotPos - transform.position ;
			
			
			
			
			//Distance from player to Click position
			//float distance = Vector3.Magnitude(distvector);
			
			distvector.Normalize();
			
				
				
				
				
				//var perpendicular = new Vector2(-distvector.y,distvector.x) * perpendicularOrientation;
				
				//Inside Circle Radius
				
				Vector2 velocity = new Vector2(attractionForce*distvector.x,transform.rigidbody2D.velocity.y);
				
				//	if(distance<=circle_radius)
				//velocity+= perpendicular*perimeterForce ;
				
				
				transform.rigidbody2D.velocity= velocity;
				
				
				//	transform.rotation.SetLookRotation(new Vector3(velocity.x,velocity.y,0));
				float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg-90;
				
				
				transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.AngleAxis(angle, Vector3.forward),Time.time*rotationspeed);
				//transform.rigidbody2D.velocity= new Vector2(attractionForce*distvector.x,attractionForce*distvector.y);
				//transform.rigidbody2D.AddForce(perpendicular*perimeterForce);
				//transform.rigidbody2D.AddForce(new Vector2(attractionForce*distvector.x,attractionForce*distvector.y));
				
				
			
			
			
			
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
	
	
	
	
}

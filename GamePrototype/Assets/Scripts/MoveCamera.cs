using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {


	private Transform CameraTransform;
	 bool moving = false;
	float movementStep ;

	 float lastYVelocity;

	 public Transform player;


	public  bool IsMoving()
	{
		return moving;
	}
	public  void StopMoving()
	{
		Vector2 velo = player.transform.rigidbody2D.velocity;
		Debug.Log ("LV: " + lastYVelocity);
		velo.y = lastYVelocity;	
		player.transform.rigidbody2D.velocity = velo;

		moving = false;
	}
	
	void Start()
	{
		var vtest = Camera.main.ScreenToWorldPoint(new Vector3(0,0,0))-Camera.main.ScreenToWorldPoint(new Vector3(0,Screen.height,0));
		float module = Vector3.Magnitude(vtest);
		
		movementStep = module/1.8f;
		CameraTransform = Camera.main.transform;
	}
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other)
	{
		
		
		if (other.gameObject.tag=="Player")
		{
			Debug.Log("Trigger");

			Vector2 velo = player.transform.rigidbody2D.velocity;
			lastYVelocity = velo.y;
			moving = true;
			
		}

	}
	
	
	void Update()
	{
		if (moving) 
		{
						Vector2 velo = player.transform.rigidbody2D.velocity;
						
						velo.y = 0;
						player.transform.rigidbody2D.velocity = velo;
						var pos = CameraTransform.position;
			
						pos.y = pos.y + movementStep;
						//CameraTransform.Translate(pos);
						CameraTransform.position = Vector3.Lerp (CameraTransform.position, pos, 1.4f * Time.deltaTime); 
			
		} 

	
	}
}

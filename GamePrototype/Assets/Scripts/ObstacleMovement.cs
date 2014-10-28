using UnityEngine;
using System.Collections;

public class ObstacleMovement : MonoBehaviour {

	// Use this for initialization
	
	int randomMin = 1;
	public int randomMax ;
	float initialForce = 2f;
	void Start () {
	
			
			
			int randomNumber = Random.Range(randomMin,randomMax);
			int values = randomMax-randomMin;
			
			float angle = 180/(values+1);
			
			
			Vector2 baseVector = Vector2.right;
			
			Vector2 result = Quaternion.AngleAxis(-angle*randomNumber,Vector3.forward)*baseVector;
			
			
			Debug.Log("Result: "+result +" random: "+randomNumber);
			
		//	transform.rigidbody2D.velocity = result*initialForce;
			
			
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

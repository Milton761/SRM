using UnityEngine;
using System.Collections;

public class StickyScript : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		
		other.gameObject.rigidbody2D.velocity = new Vector2(0,0);


	}


}

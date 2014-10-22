using UnityEngine;
using System.Collections;

public class StopCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		
		
		if (other.gameObject.tag=="Player")
		{
			var camera = GameObject.Find("UpperScreenLimit").GetComponent<MoveCamera>();
			camera.StopMoving();
			
		}
		
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}

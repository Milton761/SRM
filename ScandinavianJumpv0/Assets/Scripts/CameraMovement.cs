using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {


	public float constantMovement ;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		var vec = transform.position ;
		vec.x = vec.x+constantMovement*Time.deltaTime;
		transform.position = vec;
	}
}

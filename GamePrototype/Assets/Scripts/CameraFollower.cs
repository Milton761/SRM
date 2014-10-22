using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour {

	public Transform target;
	public float smoothTime = 0.3F;
	private Vector3 velocity = Vector3.zero;
	void Update() {
		var movement = 3;
		
		
		Vector3 targetPosition = new Vector3(transform.position.x,transform.position.y+movement,transform.position.z);
		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
	}
}

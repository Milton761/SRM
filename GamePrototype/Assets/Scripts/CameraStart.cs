using UnityEngine;
using System.Collections;

public class CameraStart : MonoBehaviour {

	public float baseAspect = 2000/1600;
	// Use this for initialization
	void Start () {
		float currAspect = (float)Screen.width / (float)Screen.height;
		Debug.Log ("Aspect: " + currAspect);

		Camera.main.aspect = 6f / 3f;
	//	Camera.main.projectionMatrix = Matrix4x4.Scale(new Vector3(currAspect / baseAspect, 1.0f, 1.0f)) * Camera.main.projectionMatrix;
	//	fontSize = (int)(12 * vertRatio);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

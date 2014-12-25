using UnityEngine;
using System.Collections;

public class SkyBackground : MonoBehaviour
{
	public float scrollSpeed;
	public float tileSizeZ;
//	private Vector3 startPosition;
	
	void Start ()
	{
		//startPosition = transform.position;
	}
	
	void Update ()
	{
		if (Camera.main.transform.position.x > transform.position.x + tileSizeZ) 
		{
			Vector3 tmp = transform.position;
			tmp.x += (2*tileSizeZ);
			transform.position = tmp; 
		}
	}
}
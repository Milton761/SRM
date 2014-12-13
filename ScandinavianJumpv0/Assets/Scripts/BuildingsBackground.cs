using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class BuildingsBackground : MonoBehaviour
{
	public Vector2 speed = new Vector2(10, 10);
	public Vector2 direction = new Vector2(-1, 0);
	private Vector3 startPosition;
	public float tileSizeZ;

	void Start()
	{
		startPosition = transform.position;
	}

	void Update()
	{
		Vector3 movement = new Vector3(speed.x * direction.x, speed.y * direction.y, 0);
		
		movement *= Time.deltaTime;
		gameObject.transform.Translate (movement);

		float currentCameraPos = Camera.main.transform.position.x;
		Vector3 currentBuildingPos = transform.position;

		if (currentCameraPos > currentBuildingPos.x + tileSizeZ) 
		{
			Vector3 lastPosition = new Vector3(currentBuildingPos.x + tileSizeZ, currentBuildingPos.y,currentBuildingPos.z);
			transform.position = new Vector3(lastPosition.x + tileSizeZ, currentBuildingPos.y, currentBuildingPos.z);
		}

	}
	

}



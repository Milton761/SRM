using UnityEngine;
using System.Collections;

public class BuildingsBackground : MonoBehaviour
{
	public float scrollSpeed;
	public float tileSizeZ;
	private Vector3 startPosition;
	public int BuildingN;
	float prevCameraPos;

	void Start ()
	{
		startPosition = transform.position;
		//Debug.Log (startPosition);
		prevCameraPos = 0;
	}
	
	void Update ()
	{
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
		transform.position = startPosition + Vector3.right * newPosition;
		float currentCameraPos = Camera.main.transform.position.x;
		Vector3 currentBuildingPos = transform.position;
		if (currentCameraPos > currentBuildingPos.x + tileSizeZ) 
		{
			Vector3 tmp = currentBuildingPos;
			tmp.x = startPosition.x + (2*tileSizeZ);
			transform.position = tmp;
			startPosition = tmp;
//			Debug.Log (BuildingN + ")  " + transform.position.x + "  " + currentCameraPos);

		}
	}
}
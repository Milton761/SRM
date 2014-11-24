using UnityEngine;
using System.Collections;

public class LocationScript : MonoBehaviour {


	float desiredAccuracyInMeters = 500f;

	public static float Latitude;
	public static float Longitude;

	// Use this for initialization
	IEnumerator Start () {

		if (!Input.location.isEnabledByUser)
			yield return null;


		Input.location.Start(desiredAccuracyInMeters);
		int maxWait = 20;
		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) {
			yield return new WaitForSeconds(1);
			maxWait--;
		}
		if (maxWait < 1) {
			print("Timed out");
			yield return null;
		}
		if (Input.location.status == LocationServiceStatus.Failed) {
			print("Unable to determine device location");
			yield return null;
		} else
		{
			Latitude = Input.location.lastData.latitude;
			Longitude = Input.location.lastData.longitude;

			print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
		}
			


		Input.location.Stop();
	
	}



	
	// Update is called once per frame

}

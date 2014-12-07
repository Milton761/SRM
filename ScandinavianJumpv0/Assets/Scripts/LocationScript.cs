using UnityEngine;
using System.Collections;

public class LocationScript : MonoBehaviour {


	static public double Latitude;
	static public double Longitude;
	IEnumerator Start() {
		if (!Input.location.isEnabledByUser)
			 yield return null;
		
		Input.location.Start(500f,0.1f);
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
			print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
			Latitude = Input.location.lastData.latitude;
			Longitude = Input.location.lastData.longitude ;
		}
		Input.location.Stop();
	}
}

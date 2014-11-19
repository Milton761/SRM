using UnityEngine;
using System.Collections;
using Parse;

public class CloudScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	public static void SendScore(int score)
	{
		
		ParseObject testObject = new ParseObject("Score");
		testObject["foo"] = "bar";
		testObject.SaveAsync();
	}
}

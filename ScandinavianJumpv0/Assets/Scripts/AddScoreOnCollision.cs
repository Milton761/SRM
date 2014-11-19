using UnityEngine;
using System.Collections;

public class AddScoreOnCollision : MonoBehaviour {

	bool score = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		
		if(other.gameObject.tag=="Player")
		{
			AddScore();
		}
		

	}

	void AddScore()
	{
		if(!score)
		{
			score = true;
			GameScore.Score++;
			
		}
		
	}
}

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

			//GetComponent<AudioSource>().Play();
		}
		

	}

	void AddScore()
	{
		if(!score)
		{
			score = true;
			GameScore.Score++;

			if(GameScore.Score!=0 && GameScore.Score%SettingsScript.ScoreLimit==0)
			{
				//GameObject.FindGameObjectWithTag("Player").transform.rigidbody2D.gravityScale+=SettingsScript.GravityIncrease;
				PlayerController.touchTimeScale +=0.001f;
				Camera.main.GetComponent<CameraMovement>().constantMovement+=SettingsScript.CameraMovementIncrease;
				Camera.main.GetComponent<AudioSource>().Play();
			}
			
		}
		
	}
}

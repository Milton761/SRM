using UnityEngine;
using System.Collections;

public class AddScoreOnCollision : MonoBehaviour {

	bool score = false;

	AudioSource scoreLimitAudio;
	// Use this for initialization
	void Start () {

		scoreLimitAudio = Camera.main.GetComponent<AudioSource>();
	
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
				//Increase difficulty
				PlayerController.touchTimeScale +=SettingsScript.PlayerTouchTimeScale;
				Camera.main.GetComponent<CameraMovement>().constantMovement+=SettingsScript.CameraMovementIncrease;
				scoreLimitAudio.Play();
			}





		
			
		}
		
	}



}

using UnityEngine;
using System.Collections;

public class DeadScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
	
		if (other.tag == "Player")
		{
			//Show Score
			//Show Play Button
			//var camera = GameObject.Find("UpperScreenLimit").GetComponent<MoveCamera>();
			//camera.StopMoving();
			SavePlayerScore();
			Application.LoadLevel(4);	
		} 
	}
	

	void SavePlayerScore()
	{

		int score = GameScore.Score;
		int highscore = PlayerPrefs.GetInt ("highscore");



		if (score > highscore) 
		{

			highscore = score;
			PlayerPrefs.SetInt ("highscore", highscore);
		}


		PlayerPrefs.SetInt ("score", score);

		PlayerPrefs.Save ();
	}
	
}

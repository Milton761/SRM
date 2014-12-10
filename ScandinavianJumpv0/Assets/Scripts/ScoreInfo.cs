using UnityEngine;
using System.Collections;

public class ScoreInfo : MonoBehaviour {


	//static float startTime ;
	
	
	float xoffset= 100;
	
	float scoreWidth = 20;
	
	float scoreHeight = 20;
	
	GUIStyle style ;


	
	
	void Start()
	{
		GameScore.Score = 0;
		style = new GUIStyle();
		style.normal.textColor= Color.white;
		style.fontSize=25;
	}

	public static void StartTimer()
	{

	//	startTime = Time.time;

	}
	void Update()
	{
	/*	if (PlayerController.isMoving) 
		{
			GameScore.Score = (int)(Time.time-startTime);
		}
*/

		
		
		
		
	
	}
	
	public GUISkin skin = null;
	void OnGUI()
	{
		GUI.skin = skin;

		GUI.Label(new Rect(Screen.width*0.5f,0,scoreWidth,scoreHeight), "" + GameScore.Score, style);
	}
	

}

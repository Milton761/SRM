using UnityEngine;
using System.Collections;

public class ScoreInfo : MonoBehaviour {


	//static float startTime ;
	
	
	float xoffset= 100;
	
	float scoreWidth = 10;
	
	float scoreHeight = 10;
	
	GUIStyle style ;
	
	
	void Start()
	{
		GameScore.Score = 0;
		style = new GUIStyle();
		style.normal.textColor= Color.white;
		style.fontSize=20;
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
	
	
	void OnGUI()
	{
	
		GUI.Label(new Rect(Screen.width-xoffset,0,scoreWidth,scoreHeight),"Score: "+ GameScore.Score,style);
	}
	

}

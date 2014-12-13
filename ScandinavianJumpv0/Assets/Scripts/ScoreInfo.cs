using UnityEngine;
using System.Collections;

public class ScoreInfo : MonoBehaviour {


	//static float startTime ;

	float scoreWidth = Screen.width * 0.28f;
	float scoreHeight = Screen.height * 0.16f;
	


	
	
	void Start()
	{
		GameScore.Score = 0;
	}

	public static void StartTimer()
	{

	}
	void Update()
	{
	
	}
	
	public GUISkin skin = null;
	void OnGUI()
	{
		GUI.skin = skin;
		GUI.skin.label.fontSize = (int)(Screen.height * 0.125f);
		Debug.Log (GUI.skin.label.fontSize);
		GUI.Label(new Rect(Screen.width*0.36f,0,scoreWidth,scoreHeight), "" + GameScore.Score);
	}
	

}

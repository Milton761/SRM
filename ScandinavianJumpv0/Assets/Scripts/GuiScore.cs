using UnityEngine;
using System.Collections;
using System;
using Parse;
using System.Threading.Tasks;
using System.Linq;
using Facebook.MiniJSON;

public class GuiScore : MonoBehaviour {

	float myScoreX, myScoreY, myScoreWidth, myScoreHeight;

	float maxScoreX, maxScoreY, maxScoreWidth, maxScoreHeight;

	public GUISkin skin = null;

	
	void Start()
	{
		myScoreX = Screen.width * 0.26f;
		myScoreY = Screen.height * 0.56f;
		myScoreWidth = Screen.width * 0.1f;
		myScoreHeight = Screen.height * 0.14f;

		maxScoreX = Screen.width * 0.58f;
		maxScoreY = Screen.height * 0.56f;
		maxScoreWidth = Screen.width * 0.15f;
		maxScoreHeight = Screen.height * 0.14f;

	}
	

	void OnGUI () {

		// do some settings here that are needed in the component
		// set the text
		GUI.skin = skin;
		int score = PlayerPrefs.GetInt ("score");
		int highscore = PlayerPrefs.GetInt ("highscore");
		//score
		GUI.Label (new Rect (myScoreX, myScoreY, myScoreWidth, myScoreHeight), score.ToString());
		//highscore
		GUI.Label (new Rect (maxScoreX, maxScoreY, maxScoreWidth, maxScoreHeight), highscore.ToString());


	}

	public Color OnMouseOverColor = Color.blue;
	public Color OnMouseExitColor = Color.white;
	
	void OnMouseOver()
	{
		GetComponent<TextMesh>().color = OnMouseOverColor;
		
	}
	void OnMouseExit()
	{
		GetComponent<TextMesh>().color = OnMouseExitColor;
	}
	
	bool quit = false;
	
	void OnMouseUp()
	{
		Application.LoadLevel (1);
	}
}

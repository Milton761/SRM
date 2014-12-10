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
		myScoreX = Screen.width * 0.31f;
		myScoreY = Screen.height * 0.56f;
		myScoreWidth = Screen.width * 0.1f;
		myScoreHeight = Screen.height * 0.14f;
		maxScoreX = Screen.width * 0.53f;
		maxScoreY = Screen.height * 0.56f;
		maxScoreWidth = Screen.width * 0.15f;
		maxScoreHeight = Screen.height * 0.14f;

		try
		{
			//only enters once
			int score = PlayerPrefs.GetInt ("score");
			int highscore = PlayerPrefs.GetInt ("highscore");
			var g1 = transform.Find ("myScore").GetComponent<GUIText> ();
			g1.text = score.ToString();
			g1.fontSize = (int)(0.14f * Screen.height);
			var g2 = transform.Find ("maxScore").GetComponent<GUIText> ();
			g2.text = highscore.ToString();
			g2.fontSize = (int)(0.14f * Screen.height);

		}
		catch
		{
		}
	}

	void OnGUI () {

		// do some settings here that are needed in the component
		// set the text
		GUI.skin = skin;
		int score = PlayerPrefs.GetInt ("score");
		int highscore = PlayerPrefs.GetInt ("highscore");
		//score
		//GUI.Label (new Rect (myScoreX, myScoreY, myScoreWidth, myScoreHeight), score.ToString());
		//highscore
		//GUI.Label (new Rect (maxScoreX, maxScoreY, maxScoreWidth, maxScoreHeight), highscore.ToString());

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
		StartCoroutine("StartLevel");
	}

	IEnumerator StartLevel()
	{
		
		var audio = Camera.main.GetComponent<AudioSource>();
		
		audio.Play();
		
		yield return new WaitForSeconds(audio.clip.length);
		
		Application.LoadLevel (1);  
	}
}

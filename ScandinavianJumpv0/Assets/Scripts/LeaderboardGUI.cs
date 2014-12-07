using UnityEngine;
using System.Collections;
using Parse;
using System.Collections.Generic;

public class LeaderboardGUI : MonoBehaviour {


	class Scores
	{
		public string name;
		public string score;
		
	}
	public GUISkin skin = null;

	
	List<Scores> scoresList; 
	// Use this for initialization
	void Start () {

		StartCoroutine("LoadNearestScores");

		scoresList = new List<Scores>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}




	IEnumerator LoadNearestScores()
	{

		ParseGeoPoint userLocation = new ParseGeoPoint(LocationScript.Latitude,LocationScript.Longitude);
		ParseQuery<ParseObject> query = ParseObject.GetQuery("GameScore");


		query.WhereWithinDistance("geo_point",userLocation,ParseGeoDistance.FromKilometers(2));
		query.Limit(5);

		var resultTask = query.FindAsync();

		while (!resultTask.IsCompleted) yield return null;

		if (resultTask.IsFaulted || resultTask.IsCanceled) 
		{
			// Handle error
		} 
		else
		{
			var results = resultTask.Result;


			foreach (var item in results) 
			{
				Debug.Log("name: "+item["player_name"]);
				Debug.Log("score: "+item["score"]);

				scoresList.Add(new Scores{name=item["player_name"].ToString(),score=item["score"].ToString()});
			}
		}
	}


	void OnGUI()
	{
		GUI.skin = skin;

		float win=Screen.width*0.6f;
		int i = 0;
     	foreach (var item in scoresList)
		{
			GUI.Label(new Rect(Screen.width * 0.32f,Screen.height * 0.3f + (i * Screen.height*0.09f), Screen.width*0.28f,Screen.height*0.09f), item.name);
			GUI.Label(new Rect(Screen.width * 0.6f,Screen.height * 0.3f + (i * Screen.height*0.09f), Screen.width*0.7f,Screen.height*0.09f), item.score);                     
			i++;
		}

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

	
	void OnMouseUp()
	{
		Application.LoadLevel ("GameOverScene");
	}
}

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

		float win=Screen.width*0.6f;
		float w1=win*0.35f; float w2=win*0.15f; float w3=win*0.35f;

		foreach (var item in scoresList)
		{
		
			
				GUILayout.BeginHorizontal();
				GUILayout.Label(item.name, GUILayout.Width(w1));
				GUILayout.Label(item.score, GUILayout.Width(w2));
				
				GUILayout.EndHorizontal();                     
			
		}
	}
}

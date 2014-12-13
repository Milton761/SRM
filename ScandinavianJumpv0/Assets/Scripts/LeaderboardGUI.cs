using UnityEngine;
using System.Collections;
using Parse;
using System.Collections.Generic;
using System.Linq;

public class LeaderboardGUI : MonoBehaviour {


	class Scores
	{
		public string name;
		public string score;
		
	}
	public GUISkin skin = null;

	
	List<Scores> scoresList; 

	List<Scores> nearestScoresList;
	// Use this for initialization
	IEnumerator Start () {

		yield return new WaitForSeconds(0.8f);

		StartCoroutine("LoadNearestScores");

		scoresList = new List<Scores>();
		nearestScoresList = new List<Scores> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}




	IEnumerator LoadNearestScores()
	{

		ParseGeoPoint userLocation = new ParseGeoPoint(LocationScript.Latitude,LocationScript.Longitude);
		ParseQuery<ParseObject> query = ParseObject.GetQuery("GameScore").OrderByDescending("score").Limit(5);
		ParseQuery<ParseObject> nearestQuery = ParseObject.GetQuery("GameScore").WhereWithinDistance("geo_pos",userLocation,ParseGeoDistance.FromKilometers(2)).OrderByDescending("score").Limit(5);




		var resultTask = query.FindAsync();

		while (!resultTask.IsCompleted) yield return null;

		if (resultTask.IsFaulted || resultTask.IsCanceled) 
		{
			// Handle error
		} 
		else
		{
			var results = resultTask.Result;


			//var resultsList = results.OrderBy(item=>item.Get<int>("score")).Reverse().ToList();
			foreach(var item in results) 
			{

				Debug.Log("name: "+item["player_name"]);
				Debug.Log("score: "+item["score"]);

				scoresList.Add(new Scores{name=item["player_name"].ToString(),score=item["score"].ToString()});
			}
		}


		//////////////////
		/// 
		 resultTask = nearestQuery.FindAsync();
		
		while (!resultTask.IsCompleted) yield return null;
		
		if (resultTask.IsFaulted || resultTask.IsCanceled) 
		{
			// Handle error
		} 
		else
		{
			var results = resultTask.Result;
			Debug.Log ("NEAREST COUNT " + results.Count());
			
			//var resultsList = results.OrderBy(item=>item.Get<int>("score")).Reverse().ToList();
			foreach(var item in results) 
			{
				
				Debug.Log("name: "+item["player_name"]);
				Debug.Log("score: "+item["score"]);
				
				nearestScoresList.Add(new Scores{name=item["player_name"].ToString(),score=item["score"].ToString()});
			}
		}


	}


	void OnGUI()
	{
		GUI.skin = skin;
		GUI.skin.label.fontSize = (int)(0.032f * Screen.height);

		int i = 0;

		GUI.skin.label.fontSize = (int)(0.072f * Screen.height);

		GUI.Label (new Rect(Screen.width * 0.13f,Screen.height * 0.1f , Screen.width*0.23f,Screen.height*0.1f), "GLOBAL");
		GUI.Label (new Rect(Screen.width * 0.61f,Screen.height * 0.1f , Screen.width*0.2f,Screen.height*0.1f), "LOCAL");

		GUI.skin.label.fontSize = (int)(0.032f * Screen.height);

		if(scoresList!=null)
		{

			foreach (var item in scoresList)
			{
				GUI.Label(new Rect(Screen.width * 0.06f,Screen.height * 0.25f + (i * Screen.height*0.09f), Screen.width*0.44f,Screen.height*0.09f), item.name);
				GUI.Label(new Rect(Screen.width * 0.44f,Screen.height * 0.25f + (i * Screen.height*0.09f), Screen.width*0.1f,Screen.height*0.09f), item.score);                     

				i++;
			}

		}

		i = 0;


		if(nearestScoresList!=null)
		{

			foreach (var item in nearestScoresList)
			{
				GUI.Label(new Rect(Screen.width * 0.53f,Screen.height * 0.25f + (i * Screen.height*0.09f), Screen.width*0.44f,Screen.height*0.09f), item.name);
				GUI.Label(new Rect(Screen.width * 0.9f,Screen.height * 0.25f + (i * Screen.height*0.09f), Screen.width*0.1f,Screen.height*0.09f), item.score);                     
				
				i++;
			}
			
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

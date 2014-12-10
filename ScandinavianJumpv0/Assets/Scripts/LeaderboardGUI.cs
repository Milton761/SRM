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
	// Use this for initialization
	IEnumerator Start () {

		yield return new WaitForSeconds(0.8f);

		StartCoroutine("LoadNearestScores");

		scoresList = new List<Scores>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}




	IEnumerator LoadNearestScores()
	{

		ParseGeoPoint userLocation = new ParseGeoPoint(LocationScript.Latitude,LocationScript.Longitude);
		ParseQuery<ParseObject> query = ParseObject.GetQuery("GameScore").WhereWithinDistance("geo_point",userLocation,ParseGeoDistance.FromKilometers(2)).Limit(5);




		var resultTask = query.FindAsync();

		while (!resultTask.IsCompleted) yield return null;

		if (resultTask.IsFaulted || resultTask.IsCanceled) 
		{
			// Handle error
		} 
		else
		{
			var results = resultTask.Result;


			var resultsList = results.OrderBy(item=>item.Get<int>("score")).Reverse().ToList();
			foreach(var item in resultsList) 
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
		GUI.skin.label.fontSize = (int)(0.032f * Screen.height);

		float win=Screen.width*0.6f;
		int i = 0;

		if(scoresList!=null)
		{

			foreach (var item in scoresList)
			{
				GUI.Label(new Rect(Screen.width * 0.2f,Screen.height * 0.2f + (i * Screen.height*0.09f), Screen.width*0.44f,Screen.height*0.09f), item.name);
				GUI.Label(new Rect(Screen.width * 0.7f,Screen.height * 0.2f + (i * Screen.height*0.09f), Screen.width*0.1f,Screen.height*0.09f), item.score);                     
				i++;
				if (i == 5) break;
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

using UnityEngine;
using System.Collections;
using Parse;
using System;
using Facebook.MiniJSON;
using System.Linq;

public class GameOver : MonoBehaviour {

	float scoreX, scoreY, scoreWidth, scoreHeight;
	
	string Username {get;set;}
	string UserImage {get;set;}
	
	int UserScore {get;set;}
	public GUISkin skin = null;
	
	void Start()
	{
		scoreX = Screen.width * 0.36f;
		scoreY = Screen.height * 0.69f;
		scoreWidth = Screen.width * 0.29f;
		scoreHeight = Screen.height * 0.14f;

	}
	void OnGUI () {
		
		GUI.skin = skin;
		UserScore= PlayerPrefs.GetInt ("score");
		//score
		GUI.Label (new Rect (scoreX, scoreY, scoreWidth, scoreHeight), "Your Score: " + UserScore.ToString ());

		if (GUI.Button (new Rect (Screen.width * 0.42f, Screen.height * 0.85f, Screen.width * 0.15f, Screen.height * 0.08f), "Ranking"))
		{
			FBLogin();
		}
	}


	void OnMouseUp()
	{
		Application.LoadLevel (2);
	}

	
	private void FBLogin() {
		Debug.Log ("In FBLogin");

		if(FB.IsLoggedIn)
		{

			Debug.Log("Already Logged In");
			FB.API("/me?fields=name,picture", Facebook.HttpMethod.GET, UserCallBack);
		}
		else
		{
			FB.Login("user_about_me, user_relationships, user_birthday, user_location", FBLoginCallback);
		}


	}
	
	private void FBLoginCallback(FBResult result) {

		Debug.Log ("In Callback");
		if(FB.IsLoggedIn) {
			//	showLoggedIn();
			StartCoroutine("ParseLogin");
		} else {
			Debug.Log ("FBLoginCallback: User canceled login");
		}
		
		
	}
	
	
	
	
	
	
	
	private IEnumerator ParseLogin() {
		if (FB.IsLoggedIn) {
			var loginTask = 
				ParseFacebookUtils.LogInAsync(FB.UserId, 
				                              FB.AccessToken, 
				                              DateTime.Now);
			
			while (!loginTask.IsCompleted) yield return null;
			if (loginTask.IsFaulted || loginTask.IsCanceled) {
				// Handle error
				Debug.Log ("Not logged in");
			} else {
				
				Debug.Log("Logged in. ID: " + FB.UserId);
				FB.API("/me?fields=name,picture", Facebook.HttpMethod.GET, UserCallBack);
				
				
				// Handle success
			}
		}
	}
	
	
	void UserCallBack(FBResult result) {
		
		string get_data;
		if (result.Error != null)
		{              
			
			get_data = result.Text;
			
		}
		else
		{
			
			get_data = result.Text;
			
			
		}
		
		
		Debug.Log ("data: "+get_data);
		var dict = Json.Deserialize(get_data) as IDictionary;
		
		Username = dict["name"].ToString();
		var pic_data = dict["picture"] as IDictionary;
		
		
		var pic_dict = pic_data["data"] as IDictionary;
		
		
		UserImage = pic_dict["url"].ToString();
		
		Debug.Log ("image: "+UserImage);
		StartCoroutine("SaveScore");
	}
	
	
	IEnumerator   SaveScore()
	{
		//FB.API("me?fields=name", Facebook.HttpMethod.GET, UserCallBack);
		
		var query = ParseObject.GetQuery("GameScore").WhereEqualTo("player_name",Username);
		var resultTask =  query.FindAsync();
		
		while (!resultTask.IsCompleted) yield return null;
		
		
		if (resultTask.IsFaulted || resultTask.IsCanceled) {
			// Handle error
		} else {
			
			
			var results = resultTask.Result;
			
			ParseGeoPoint userLocation = new ParseGeoPoint(LocationScript.Latitude,LocationScript.Longitude);
			
			
			if(results.Count()==0)
			{
				//If its the first time
				
				ParseObject userScore = new ParseObject("GameScore");
				
				userScore["player_name"]= Username;
				userScore["player_image"]= UserImage;
				userScore["geo_pos"] = userLocation;
				//	userScore["lat"]= LocationScript.Latitude;
				//	userScore["lng"]= LocationScript.Longitude;
				userScore["score"] = UserScore;
				
				Debug.Log ("Creating score");
				
				
				
				userScore.SaveAsync();
				
			}
			else
			{

			
				//Update the score if greater than previous score
				var userScore = results.FirstOrDefault();
				
				int prev_score = userScore.Get<int>("score");

				Debug.Log ("Updating: new score: "+UserScore+" prev "+prev_score);
				
				if(prev_score< UserScore)
				{
					userScore["score"] = UserScore;
					userScore["geo_pos"] = userLocation;
					userScore.SaveAsync();
				}
				
				
				

				
				
				
			}
			
			Application.LoadLevel(5);
			
			
		}
		
		
	}

}

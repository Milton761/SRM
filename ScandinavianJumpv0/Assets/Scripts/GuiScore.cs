using UnityEngine;
using System.Collections;
using System;
using Parse;
using System.Threading.Tasks;
using System.Linq;
using Facebook.MiniJSON;

public class GuiScore : MonoBehaviour {

	float boxposx;
	float boxposy;
	
	float boxwidth = Screen.width/2;
	float boxheight = Screen.height/2;
	
	float yoffset ;
	float xoffset ;
	
	
	float buttonwidth = Screen.width/3;
	float buttonheight = Screen.height/5;

	GUIStyle style ;

	string Username {get;set;}
	string UserImage {get;set;}

	int UserScore {get;set;}

	void Start()
	{
		boxposx = Screen.width/2-boxwidth/2;
		boxposy = Screen.height/2-boxheight/2;
		
		yoffset = boxheight/5;
		xoffset = boxwidth/5;

		style = new GUIStyle();
		style.normal.textColor= Color.white;
		style.fontSize=30;
			
		
	}
	

	
	void OnGUI () {

		UserScore= PlayerPrefs.GetInt ("score");
		int highscore = PlayerPrefs.GetInt ("highscore");
		// Make a background box
		GUI.Label(new Rect(boxposx+xoffset,boxposy,boxwidth,boxheight), "Your score: "+UserScore.ToString(),style);
		// Make a background box
		GUI.Label(new Rect(boxposx+xoffset,boxposy+yoffset,boxwidth,boxheight), "Highscore: "+highscore.ToString(),style);
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(boxposx+xoffset,boxposy+2*yoffset,buttonwidth,buttonheight), "Play")) {
			Application.LoadLevel(1);
		}
		
		if(GUI.Button(new Rect(boxposx+xoffset,boxposy+4*yoffset,buttonwidth,buttonheight), "Ranking")) {
			FBLogin();
		}
		
		
	}
	
	private void FBLogin() {
		FB.Login("user_about_me, user_relationships, user_birthday, user_location", FBLoginCallback);
	}
	
	private void FBLoginCallback(FBResult result) {
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

				Debug.Log ("saving async");


			
				userScore.SaveAsync();
		 	
		 	}
			else
			{
				//Update the score if greater than previous score
				var userScore = results.FirstOrDefault();

				int prev_score = userScore.Get<int>("score");

				if(prev_score< UserScore)
				{
					userScore["score"] = UserScore;
					userScore["geo_pos"] = userLocation;
				}



				userScore.SaveAsync();



			}

			Application.LoadLevel(3);
			
			
		}
			
	
	}
	
}

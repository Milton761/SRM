using UnityEngine;
using System.Collections;
using System;
using Parse;
using System.Threading.Tasks;
using System.Linq;

public class GuiScore : MonoBehaviour {

	float boxposx;
	float boxposy;
	
	float boxwidth = 100;
	float boxheight = 90;
	
	float yoffset = 35;
	float xoffset = 10;
	
	
	float buttonwidth = 80;
	float buttonheight = 20;
	void Start()
	{
		boxposx = Screen.width/2-boxwidth/2;
		boxposy = Screen.height/2-boxheight/2;
		
		
			
		
	}
	

	
	void OnGUI () {

		int score = PlayerPrefs.GetInt ("score");
		int highscore = PlayerPrefs.GetInt ("highscore");
		// Make a background box
		GUI.Label(new Rect(boxposx,boxposy,boxwidth,boxheight), "Your score: "+score.ToString());
		// Make a background box
		GUI.Label(new Rect(boxposx,boxposy+yoffset,boxwidth,boxheight), "Highscore: "+highscore.ToString());
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(boxposx+xoffset,boxposy+2*yoffset,buttonwidth,buttonheight), "Play")) {
			Application.LoadLevel(1);
		}
		
		if(GUI.Button(new Rect(boxposx+xoffset,boxposy+3*yoffset,buttonwidth,buttonheight), "Ranking")) {
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
	
	
	string Username {get;set;}
	string UserImage {get;set;}
	
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
			
				FB.API("me?fields=name", Facebook.HttpMethod.GET, UserCallBack);
			
			
				// Handle success
			}
		}
	}
	
	
	void UserCallBack(FBResult result) {
		if (result.Error != null)
		{                                                                      
			Username = result.Text;
			StartCoroutine("SaveScore");
		}
		else
		{
			Debug.Log ("Error");
		}
		
	}
	
	
	 IEnumerator   SaveScore()
	{
		FB.API("me?fields=name", Facebook.HttpMethod.GET, UserCallBack);
		
		var query = ParseObject.GetQuery("GameScore").WhereEqualTo("player_name","unknown");
		var resultTask =  query.FindAsync();
		
		while (!resultTask.IsCompleted) yield return null;
		
		
		if (resultTask.IsFaulted || resultTask.IsCanceled) {
			// Handle error
		} else {
			
			
			var results = resultTask.Result;
		 	
		 	if(results.Count()==0)
		 	{
		 		ParseObject userScore = new ParseObject("GameScore");
		 		userScore["player_name"]= Username;
				userScore["player_image"]= "unknown";
				userScore["lat"]= "unknown";
				userScore["lng"]= "unknown";
				
				userScore.SaveAsync();
		 	
		 	}
			
			
		}
			
	
	}
	
}

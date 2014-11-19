using UnityEngine;
using System.Collections;

public class Gui : MonoBehaviour {

	float boxposx;
	float boxposy;
	
	float boxwidth = Screen.width/2;
	float boxheight = Screen.height/2;
	
	float yoffset ;
	float xoffset ;
	
	
	float buttonwidth = Screen.width/3;
	float buttonheight = Screen.height/3;
	void Start()
	{
		boxposx = Screen.width/2-boxwidth/2;
		boxposy = Screen.height/2-boxheight/2;

		 yoffset = boxheight/5;
		 xoffset = boxwidth/5;

		FB.Init(OnInitComplete, OnHideUnity);
	
	}
	void OnGUI () {
		// Make a background box
		GUI.Box(new Rect(boxposx,boxposy,boxwidth,boxheight), "Menu");
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(boxposx+xoffset,boxposy+yoffset,buttonwidth,buttonheight), "Play")) {
			Application.LoadLevel(1);
		}
		
		
	}
	
	private void OnInitComplete()
	{
		Debug.Log("FB.Init completed: Is user logged in? " + FB.IsLoggedIn);
	}
	
	private void OnHideUnity(bool isGameShown)	
	{
		Debug.Log("Is game showing? " + isGameShown);
	}
}

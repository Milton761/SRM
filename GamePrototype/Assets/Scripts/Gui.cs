using UnityEngine;
using System.Collections;

public class Gui : MonoBehaviour {

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
		// Make a background box
		GUI.Box(new Rect(boxposx,boxposy,boxwidth,boxheight), "Menu");
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(boxposx+xoffset,boxposy+yoffset,buttonwidth,buttonheight), "Play")) {
			Application.LoadLevel(1);
		}
		
		
	}
}

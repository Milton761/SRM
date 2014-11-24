using UnityEngine;
using System.Collections;

public class SplashScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{

		StartCoroutine("Wait");
	
	}

	IEnumerator Wait()
	{

		yield return new WaitForSeconds(3);


		Application.LoadLevel("GuiScene");
	}
	

}

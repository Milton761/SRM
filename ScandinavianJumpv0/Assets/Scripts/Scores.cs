using UnityEngine;
using System.Collections;

public class Scores : MonoBehaviour {

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
		GetComponent<TextMesh>().color = OnMouseExitColor;
		StartCoroutine("StartLevel");
	}


	IEnumerator StartLevel()
	{
		
		var audio = Camera.main.GetComponent<AudioSource>();
		
		audio.Play();
		
		yield return new WaitForSeconds(audio.clip.length);
		
		Application.LoadLevel (3);  
	}
}

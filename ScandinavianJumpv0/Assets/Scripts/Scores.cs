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

		Application.LoadLevel (3);
	}
}

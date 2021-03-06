﻿using UnityEngine;
using System.Collections;

public class Gui : MonoBehaviour {

	
	void Start()
	{

		if(!FB.IsInitialized)
			FB.Init(OnInitComplete, OnHideUnity);
	
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
		GetComponent<TextMesh>().color = OnMouseExitColor;
		StartCoroutine("StartLevel");

	}

	IEnumerator StartLevel()
	{

		var audio = Camera.main.GetComponent<AudioSource>();

		audio.Play();

		yield return new WaitForSeconds(audio.clip.length);

		Application.LoadLevel (2);  
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

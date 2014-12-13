using UnityEngine;
using System.Collections;

public class BackgroundSound : MonoBehaviour {


	public AudioClip [] sounds;
	public float min;
	public float max;
	// Use this for initialization
	void Start () {
		Invoke("PlaySound",Random.Range(1,5));
	}
	
	void PlaySound()
	{
		AudioSource toPlay = GetComponent<AudioSource>();

		toPlay.clip = sounds[Random.Range(0,sounds.Length)]; 

		toPlay.Play();
		Invoke("PlaySound",Random.Range(min,max));
	}
}

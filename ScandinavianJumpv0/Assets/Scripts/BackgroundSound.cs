using UnityEngine;
using System.Collections;

public class BackgroundSound : MonoBehaviour {


	public AudioClip [] sounds;
	public float min;
	public float max;

	AudioSource backgroundAudio;
	// Use this for initialization
	void Start () {

		backgroundAudio = GetComponent<AudioSource>();
		Invoke("PlaySound",Random.Range(1,5));
	}
	
	void PlaySound()
	{


		backgroundAudio.clip = sounds[Random.Range(0,sounds.Length)]; 

		backgroundAudio.Play();
		Invoke("PlaySound",Random.Range(min,max));
	}
}

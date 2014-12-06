using UnityEngine;
using System.Collections;

public class StickyScript : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other)
	{

		if (other.gameObject.tag == "Player") 
		{


			other.gameObject.GetComponent<PlayerController>().progress = 0;
			other.gameObject.rigidbody2D.velocity = new Vector2(0,0);

			other.gameObject.GetComponent<Animator>().SetBool("anim_jump",false);
		}
		



	}


}

using UnityEngine;
using System.Collections;

public class SpriteChanger : MonoBehaviour {

	// Use this for initialization

	public int sprite_limit;

	void Start () 
	{

		int spriteid = PlayerPrefs.GetInt("spriteid");

		Debug.Log("Sprite id: "+spriteid);

		if(spriteid==0)
		{

			spriteid = 1;

		
		}

		if(spriteid>sprite_limit)
		{
			spriteid = sprite_limit;
		}

		int index = Random.Range(0,spriteid);
		GetComponent<Animator>().SetInteger("sprite_id",index);

	}
	
	// Update is called once per frame
	void Update () 
	{

	}
}

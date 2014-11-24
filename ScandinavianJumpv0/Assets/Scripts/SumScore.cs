using UnityEngine;
using System.Collections;

public class SumScore : MonoBehaviour {


	
	void OnTriggerEnter2D(Collider2D other)
	{
		
		
		if (other.gameObject.tag=="Player")
		{
			GameScore.Score= GameScore.Score+1;
			
			Destroy(this.gameObject);
			
		}
		
	}
}

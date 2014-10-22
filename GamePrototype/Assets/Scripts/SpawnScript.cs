using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {


	public  GameObject[] obj;
	public  float min;
	public  float max;


	

	
	// Use this for initialization
	void Start () {

		//Spawn();
	}

	public  void StartSpawning()
	{
		Spawn();
	}
	
	 void Spawn()
	{

			float random_x = Random.Range(transform.localPosition.x-transform.localScale.x/2,transform.localPosition.x+transform.localScale.x/2);
			
			//Debug.Log ("Random "+r);
			var pos = new Vector3(random_x,transform.position.y,0);
			Instantiate(obj[Random.Range(0,obj.Length)],pos,Quaternion.identity);
			Invoke("Spawn",Random.Range(min,max));


			
		
		

		
	}
}

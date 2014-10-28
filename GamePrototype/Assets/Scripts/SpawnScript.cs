using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {


	public  GameObject[] obj;
	public  float min;
	public  float max;

	public bool spawnGoal;
	
	public GameObject GoalPrefab;
	

	
	// Use this for initialization
	void Start () {

		Invoke("Spawn",Random.Range(min,max));
	}

	public  void StartSpawning()
	{
		//Spawn();
		Invoke("Spawn",Random.Range(min,max));
		
	}
	
	 void Spawn()
	{

			
			//Instantiate Goal
			if(spawnGoal)
			{
				Instantiate(GoalPrefab,transform.position,Quaternion.identity);
			
			}
			//Instantiate obstacle
			float random_x = Random.Range(transform.localPosition.x-transform.localScale.x/2,transform.localPosition.x+transform.localScale.x/2);
		
			var pos = new Vector3(random_x,transform.position.y,0);
			Instantiate(obj[Random.Range(0,obj.Length)],pos,Quaternion.identity);
			Invoke("Spawn",Random.Range(min,max));


			
		
		

		
	}
}

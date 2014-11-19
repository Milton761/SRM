using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
	
	
	public  GameObject[] obj;
	public  float min;
	public  float max;
	


	// Use this for initialization
	void Start () {

		Spawn();
	}
	

	
	void Spawn()
	{
		

		
		var pos = new Vector3(transform.position.x,transform.position.y,0);
		Instantiate(obj[Random.Range(0,obj.Length)],pos,Quaternion.identity);
		Invoke("Spawn",Random.Range(min,max));
		
		
		
		
		
		
		
	}
}

using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] groups;

	// Use this for initialization
	void Start () {
		spawnNext();
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	public void changeSide(){
		int i = Random.Range (0, groups.Length);
		
		switch(Grid.lado){
			
		case 1:
			
			//coloca um bloco na posiçao do elemento
			//Instantiate (groups [i], transform.position, Quaternion.identity);
			//Debug.Log ("Instanciou");
			break;
		case 2:
			Vector3 pos = new Vector3(10,14,5);
			transform.position = pos;
			//transform.Rotate (new Vector3 (0, -90, 0));
			
			//coloca um bloco na posiçao do elemento
			//Instantiate (groups [i], transform.position, Quaternion.identity);
			//Debug.Log ("Instanciou");
			break;
		case 3:
			transform.position = new Vector3(5,14,10);
			//coloca um bloco na posiçao do elemento
			//Instantiate (groups [i], transform.position, Quaternion.identity);
			//Debug.Log ("Instanciou");
			break;
		case 4:
			transform.position = new Vector3(0,14,10);
			//coloca um bloco na posiçao do elemento
			//Instantiate (groups [i], transform.position, Quaternion.identity);
			//Debug.Log ("Instanciou");
			break;
		}

	}

	public void spawnNext(){
		int i = Random.Range (0, groups.Length);
		switch(Grid.lado){			
			case 1:
					Quaternion q = groups [i].transform.rotation;
					Instantiate (groups [i], transform.position,  q);
					break;

			case 2:
					Quaternion q1 = groups [i].transform.rotation;
					q.y = 270;
			Instantiate (groups [i], transform.position,  Quaternion.Euler(0, 270, 0));
					break;
		}

	}
}

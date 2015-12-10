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
			Vector3 pos2 = new Vector3(5,13,0);
			transform.position = pos2;
			//coloca um bloco na posiçao do elemento
			//Instantiate (groups [i], transform.position, Quaternion.identity);
			//Debug.Log ("Instanciou");
			break;
		case 2:
			Vector3 pos = new Vector3(10,13,5);
			transform.position = pos;
			//transform.Rotate (new Vector3 (0, -90, 0));
			
			//coloca um bloco na posiçao do elemento
			//Instantiate (groups [i], transform.position, Quaternion.identity);
			//Debug.Log ("Instanciou");
			break;
		case 3:
			Vector3 pos3 = new Vector3(4,13,10);
			transform.position = pos3;
			//coloca um bloco na posiçao do elemento
			//Instantiate (groups [i], transform.position, Quaternion.identity);
			//Debug.Log ("Instanciou");
			break;
		case 4:
			Vector3 pos4 = new Vector3(0,13,4);
			transform.position = pos4;
			//coloca um bloco na posiçao do elemento
			//Instantiate (groups [i], transform.position, Quaternion.identity);
			//Debug.Log ("Instanciou");
			break;
		}

	}

	public void spawnNext(){
		//int i = Random.Range (0, groups.Length);

		int i = 3;

		switch(Grid.lado){			
			case 1:
					Quaternion q = groups [i].transform.rotation;

			Debug.Log("POSICAO 1" + transform.position.x + " " + transform.position.y + " " + transform.position.z);

					Instantiate (groups [i], transform.position,  q);
					break;

			case 2:
					Quaternion q1 = groups [i].transform.rotation;
					q.y = 270;

					Debug.Log("POSICAO 3" + transform.position.x + " " + transform.position.y + " " + transform.position.z);


					Instantiate (groups [i], transform.position,  Quaternion.Euler(0, 270, 0));
					break;

			case 3:
					Quaternion q2 = groups [i].transform.rotation;
					q.y = 180;

			Debug.Log("POSICAO 2" + transform.position.x + " " + transform.position.y + " " + transform.position.z);
						

					Instantiate (groups [i], transform.position,  Quaternion.Euler(0, 180, 0));
					break;

			case 4:
					Quaternion q3 = groups [i].transform.rotation;
					q.y = 90;
					Instantiate (groups [i], transform.position,  Quaternion.Euler(0, 90, 0));
					break;
		}

	}
}

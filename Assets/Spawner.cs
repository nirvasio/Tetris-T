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

	public void spawnNext(){
		int i = Random.Range (0, groups.Length);
		//coloca um bloco na posiçao do elemento
		Instantiate (groups [i], transform.position, Quaternion.identity);
		//Debug.Log ("Instanciou");
	}
}

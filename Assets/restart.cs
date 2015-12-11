using UnityEngine;
using System.Collections;

public class restart : MonoBehaviour {

	public Camera camera;

	// Use this for initialization
	void Start () {
	
	}
	
	void Update(){
		if (Input.GetMouseButtonDown(0)){ // if left button pressed...

			Ray ray = GameObject.FindWithTag ("MainCamera").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)){

			}
		}
	}
}
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GAMEOVER : MonoBehaviour {

	Text placar;

	// Use this for initialization
	void Start () {

		placar = GameObject.FindWithTag ("Placar2").GetComponent<Text>();
		placar.text = "Pontuaçao: " + Grid.pontuacao;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void gameOver(){

		Grid.lado = 1;
		Grid.pontuacao = 0;
		
		Grid.grid1 = new Transform[Grid.w, Grid.h];
		Grid.grid2 = new Transform[Grid.w, Grid.h];
		Grid.grid3 = new Transform[Grid.w, Grid.h];
		Grid.grid4 = new Transform[Grid.w, Grid.h];

		Application.LoadLevel("CenaTetris");

	}
}

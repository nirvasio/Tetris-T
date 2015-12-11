using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraMove : MonoBehaviour {


	// Update is called once per frame
	public Transform[] pos;
	public Transform center;
	private GoTweenConfig configRight,configLeft, config2;
	private GoSpline pathRight,pathLeft;
	private GoTween efeito;
	private int i,aux,flag;
	private Vector3[] pointsRight;
	private Vector3[] pointsLeft;

	//public static bool rodandoDireita = true;
	//public static bool rodandoEsquerda = true;

	Text placar;

	private AudioSource audio;

	void Start ()
	{
		i = 0;
		flag = 0;

		config2 = new GoTweenConfig ()
			.shake(new Vector3(0,0,12),GoShakeType.Position, 1,false);
		
		audio = GetComponent<AudioSource>();

		placar = GameObject.FindWithTag ("Placar").GetComponent<Text>();
	}

	void setPathRight(int i,int aux)
	{	

		Debug.Log (i);
		Debug.Log (aux);

		pointsRight =  new Vector3[] {pos[i].position,pos[aux].position};
		pathRight = new GoSpline( pointsRight );

		//rodandoDireita = false;

		configRight = new GoTweenConfig ()
			.setEaseType (GoEaseType.SineInOut)
				.positionPath(pathRight,false,GoLookAtType.TargetTransform,center).position(transform.position,true)
				.position(transform.position,true)
				.onComplete(a => {
					//rodandoDireita = true;
				});
	}

	void setPathLeft(int i,int aux)
	{

		Debug.Log (i);
		Debug.Log (aux);


		pointsLeft = new Vector3[] {pos[i].position,pos[aux].position};
		pathLeft = new GoSpline( pointsLeft );

		//rodandoEsquerda = false;
		configLeft = new GoTweenConfig ()
			.setEaseType (GoEaseType.SineInOut)
				.positionPath(pathLeft,false,GoLookAtType.TargetTransform,center).position(transform.position,true)
				.position(transform.position,true)
				.onComplete(a => {
					//rodandoEsquerda = true;
				});
		
	}


	void Update () 
	{	
		
		placar.text = "Pontuaçao: " + Grid.pontuacao;

		if (Input.GetKeyDown (KeyCode.D) ) {
			audio.Play ();
			if(i>3)
			{
				i= 0;
			}
			else if(i<0){
				i = 3;
			}
			
			if (i == 3) {
				aux = 0;
				
			}
			else
			{
				aux = i+1;
			}

				setPathRight(i,aux);

				if ((transform.position != pos [aux].position)) {
					efeito = Go.to (transform, 1f, configRight);
					efeito.play ();
					i++;
				} 

		} 
		if (Input.GetKeyDown (KeyCode.A))
		{
			audio.Play ();
			if(i>3)
			{
				i= 0;
			}
			else if(i<0){
				i = 3;
			}
			
			if (i == 0) {
				aux = 3;
			} 
			else 
			{
				aux = i-1;
			}

				setPathLeft(i,aux);

				if ((transform.position != pos [aux].position)) {

						efeito = Go.to (transform, 1f, configLeft);
						efeito.play ();
						i--;
				} 

		}
	}
}
using UnityEngine;
using System.Collections;

public class Group : MonoBehaviour {

	float lastFall;
	
	public GameObject explosionPrefab;

	private AudioSource audio;

	public GameObject gameOver;


	// Use this for initialization
	void Start () {
		// Default position not valid? Then it's game over
		if (!isValidGridPos()) {
			Debug.Log("GAME OVER");
			Destroy(gameObject);
			Application.LoadLevel("CenaG");
		}

		audio = GetComponent<AudioSource>();
	}
	
	void Update() {

		if (Input.GetKeyDown (KeyCode.P)) {

			if(Time.timeScale == 0.0f) Time.timeScale = 1.0f;
			else Time.timeScale = 0.0f;

		}

		//Debug.Log ("LADOOO - " + Grid.lado);
//		Debug.Log ("Rodandooo - " + CameraMove.rodandoEsquerda);

		// Move TELA Right
		if (Input.GetKeyDown(KeyCode.D) ) {
			
			if(Grid.lado == 1){
			// Remove old children from grid
				for (int y = 0; y < Grid.h; ++y)
					for (int x = 0; x < Grid.w; ++x)
						if (Grid.grid1[x, y] != null)
							if (Grid.grid1[x, y].parent == transform)
								Grid.grid1[x, y] = null;
						
				foreach (Transform child in transform) {
					Vector3 v = Grid.roundVec3(child.position);
						if(Grid.grid2[(int)v.x, (int)v.y] != null){
							// Instantiate Explosion
							Instantiate(explosionPrefab, transform.position, transform.rotation);							
							// Destroy the gameobject
							Destroy (gameObject);

							Grid.lado = 2;
							FindObjectOfType<Spawner>().changeSide();
							FindObjectOfType<Spawner>().spawnNext();
							break;
						}
						Grid.grid2[(int)v.x, (int)v.y] = child;
				}

				transformChildToZ(transform);
				Grid.lado = 2;

				// Spawn next Group
				FindObjectOfType<Spawner>().changeSide();
			}
			
			else if(Grid.lado == 2){
			// Remove old children from grid
				for (int y = 0; y < Grid.h; ++y)
					for (int x = 0; x < Grid.w; ++x)
						if (Grid.grid2[x, y] != null)
							if (Grid.grid2[x, y].parent == transform)
								Grid.grid2[x, y] = null;
						
				foreach (Transform child in transform) {
					Vector3 v = Grid.roundVec3(child.position);	
						float tranf = Grid.w - v.z - 1;
						tranf = Mathf.Abs (tranf);
						if(Grid.grid3[(int)tranf, (int)v.y] != null){
							// Instantiate Explosion
							Instantiate(explosionPrefab, transform.position, transform.rotation);							
							// Destroy the gameobject
							Destroy (gameObject);

							Grid.lado = 3;
							FindObjectOfType<Spawner>().changeSide();
							FindObjectOfType<Spawner>().spawnNext();
							break;
						}
						Grid.grid3[(int)tranf, (int)v.y] = child;
				}
				transformChildToX(transform);
				Grid.lado = 3;

				// Spawn next Group
				FindObjectOfType<Spawner>().changeSide();
			}
			
			else if(Grid.lado == 3){
			// Remove old children from grid
				for (int y = 0; y < Grid.h; ++y)
					for (int x = 0; x < Grid.w; ++x)
						if (Grid.grid3[x, y] != null)
							if (Grid.grid3[x, y].parent == transform)
								Grid.grid3[x, y] = null;
						
				foreach (Transform child in transform) {
					Vector3 v = Grid.roundVec3(child.position);
						if(Grid.grid4[(int)v.x, (int)v.y] != null){
							// Instantiate Explosion
							Instantiate(explosionPrefab, transform.position, transform.rotation);							
							// Destroy the gameobject
							Destroy (gameObject);
							Grid.lado = 4;
							FindObjectOfType<Spawner>().changeSide();
							FindObjectOfType<Spawner>().spawnNext();
							break;
						}					
						Grid.grid4[(int)v.x, (int)v.y] = child;
				}
				transformChildToZMenos(transform);
				Grid.lado = 4;

				// Spawn next Group
				FindObjectOfType<Spawner>().changeSide();
			}
			
			else if(Grid.lado == 4){
			// Remove old children from grid
				for (int y = 0; y < Grid.h; ++y)
					for (int x = 0; x < Grid.w; ++x)
						if (Grid.grid4[x, y] != null)
							if (Grid.grid4[x, y].parent == transform)
								Grid.grid4[x, y] = null;
						
				foreach (Transform child in transform) {
					Vector3 v = Grid.roundVec3(child.position);
						float tranf = v.z - Grid.w + 1;
						tranf = Mathf.Abs (tranf);
						if(Grid.grid1[(int)tranf, (int)v.y] != null){
							// Instantiate Explosion
							Instantiate(explosionPrefab, transform.position, transform.rotation);							
							// Destroy the gameobject
							Destroy (gameObject);
							Grid.lado = 1;
							FindObjectOfType<Spawner>().changeSide();
							FindObjectOfType<Spawner>().spawnNext();
							break;
						}						
						Grid.grid1[(int)tranf, (int)v.y] = child;
				}

				transformChildToXNormal(transform);
				Grid.lado = 1;

				// Spawn next Group
				FindObjectOfType<Spawner>().changeSide();
			}
		}
		
		// Move TELA Left
		if (Input.GetKeyDown(KeyCode.A) ) {
			
			if(Grid.lado == 1){
			// Remove old children from grid
				for (int y = 0; y < Grid.h; ++y)
					for (int x = 0; x < Grid.w; ++x)
						if (Grid.grid1[x, y] != null)
							if (Grid.grid1[x, y].parent == transform)
								Grid.grid1[x, y] = null;
						
				foreach (Transform child in transform) {
					Vector3 v = Grid.roundVec3(child.position);	
						float tranf = v.x - Grid.w + 1;
						tranf = Mathf.Abs (tranf);
						if(Grid.grid4[(int)tranf, (int)v.y] != null){
							// Instantiate Explosion
							Instantiate(explosionPrefab, transform.position, transform.rotation);							
							// Destroy the gameobject
							Destroy (gameObject);
							Grid.lado = 4;
							FindObjectOfType<Spawner>().changeSide();
							FindObjectOfType<Spawner>().spawnNext();
							break;
						}
						
						Grid.grid4[(int)tranf, (int)v.y] = child;
				}

				transformChildToFour(transform);
				Grid.lado = 4;
				
				// Spawn next Group
				FindObjectOfType<Spawner>().changeSide();
			}
			
			else if(Grid.lado == 2){
			// Remove old children from grid
				for (int y = 0; y < Grid.h; ++y)
					for (int x = 0; x < Grid.w; ++x)
						if (Grid.grid2[x, y] != null)
							if (Grid.grid2[x, y].parent == transform)
								Grid.grid2[x, y] = null;
						
				foreach (Transform child in transform) {
					Vector3 v = Grid.roundVec3(child.position);
						if(Grid.grid1[(int)v.z, (int)v.y] != null){
							// Instantiate Explosion
							Instantiate(explosionPrefab, transform.position, transform.rotation);							
							// Destroy the gameobject
							Destroy (gameObject);
							Grid.lado = 1;
							FindObjectOfType<Spawner>().changeSide();
							FindObjectOfType<Spawner>().spawnNext();
							break;
						}
						Grid.grid1[(int)v.z, (int)v.y] = child;
				}

				transformChildToThree(transform);
				Grid.lado = 1;
				
				// Spawn next Group
				FindObjectOfType<Spawner>().changeSide();
			}
			
			else if(Grid.lado == 3){
			// Remove old children from grid
				for (int y = 0; y < Grid.h; ++y)
					for (int x = 0; x < Grid.w; ++x)
						if (Grid.grid3[x, y] != null)
							if (Grid.grid3[x, y].parent == transform)
								Grid.grid3[x, y] = null;
						
				foreach (Transform child in transform) {
					Vector3 v = Grid.roundVec3(child.position);
						float tranf = Grid.w - v.x - 1;
						tranf = Mathf.Abs (tranf);
						if(Grid.grid2[(int)tranf, (int)v.y] != null){
							// Instantiate Explosion
							Instantiate(explosionPrefab, transform.position, transform.rotation);							
							// Destroy the gameobject
							Destroy (gameObject);
							Grid.lado = 2;
							FindObjectOfType<Spawner>().changeSide();
							FindObjectOfType<Spawner>().spawnNext();
							break;
						}
						
						Grid.grid2[(int)tranf, (int)v.y] = child;
				}

				transformChildToTwo(transform);
				Grid.lado = 2;
				
				// Spawn next Group
				FindObjectOfType<Spawner>().changeSide();
			}
			
			else if(Grid.lado == 4){
			// Remove old children from grid
				for (int y = 0; y < Grid.h; ++y)
					for (int x = 0; x < Grid.w; ++x)
						if (Grid.grid4[x, y] != null)
							if (Grid.grid4[x, y].parent == transform)
								Grid.grid4[x, y] = null;
						
				foreach (Transform child in transform) {
					Vector3 v = Grid.roundVec3(child.position);
						if(Grid.grid3[(int)v.z, (int)v.y] != null){
							// Instantiate Explosion
							Instantiate(explosionPrefab, transform.position, transform.rotation);							
							// Destroy the gameobject
							Destroy (gameObject);
							Grid.lado = 3;
							FindObjectOfType<Spawner>().changeSide();
							FindObjectOfType<Spawner>().spawnNext();
							break;
						}
						Grid.grid3[(int)v.z, (int)v.y] = child;
				}

				transformChildToOne(transform);
				Grid.lado = 3;
				
				// Spawn next Group
				FindObjectOfType<Spawner>().changeSide();
			}
		}
		
		// Move Left
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			// Modify position
			if(Grid.lado == 1)
				transform.position += new Vector3(-1, 0, 0);
			if(Grid.lado == 2)
				transform.position += new Vector3(0, 0, -1);
			if(Grid.lado == 3)
				transform.position += new Vector3(1, 0, 0);
			if(Grid.lado == 4)
				transform.position += new Vector3(0, 0, 1);
			
			// See if valid
			if (isValidGridPos())
				// It's valid. Update grid.
				updateGrid();
			else{
				if(Grid.lado == 1)
					transform.position += new Vector3(1, 0, 0);
				if(Grid.lado == 2 )
					transform.position += new Vector3(0, 0, 1);
				if(Grid.lado == 3 )
					transform.position += new Vector3(-1, 0, 0);
				if(Grid.lado == 4 )
					transform.position += new Vector3(0, 0, -1);
			}
			audio.Play ();
		}
		
		// Move Right
		else if (Input.GetKeyDown(KeyCode.RightArrow)) {
			if(Grid.lado == 1)
				transform.position += new Vector3(1, 0, 0);
			if(Grid.lado == 2)
				transform.position += new Vector3(0, 0, 1);
			if(Grid.lado == 3)
				transform.position += new Vector3(-1, 0, 0);
			if(Grid.lado == 4 )
				transform.position += new Vector3(0, 0, -1);
			
			// See if valid
			if (isValidGridPos())
				// It's valid. Update grid.
				updateGrid();
			else{
				if(Grid.lado == 1)
					transform.position += new Vector3(-1, 0, 0);
				if(Grid.lado == 2)
					transform.position += new Vector3(0, 0, -1);
				if(Grid.lado == 3)
					transform.position += new Vector3(1, 0, 0);
				if(Grid.lado == 4)
					transform.position += new Vector3(0, 0, 1);
			}
			audio.Play ();
		}
		
		// Rotate
		else if (Input.GetKeyDown(KeyCode.UpArrow)) {

			if(Grid.lado == 1 ||Grid.lado == 3)
				transform.Rotate(0, 0, -90);
			else if(Grid.lado == 2 ||Grid.lado == 4)
				transform.Rotate(0, 0, 90);
			
			// See if valid
			if (isValidGridPos())
				// It's valid. Update grid.
				updateGrid();
			else{
				if(Grid.lado == 1 ||Grid.lado == 3)
					transform.Rotate(0, 0, 90);
				else if(Grid.lado == 2 ||Grid.lado == 4)
					transform.Rotate(0,0, -90);
			}
			audio.Play ();

		}
		
		// Move Downwards and Fall
		else if (Input.GetKeyDown(KeyCode.DownArrow) ||
		         Time.time - lastFall >= 1) {
			// Modify position
			transform.position += new Vector3(0, -1, 0);

			//Debug.Log(isValidGridPos());
			// See if valid
			if (isValidGridPos()) {
				//Debug.Log("isValidGridPos - Move Down");
				// It's valid. Update grid.
				updateGrid();
				audio.Play ();
				//audio.PlayOneShot ((AudioClip)Resources.Load ("265385__b-lamerichs__sound-effects-01-03-2015-8-pops-2"));
			} else {
				// It's not valid. revert.
				transform.position += new Vector3(0, 1, 0);
				
				// Clear filled horizontal lines
				Grid.deleteFullRows();
				
				// Spawn next Group
				FindObjectOfType<Spawner>().spawnNext();
				
				// Disable script
				enabled = false;
			}
			
			lastFall = Time.time;
		}
	}

	bool isValidGridPos() {

		Debug.Log ("LADO --- " + Grid.lado);

		switch(Grid.lado){
			case 1:
				int childint = 0;
				foreach (Transform child in transform) {
					Vector3 v = Grid.roundVec3(child.position);
					Debug.Log ("child int " + childint);
					Debug.Log(" FUNÇAO 0 " + child.position.x + "  " + child.position.y + " " + child.position.z);

					// Not inside Border?
				    Debug.Log(" FUNÇAO 1 " + Grid.insideBorder(v));
					if (!Grid.insideBorder(v))
						return false;
					
					Debug.Log(" FUNÇAO 2 " + (Grid.grid1[(int)v.x, (int)v.y] != null &&
				                          Grid.grid1[(int)v.x, (int)v.y].parent != transform));
					// Block in grid cell (and not part of same group)?
					if (Grid.grid1[(int)v.x, (int)v.y] != null &&
						Grid.grid1[(int)v.x, (int)v.y].parent != transform)
						return false;
					childint++;
				}
				//return true;
				break;
			case 2:
				foreach (Transform child in transform) {
					Vector3 v = Grid.roundVec3(child.position);
					
					// Not inside Border?
					if (!Grid.insideBorder(v))
						return false;
					
					// Block in grid cell (and not part of same group)?
					if (Grid.grid2[(int)v.z, (int)v.y] != null &&
						Grid.grid2[(int)v.z, (int)v.y].parent != transform)
						return false;
				}
				break;
				//return true;
			case 3:
				foreach (Transform child in transform) {
					Vector3 v = Grid.roundVec3(child.position);
					
					// Not inside Border?
					if (!Grid.insideBorder(v))
						return false;
					
					// Block in grid cell (and not part of same group)?
					if (Grid.grid3[(int)v.x, (int)v.y] != null &&
						Grid.grid3[(int)v.x, (int)v.y].parent != transform)
						return false;
				}
				break;
				//return true;
			case 4:
				foreach (Transform child in transform) {
					Vector3 v = Grid.roundVec3(child.position);
					
					// Not inside Border?
					if (!Grid.insideBorder(v))
						return false;
					
					// Block in grid cell (and not part of same group)?
					if (Grid.grid4[(int)v.z, (int)v.y] != null &&
						Grid.grid4[(int)v.z, (int)v.y].parent != transform)
						return false;
				}
				//return true;
				break;
		}

		return true;
	}

	void updateGrid() {
		
		switch(Grid.lado){
			
			case 1:
				// Remove old children from grid
				for (int y = 0; y < Grid.h; ++y)
					for (int x = 0; x < Grid.w; ++x)
						if (Grid.grid1[x, y] != null)
							if (Grid.grid1[x, y].parent == transform)
								Grid.grid1[x, y] = null;
				
				// Add new children to grid
				foreach (Transform child in transform) {
					Vector3 v = Grid.roundVec3(child.position);
					Grid.grid1[(int)v.x, (int)v.y] = child;
				}
				break;
				
			case 2:
				// Remove old children from grid
				for (int y = 0; y < Grid.h; ++y)
					for (int x = 0; x < Grid.w; ++x)
						if (Grid.grid2[x, y] != null)
							if (Grid.grid2[x, y].parent == transform)
								Grid.grid2[x, y] = null;
				
				// Add new children to grid
				foreach (Transform child in transform) {
					Vector3 v = Grid.roundVec3(child.position);
					Grid.grid2[(int)v.z, (int)v.y] = child;
				}
				break;
				
			case 3:
				// Remove old children from grid
				for (int y = 0; y < Grid.h; ++y)
					for (int x = 0; x < Grid.w; ++x)
						if (Grid.grid3[x, y] != null)
							if (Grid.grid3[x, y].parent == transform)
								Grid.grid3[x, y] = null;
				
				// Add new children to grid
				foreach (Transform child in transform) {
					Vector3 v = Grid.roundVec3(child.position);
					Grid.grid3[(int)v.x, (int)v.y] = child;
				}
				break;
				
			case 4:
				// Remove old children from grid
				for (int y = 0; y < Grid.h; ++y)
					for (int x = 0; x < Grid.w; ++x)
						if (Grid.grid4[x, y] != null)
							if (Grid.grid4[x, y].parent == transform)
								Grid.grid4[x, y] = null;
				
				// Add new children to grid
				foreach (Transform child in transform) {
					Vector3 v = Grid.roundVec3(child.position);
					Grid.grid4[(int)v.z, (int)v.y] = child;
				}
				break;
		}		
	}

	void transformChildToZ(Transform t){
		t.Rotate (new Vector3 (0, -90, 0), Space.World);
		transform.position = new Vector3 (10, transform.position.y, transform.position.x);
	}

	void transformChildToZMenos(Transform t){		
		t.Rotate (new Vector3 (0, -90, 0), Space.World);
		transform.position = new Vector3 (-1, transform.position.y, transform.position.x);
	}

	void transformChildToX(Transform t){		
		t.Rotate (new Vector3 (0, -90,0), Space.World);

		float tranf = Grid.w - transform.position.z - 1;

		transform.position = new Vector3 (tranf, transform.position.y,10);
	}

	void transformChildToXNormal(Transform t){		
		t.Rotate (new Vector3 (0, -90, 0), Space.World);

		float tranf = transform.position.z - Grid.w + 1;
		tranf = Mathf.Abs (tranf);

		transform.position = new Vector3 (tranf, transform.position.y,-1);
	}

	void transformChildToOne(Transform t){		
		t.Rotate (new Vector3 (0, 90, 0), Space.World);
		transform.position = new Vector3 (transform.position.z, transform.position.y,10);
	}

	void transformChildToTwo(Transform t){		
		t.Rotate (new Vector3 (0, 90, 0), Space.World);

		float tranf = Grid.w - transform.position.x - 1;
		tranf = Mathf.Abs (tranf);

		transform.position = new Vector3 (10, transform.position.y,tranf);
	}

	void transformChildToThree(Transform t){		
		t.Rotate (new Vector3 (0, 90, 0), Space.World);
		transform.position = new Vector3 (transform.position.z, transform.position.y,-1);
	}

	void transformChildToFour(Transform t){		
		t.Rotate (new Vector3 (0, 90, 0), Space.World);

		float tranf = transform.position.x - Grid.w + 1;
		tranf = Mathf.Abs (tranf);

		transform.position = new Vector3 (-1,transform.position.y,tranf);
	}
}

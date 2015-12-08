using UnityEngine;
using System.Collections;

public class Group : MonoBehaviour {

	float lastFall;
	
	public GameObject explosionPrefab;

	// Use this for initialization
	void Start () {
		// Default position not valid? Then it's game over
		if (!isValidGridPos()) {
			Debug.Log("GAME OVER");
			Destroy(gameObject);
		}
	}
	
	void Update() {

		if (Input.GetKeyDown (KeyCode.P)) {

			if(Time.timeScale == 0.0f) Time.timeScale = 1.0f;
			else Time.timeScale = 0.0f;

		}

		//Debug.Log ("LADOOO - " + Grid.lado);

		// Move TELA Right
		if (Input.GetKeyDown(KeyCode.D)) {
			
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
						if(Grid.grid3[(int)v.z, (int)v.y] != null){
							// Instantiate Explosion
							Instantiate(explosionPrefab, transform.position, transform.rotation);							
							// Destroy the gameobject
							Destroy (gameObject);
							break;
						}

						float tranf = Grid.w - v.z - 1;
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
						if(Grid.grid1[(int)v.z, (int)v.y] != null){
							// Instantiate Explosion
							Instantiate(explosionPrefab, transform.position, transform.rotation);							
							// Destroy the gameobject
							Destroy (gameObject);
							break;
						}

						float tranf = v.z - Grid.w + 1;
						tranf = Mathf.Abs (tranf);
						Grid.grid1[(int)v.z, (int)v.y] = child;
				}

				transformChildToXNormal(transform);
				Grid.lado = 1;

				// Spawn next Group
				FindObjectOfType<Spawner>().changeSide();
			}
		}
		
		// Move TELA Left
		if (Input.GetKeyDown(KeyCode.A)) {
			
			if(Grid.lado == 1){
			// Remove old children from grid
				for (int y = 0; y < Grid.h; ++y)
					for (int x = 0; x < Grid.w; ++x)
						if (Grid.grid1[x, y] != null)
							if (Grid.grid1[x, y].parent == transform)
								Grid.grid1[x, y] = null;
						
				foreach (Transform child in transform) {
					Vector3 v = Grid.roundVec3(child.position);	
						if(Grid.grid4[(int)v.x, (int)v.y] != null){
							// Instantiate Explosion
							Instantiate(explosionPrefab, transform.position, transform.rotation);							
							// Destroy the gameobject
							Destroy (gameObject);
							break;
						}
						Grid.grid4[(int)v.x, (int)v.y] = child;
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
						if(Grid.grid2[(int)v.x, (int)v.y] != null){
							// Instantiate Explosion
							Instantiate(explosionPrefab, transform.position, transform.rotation);							
							// Destroy the gameobject
							Destroy (gameObject);
							break;
						}
						Grid.grid2[(int)v.x, (int)v.y] = child;
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

		}
		
		// Move Downwards and Fall
		else if (Input.GetKeyDown(KeyCode.DownArrow) ||
		         Time.time - lastFall >= 1) {
			// Modify position
			transform.position += new Vector3(0, -1, 0);

			Debug.Log(isValidGridPos());
			// See if valid
			if (isValidGridPos()) {
				Debug.Log("isValidGridPos - Move Down");
				// It's valid. Update grid.
				updateGrid();
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

		switch(Grid.lado){
			case 1:
				foreach (Transform child in transform) {
					Vector3 v = Grid.roundVec3(child.position);

					// Not inside Border?
				    //Debug.Log(Grid.insideBorder(v));
					if (!Grid.insideBorder(v))
						return false;
					
					// Block in grid cell (and not part of same group)?
					if (Grid.grid1[(int)v.x, (int)v.y] != null &&
						Grid.grid1[(int)v.x, (int)v.y].parent != transform)
						return false;
				}
				return true;
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
				return true;
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
				return true;
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
				return true;
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
		transform.position = new Vector3 (0, transform.position.y, transform.position.x);
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

		transform.position = new Vector3 (tranf, transform.position.y,0);
	}

	void transformChildToOne(Transform t){		
		t.Rotate (new Vector3 (0, 90, 0), Space.World);
		transform.position = new Vector3 (transform.position.z, transform.position.y,10);
	}

	void transformChildToTwo(Transform t){		
		t.Rotate (new Vector3 (0, 90, 0), Space.World);
		transform.position = new Vector3 (10, transform.position.y,transform.position.x);
	}

	void transformChildToThree(Transform t){		
		t.Rotate (new Vector3 (0, 90, 0), Space.World);
		transform.position = new Vector3 (transform.position.z, transform.position.y,0);
	}

	void transformChildToFour(Transform t){		
		t.Rotate (new Vector3 (0, 90, 0), Space.World);
		transform.position = new Vector3 (0,transform.position.y,transform.position.x);
	}
}

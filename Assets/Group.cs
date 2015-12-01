using UnityEngine;
using System.Collections;

public class Group : MonoBehaviour {

	float lastFall;
	
	public Prefab explosionPrefab;

	// Use this for initialization
	void Start () {
		// Default position not valid? Then it's game over
		if (!isValidGridPos()) {
			Debug.Log("GAME OVER");
			Destroy(gameObject);
		}
	}
	
	void Update() {
		
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
					Vector2 v = Grid.roundVec2(child.position);
						if(Grid.grid2[(int)v.x, (int)v.y] != null){
							// Instantiate Explosion
							Instantiate(explosionPrefab, transform.position, transform.rotation);							
							// Destroy the gameobject
							Destroy (gameObject);
							break;
						}
						Grid.grid2[(int)v.x, (int)v.y] = child;
				}
			}
			
			if(Grid.lado == 2){
			// Remove old children from grid
				for (int y = 0; y < Grid.h; ++y)
					for (int x = 0; x < Grid.w; ++x)
						if (Grid.grid2[x, y] != null)
							if (Grid.grid2[x, y].parent == transform)
								Grid.grid2[x, y] = null;
						
				foreach (Transform child in transform) {
					Vector2 v = Grid.roundVec2(child.position);	
						if(Grid.grid3[(int)v.x, (int)v.y] != null){
							// Instantiate Explosion
							Instantiate(explosionPrefab, transform.position, transform.rotation);							
							// Destroy the gameobject
							Destroy (gameObject);
							break;
						}
						Grid.grid3[(int)v.x, (int)v.y] = child;
				}
			}
			
			if(Grid.lado == 3){
			// Remove old children from grid
				for (int y = 0; y < Grid.h; ++y)
					for (int x = 0; x < Grid.w; ++x)
						if (Grid.grid2[x, y] != null)
							if (Grid.grid3[x, y].parent == transform)
								Grid.grid3[x, y] = null;
						
				foreach (Transform child in transform) {
					Vector2 v = Grid.roundVec2(child.position);
						if(Grid.grid4[(int)v.x, (int)v.y] != null){
							// Instantiate Explosion
							Instantiate(explosionPrefab, transform.position, transform.rotation);							
							// Destroy the gameobject
							Destroy (gameObject);
							break;
						}					
						Grid.grid4[(int)v.x, (int)v.y] = child;
				}
			}
			
			if(Grid.lado == 4){
			// Remove old children from grid
				for (int y = 0; y < Grid.h; ++y)
					for (int x = 0; x < Grid.w; ++x)
						if (Grid.grid2[x, y] != null)
							if (Grid.grid4[x, y].parent == transform)
								Grid.grid4[x, y] = null;
						
				foreach (Transform child in transform) {
					Vector2 v = Grid.roundVec2(child.position);
						if(Grid.grid1[(int)v.x, (int)v.y] != null){
							// Instantiate Explosion
							Instantiate(explosionPrefab, transform.position, transform.rotation);							
							// Destroy the gameobject
							Destroy (gameObject);
							break;
						}					
						Grid.grid1[(int)v.x, (int)v.y] = child;
				}
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
					Vector2 v = Grid.roundVec2(child.position);	
						if(Grid.grid4[(int)v.x, (int)v.y] != null){
							// Instantiate Explosion
							Instantiate(explosionPrefab, transform.position, transform.rotation);							
							// Destroy the gameobject
							Destroy (gameObject);
							break;
						}
						Grid.grid4[(int)v.x, (int)v.y] = child;
				}
			}
			
			if(Grid.lado == 2){
			// Remove old children from grid
				for (int y = 0; y < Grid.h; ++y)
					for (int x = 0; x < Grid.w; ++x)
						if (Grid.grid2[x, y] != null)
							if (Grid.grid2[x, y].parent == transform)
								Grid.grid2[x, y] = null;
						
				foreach (Transform child in transform) {
					Vector2 v = Grid.roundVec2(child.position);
						if(Grid.grid1[(int)v.x, (int)v.y] != null){
							// Instantiate Explosion
							Instantiate(explosionPrefab, transform.position, transform.rotation);							
							// Destroy the gameobject
							Destroy (gameObject);
							break;
						}
						Grid.grid1[(int)v.x, (int)v.y] = child;
				}
			}
			
			if(Grid.lado == 3){
			// Remove old children from grid
				for (int y = 0; y < Grid.h; ++y)
					for (int x = 0; x < Grid.w; ++x)
						if (Grid.grid2[x, y] != null)
							if (Grid.grid3[x, y].parent == transform)
								Grid.grid3[x, y] = null;
						
				foreach (Transform child in transform) {
					Vector2 v = Grid.roundVec2(child.position);
						if(Grid.grid2[(int)v.x, (int)v.y] != null){
							// Instantiate Explosion
							Instantiate(explosionPrefab, transform.position, transform.rotation);							
							// Destroy the gameobject
							Destroy (gameObject);
							break;
						}
						Grid.grid2[(int)v.x, (int)v.y] = child;
				}
			}
			
			if(Grid.lado == 4){
			// Remove old children from grid
				for (int y = 0; y < Grid.h; ++y)
					for (int x = 0; x < Grid.w; ++x)
						if (Grid.grid2[x, y] != null)
							if (Grid.grid4[x, y].parent == transform)
								Grid.grid4[x, y] = null;
						
				foreach (Transform child in transform) {
					Vector2 v = Grid.roundVec2(child.position);
						if(Grid.grid3[(int)v.x, (int)v.y] != null){
							// Instantiate Explosion
							Instantiate(explosionPrefab, transform.position, transform.rotation);							
							// Destroy the gameobject
							Destroy (gameObject);
							break;
						}
						Grid.grid3[(int)v.x, (int)v.y] = child;
				}
			}
			
		}
		
		// Move Left
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			// Modify position
			transform.position += new Vector3(-1, transform.position.y, transform.position.z);
			
			// See if valid
			if (isValidGridPos())
				// It's valid. Update grid.
				updateGrid();
			else
				// It's not valid. revert.
				transform.position += new Vector3(1, transform.position.y, transform.position.z);
		}
		
		// Move Right
		else if (Input.GetKeyDown(KeyCode.RightArrow)) {
			// Modify position
			transform.position += new Vector3(1, transform.position.y, transform.position.z);
			
			// See if valid
			if (isValidGridPos())
				// It's valid. Update grid.
				updateGrid();
			else
				// It's not valid. revert.
				transform.position += new Vector3(-1, transform.position.y, transform.position.z);
		}
		
		// Rotate
		else if (Input.GetKeyDown(KeyCode.UpArrow)) {
			transform.Rotate(transform.rotation.x, transform.rotation.y, -90);
			
			// See if valid
			if (isValidGridPos())
				// It's valid. Update grid.
				updateGrid();
			else
				// It's not valid. revert.
				transform.Rotate(transform.rotation.x, transform.rotation.y, 90);
		}
		
		// Move Downwards and Fall
		else if (Input.GetKeyDown(KeyCode.DownArrow) ||
		         Time.time - lastFall >= 1) {
			// Modify position
			transform.position += new Vector3(transform.position.x, -1, transform.position.z);
			
			// See if valid
			if (isValidGridPos()) {
				// It's valid. Update grid.
				updateGrid();
			} else {
				// It's not valid. revert.
				transform.position += new Vector3(transform.position.x, 1, transform.position.z);
				
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
					Vector2 v = Grid.roundVec2(child.position);
					
					// Not inside Border?
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
					Vector2 v = Grid.roundVec2(child.position);
					
					// Not inside Border?
					if (!Grid.insideBorder(v))
						return false;
					
					// Block in grid cell (and not part of same group)?
					if (Grid.grid2[(int)v.x, (int)v.y] != null &&
						Grid.grid2[(int)v.x, (int)v.y].parent != transform)
						return false;
				}
				return true;
			case 3:
				foreach (Transform child in transform) {
					Vector2 v = Grid.roundVec2(child.position);
					
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
					Vector2 v = Grid.roundVec2(child.position);
					
					// Not inside Border?
					if (!Grid.insideBorder(v))
						return false;
					
					// Block in grid cell (and not part of same group)?
					if (Grid.grid4[(int)v.x, (int)v.y] != null &&
						Grid.grid4[(int)v.x, (int)v.y].parent != transform)
						return false;
				}
				return true;
		}
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
					Vector2 v = Grid.roundVec2(child.position);
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
					Vector2 v = Grid.roundVec2(child.position);
					Grid.grid2[(int)v.x, (int)v.y] = child;
				}
				break;
				
			case 3:
				// Remove old children from grid
				for (int y = 0; y < Grid.h; ++y)
					for (int x = 0; x < Grid.w; ++x)
						if (Grid.grid[x, y] != null)
							if (Grid.grid3[x, y].parent == transform)
								Grid.grid3[x, y] = null;
				
				// Add new children to grid
				foreach (Transform child in transform) {
					Vector2 v = Grid.roundVec2(child.position);
					Grid.grid3[(int)v.x, (int)v.y] = child;
				}
				break;
				
			case 4:
				// Remove old children from grid
				for (int y = 0; y < Grid.h; ++y)
					for (int x = 0; x < Grid.w; ++x)
						if (Grid.grid[x, y] != null)
							if (Grid.grid4[x, y].parent == transform)
								Grid.grid4[x, y] = null;
				
				// Add new children to grid
				foreach (Transform child in transform) {
					Vector2 v = Grid.roundVec2(child.position);
					Grid.grid4[(int)v.x, (int)v.y] = child;
				}
				break;
		}		
	}
}

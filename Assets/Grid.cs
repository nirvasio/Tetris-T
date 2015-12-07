using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	// The Grid itself
	public static int w = 10;
	public static int h = 20;
	public static int lado = 1;
	
	public static Transform[,] grid1 = new Transform[w, h];
	public static Transform[,] grid2 = new Transform[w, h];
	public static Transform[,] grid3 = new Transform[w, h];
	public static Transform[,] grid4 = new Transform[w, h];

	public static Vector2 roundVec2(Vector2 v) {
		return new Vector2(Mathf.Round(v.x),
		                   Mathf.Round(v.y));
	}

	public static Vector3 roundVec3(Vector3 v) {
		return new Vector3(Mathf.Round(v.x),
		                   Mathf.Round(v.y),
		                   Mathf.Round(v.z));
	}

	public static bool insideBorder(Vector3 pos) {

		if (lado == 1 || lado == 3) {
			return ((int)pos.x >= 0 &&
				(int)pos.x < w &&
				(int)pos.y >= 0);
		} else {
			return ((int)pos.z >= 0 &&
			        (int)pos.z < w &&
			        (int)pos.y >= 0);
		}
	}

	public static void deleteRow(int y) {
		for (int x = 0; x < w; ++x) {
					Destroy(grid1[x, y].gameObject);
					grid1[x, y] = null;
					Destroy(grid2[x, y].gameObject);
					grid2[x, y] = null;
					Destroy(grid3[x, y].gameObject);
					grid3[x, y] = null;
					Destroy(grid4[x, y].gameObject);
					grid4[x, y] = null;
			}		

	}

	public static void decreaseRow(int y) {
		for (int x = 0; x < w; ++x) {
					if (grid1[x, y] != null) {
						// Move one towards bottom
						grid1[x, y-1] = grid1[x, y];
						grid1[x, y] = null;
						
						// Update Block position
						grid1[x, y-1].position += new Vector3(0, -1, 0);
					}
					if (grid2[x, y] != null) {
						// Move one towards bottom
						grid2[x, y-1] = grid2[x, y];
						grid2[x, y] = null;
						
						// Update Block position
						grid2[x, y-1].position += new Vector3(0, -1, 0);
					}
					if (grid3[x, y] != null) {
						// Move one towards bottom
						grid3[x, y-1] = grid3[x, y];
						grid3[x, y] = null;
						
						// Update Block position
						grid3[x, y-1].position += new Vector3(0, -1, 0);
					}
					if (grid4[x, y] != null) {
						// Move one towards bottom
						grid4[x, y-1] = grid4[x, y];
						grid4[x, y] = null;
						
						// Update Block position
						grid4[x, y-1].position += new Vector3(0, -1, 0);
					}			
			}	
	}
					

	public static void decreaseRowsAbove(int y) {
		for (int i = y; i < h; ++i)
			decreaseRow(i);
	}

	public static bool isRowFull(int y) {
		for (int x = 0; x < w; ++x){

					if (grid1[x, y] == null)
						return false;

					if (grid2[x, y] == null)
						return false;

					if (grid3[x, y] == null)
						return false;

					if (grid4[x, y] == null)
						return false;
			}				
			
					
		return true;
	}

	public static void deleteFullRows() {
		for (int y = 0; y < h; ++y) {
			if (isRowFull(y)) {
				deleteRow(y);
				decreaseRowsAbove(y+1);
				--y;
			}
		}
	}

}

using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	// The Grid itself
	public static int w = 10;
	public static int h = 20;
	public static lado = 1;
	
	public static Transform[,] grid1 = new Transform[w, h];
	public static Transform[,] grid2 = new Transform[w, h];
	public static Transform[,] grid3 = new Transform[w, h];
	public static Transform[,] grid4 = new Transform[w, h];

	public static Vector2 roundVec2(Vector2 v) {
		return new Vector2(Mathf.Round(v.x),
		                   Mathf.Round(v.y));
	}

	public static bool insideBorder(Vector2 pos) {
		return ((int)pos.x >= 0 &&
		        (int)pos.x < w &&
		        (int)pos.y >= 0);
	}

	public static void deleteRow(int y) {
		for (int x = 0; x < w; ++x) {
			switch(lado){
				case 1:
					Destroy(grid1[x, y].gameObject);
					grid1[x, y] = null;
					break;
				case 2:
					Destroy(grid2[x, y].gameObject);
					grid2[x, y] = null;
					break;
				case 3:
					Destroy(grid3[x, y].gameObject);
					grid3[x, y] = null;
					break;
				case 4:
					Destroy(grid4[x, y].gameObject);
					grid4[x, y] = null;
					break;
			}		
		}
	}

	public static void decreaseRow(int y) {
		for (int x = 0; x < w; ++x) {
			switch(lado){
				case 1:
					if (grid1[x, y] != null) {
						// Move one towards bottom
						grid1[x, y-1] = grid1[x, y];
						grid1[x, y] = null;
						
						// Update Block position
						grid1[x, y-1].position += new Vector3(0, -1, 0);
					}
					break;
				case 2:
					if (grid2[x, y] != null) {
						// Move one towards bottom
						grid2[x, y-1] = grid2[x, y];
						grid2[x, y] = null;
						
						// Update Block position
						grid[x, y-1].position += new Vector3(0, -1, 0);
					}
					break;
				case 3:
					if (grid3[x, y] != null) {
						// Move one towards bottom
						grid3[x, y-1] = grid3[x, y];
						grid3[x, y] = null;
						
						// Update Block position
						grid3[x, y-1].position += new Vector3(0, -1, 0);
					}
					break;
				case 4:
					if (grid3[x, y] != null) {
						// Move one towards bottom
						grid4[x, y-1] = grid4[x, y];
						grid4[x, y] = null;
						
						// Update Block position
						grid4[x, y-1].position += new Vector3(0, -1, 0);
					}
					break;				
			}		
		}
	}
					

	public static void decreaseRowsAbove(int y) {
		for (int i = y; i < h; ++i)
			decreaseRow(i);
	}

	public static bool isRowFull(int y) {
		for (int x = 0; x < w; ++x){
			switch(lado){
				case 1:	
					if (grid1[x, y] == null)
						return false;
					break;
				case 2:
					if (grid2[x, y] == null)
						return false;
					break;
				case 3:
					if (grid3[x, y] == null)
						return false;
					break;
				case 4:	
					if (grid4[x, y] == null)
						return false;
					break;
			}				
			
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

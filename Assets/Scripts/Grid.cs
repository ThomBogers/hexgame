using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {
    public int height;
    public int width;

    public float cellSize;
    
    public Cell cellPrefab;

    Cell[] cells;

    // Use this for initialization
	void Awake ()
    {
        cells = new Cell[height * width];

        for (int z = 0, i = 0; z < height; z++) {
            for (int x = 0; x < width; x++) {
                CreateCell(x, z, i++);
            }
        }
    }




    void CreateCell(int x, int z, int index) {
        Vector3 position = CellCoordinates.getPositionFromCoordinate(x,z);
        Quaternion rotation = new Quaternion();

        Cell cell = cells[index] = Instantiate<Cell>(cellPrefab, position, rotation);

        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;
        cell.index = index;
        cell.x = x;
        cell.z = z;

    }
    // Update is called once per frame
    void Update () {
		
	}
}

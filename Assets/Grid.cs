using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {
    public int height;
    public int width;
    
    public float buffer = 1f;

    public Cell cellPrefab;

    Cell[] cells;

    // Use this for initialization
	void Start () {
        cells = new Cell[height * width];

        for (int z = 0, i = 0; z < height; z++) {
            for (int x = 0; x < width; x++) {
                CreateCell(x, z, i++);
            }
        }
    }

    void CreateCell(int x, int z, int index) {
        Vector3 position; 
        position.x = x * 10f + buffer;
        position.z = z * 10f +buffer;
        position.y = 0f;

        Cell cell = cells[index] = Instantiate<Cell>(cellPrefab);
        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;
    }
    // Update is called once per frame
    void Update () {
		
	}
}

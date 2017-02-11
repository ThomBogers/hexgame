using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {
    public int height;
    public int width;
    
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

        float offset = 2.5f;
        float buffer = 1.0f;
        if(z%2 != 0) {
            offset = -offset;
        }

        position.x = x * 10f + x*buffer + offset;
        position.z = z * 10f + z*buffer;
        position.y = 0f;

        Cell cell = cells[index] = Instantiate<Cell>(cellPrefab);
        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;
    }
    // Update is called once per frame
    void Update () {
		
	}
}

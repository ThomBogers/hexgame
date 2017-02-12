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
        Quaternion rotation = new Quaternion();

        cellPrefab.setSize(cellSize);
        float innerRadius = cellPrefab.getInnerRadius();
        float outerRadius = cellPrefab.getOuterRadius();

        float offset = 0.0f;
        if (x%2 != 0) {
            offset = innerRadius;
        }

        position.x = x * outerRadius * 1.5f;
        position.z = z * innerRadius * 2.0f + offset;
        position.y = 0f;

        Cell cell = cells[index] = Instantiate<Cell>(cellPrefab, position, rotation);

        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;
        cell.index = index;

    }
    // Update is called once per frame
    void Update () {
		
	}
}

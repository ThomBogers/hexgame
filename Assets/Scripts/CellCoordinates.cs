using UnityEngine;

public class CellCoordinates {
    public int x;
    public int z;
    public int y;

    public CellCoordinates(int x, int z, int y)
    {
        this.x = x;
        this.z = z;
        this.y = y;
    }

    static public CellCoordinates getCoordinatesFromPostion(Vector3 position) {
        int x = Mathf.RoundToInt((position.x / 1.5f) / CellMetrics.outerRadius);
        float offset = 0.0f;
        if (x % 2 != 0)
        {
            offset = CellMetrics.innerRadius;
        }
        
        int z = Mathf.RoundToInt(((position.z - offset)/2.0f)/CellMetrics.innerRadius);
        int y = 0;

        return new CellCoordinates(x, z, y);
    }

    static public Vector3 getPositionFromCoordinate(int x, int z)
    {
        Vector3 position;

        float innerRadius = CellMetrics.innerRadius;
        float outerRadius = CellMetrics.outerRadius;

        float offset = 0.0f;
        if (x % 2 != 0)
        {
            offset = innerRadius;
        }

        position.x = x * outerRadius * 1.5f;
        position.z = z * innerRadius * 2.0f + offset;
        position.y = 0f;
        return position;
    }
}

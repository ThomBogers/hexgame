using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {

    public Color color;
    public int index;
    
    // Use this for initialization
    void Start () {
        Mesh mesh = CreateHexMesh(CellMetrics.size, CellMetrics.outerRadius, CellMetrics.innerRadius);

        gameObject.name = "HexCell " + this.index;

        MeshFilter meshFilter = gameObject.AddComponent(typeof(MeshFilter)) as MeshFilter;
        meshFilter.mesh = mesh;
        
        MeshCollider collider = gameObject.AddComponent(typeof(MeshCollider)) as MeshCollider;
        collider.sharedMesh = mesh;
        collider.convex = true;

        MeshRenderer renderer = gameObject.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
        renderer.material.shader = Shader.Find("Unlit/Color");

        float r;
        float g;
        float b;

        if (this.index % 2 == 0)
        {
            r = 0.0f; //Random.Range(0f, 1f);
            g = 1.0f - 0.008f * index; //Random.Range(0f, 1f);
            b = 0.0f;//Random.Range(0f, 1f);
        }
        else
        {
            r = 0.0f;//Random.Range(0f, 1f);
            g = 0.0f; //Random.Range(0f, 1f);
            b = 1.0f - 0.008f * index; //Random.Range(0f, 1f);
        }
        float a = 0f;
        this.color = new Color(r, g, b, a);

        Texture2D texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, this.color);
        texture.Apply();
        renderer.material.mainTexture = texture;

        renderer.material.color = this.color;

        GameObject textobj = new GameObject();
        textobj.layer = 5; //Background texts
        textobj.name = "HexCell "+ this.index +" text";
        TextMesh textmesh = textobj.AddComponent(typeof(TextMesh)) as TextMesh;
        textmesh.text = this.index.ToString();
        textmesh.fontSize = 50;
        textmesh.color = Color.black;
        textobj.transform.SetParent(gameObject.transform, false);
        textobj.transform.Translate(-3.0f, 0.0f, 3.0f);
        textobj.transform.Rotate(90.0f, 0.0f, 0.0f);


    }

    // Update is called once per frame
    void Update ()
    {

        gameObject.GetComponent<Renderer>().material.color = this.color;
    }

    Mesh CreateSquareMesh(float size)
    {
        float width = size;
        float depth = size;
        float height = 0.0f;

        Mesh m = new Mesh();
        m.name = "SwuareMesh";
        m.vertices = new Vector3[] {
            new Vector3(-width, height, -depth),
            new Vector3(width,  height, -depth),
            new Vector3(width,  height, depth),
            new Vector3(-width, height, depth)
        };

        m.triangles = new int[] { 2, 1, 0, 3, 2, 0};
        m.RecalculateNormals();

        return m;
    }

    Mesh CreateHexMesh(float size, float outerRadius, float innerRadius) {
        float height = 0.0f;

        Mesh m = new Mesh();
        m.name = "HexMesh";

        m.vertices = new Vector3[] {
            new Vector3(0.0f,             height, 0.0f),
            new Vector3((-outerRadius/2), height, innerRadius),
            new Vector3((outerRadius/2),  height, innerRadius),
            new Vector3(outerRadius,      height, 0.0f),
            new Vector3((outerRadius/2),  height, (-innerRadius)),
            new Vector3((-outerRadius/2), height, (-innerRadius)),
            new Vector3((-outerRadius),   height, 0.0f),
        };

        m.triangles = new int[] {
            0,1,2,
            0,2,3,
            0,3,4,
            0,4,5,
            0,5,6,
            0,6,1
        };
        m.RecalculateNormals();

        return m;
    }

}

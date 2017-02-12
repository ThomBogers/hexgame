using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {


    public Color color;

    // Use this for initialization
    void Awake () {
        Mesh mesh = CreateMesh(5.0f, 0.0f, 5.0f);

        gameObject.name = "HexCell";

        MeshFilter meshFilter = gameObject.AddComponent(typeof(MeshFilter)) as MeshFilter;
        meshFilter.mesh = mesh;
        
        MeshCollider collider = gameObject.AddComponent(typeof(MeshCollider)) as MeshCollider;
        collider.sharedMesh = mesh;
        collider.convex = true;

        MeshRenderer renderer = gameObject.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
        renderer.material.shader = Shader.Find("Unlit/Color");

        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        float a = 0f;
        color = new Color(r, g, b, a);

        Texture2D texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, color);
        texture.Apply();
        renderer.material.mainTexture = texture;

        renderer.material.color = color;

    }

    // Update is called once per frame
    void Update ()
    {
        //gameObject.GetComponent<Renderer>().material.color = color;

    }

    Mesh CreateMesh(float width, float height, float depth)
    {
        Mesh m = new Mesh();
        m.name = "HexMesh";
        m.vertices = new Vector3[] {
         new Vector3(-width, height, -depth),
         new Vector3(width,  height, -depth),
         new Vector3(width,  height, depth),
         new Vector3(-width, height, depth)
     };
        m.uv = new Vector2[] {
         new Vector2 (0, 0),
         new Vector2 (0, 1),
         new Vector2(1, 1),
         new Vector2 (1, 0)
     };
        m.triangles = new int[] { 2, 1, 0, 3, 2, 0};
        m.RecalculateNormals();

        return m;
    }

}

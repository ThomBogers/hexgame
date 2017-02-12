﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {


    public Color color;
    public float cellSize;
    public float outerRadius;
    public float innerRadius;
    public int index;
    
    public void setSize(float size) {
        this.cellSize = size;
        this.outerRadius = size / 2;
        this.innerRadius = outerRadius * 0.866025404f;
    }

    internal float getOuterRadius()
    {
        return this.outerRadius;
    }
    

    internal float getInnerRadius()
    {
        return this.innerRadius;
    }

    // Use this for initialization
    void Awake () {
        Mesh mesh = CreateHexMesh(cellSize);

        gameObject.name = "HexCell";

        MeshFilter meshFilter = gameObject.AddComponent(typeof(MeshFilter)) as MeshFilter;
        meshFilter.mesh = mesh;
        
        MeshCollider collider = gameObject.AddComponent(typeof(MeshCollider)) as MeshCollider;
        collider.sharedMesh = mesh;
        collider.convex = true;

        MeshRenderer renderer = gameObject.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
        renderer.material.shader = Shader.Find("Unlit/Color");
    
        float r = 0.0f;//Random.Range(0f, 1f);
        float g = 0.0f; //Random.Range(0f, 1f);
        float b = 0.0f;//Random.Range(0f, 1f);
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
        float r;
        float g;
        float b;

        if (this.index % 2 == 0) {
            r = 0.0f; //Random.Range(0f, 1f);
            g = 1.0f - 0.008f * index; //Random.Range(0f, 1f);
            b = 0.0f;//Random.Range(0f, 1f);
        } else
        {
            r = 0.0f;//Random.Range(0f, 1f);
            g = 0.0f; //Random.Range(0f, 1f);
            b = 1.0f - 0.008f * index; //Random.Range(0f, 1f);
        }
        float a = 0f;
        color = new Color(r, g, b, a);
        gameObject.GetComponent<Renderer>().material.color = color;
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

    Mesh CreateHexMesh(float size) {
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

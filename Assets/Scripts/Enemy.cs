using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health;
    public int x;
    public int z;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void hover ()
    {
        Debug.Log("Show enemy tooltip: " + this.health + " " + this.x + " " + this.z);
    }
}

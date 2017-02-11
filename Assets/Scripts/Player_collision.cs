using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_collision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision) {
        string tag = collision.gameObject.tag;
        if (tag == "Enemy") {
            Destroy(collision.gameObject, 0.5f);
        }
    }

}

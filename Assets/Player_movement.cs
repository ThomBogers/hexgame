using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour {

    public float speed = 150.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        var y = Input.GetAxis("Jump") * Time.deltaTime * speed;

        Debug.Log("x = " + x + "z = " + z + "y = "+ y);

        transform.Translate(x, y, z);

    }
}

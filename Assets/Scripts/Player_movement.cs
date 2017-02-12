using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour {

    public float movespeed = 150.0f;
    public float jumpspeed = 25.0f;

    // Use this for initialization
    void Start () {
        //rigidbody.freezeRotation = true;
        GetComponent<Rigidbody>().freezeRotation = true;


    }
	
	// Update is called once per frame
	void Update () {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * movespeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * movespeed;

        var y = Input.GetAxis("Jump") * Time.deltaTime * jumpspeed;

        //Debug.Log("x = " + x + "z = " + z + "y = "+ y);

        transform.Translate(x, y, z);

    }
}

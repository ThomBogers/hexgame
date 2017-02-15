using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float movespeed = 150.0f;
    public float jumpspeed = 25.0f;

    private Vector3? targetPosition = null;

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
        transform.Translate(x, y, z);

        if (Input.GetMouseButton(0)) {
            HandleInput();
        }

        if (targetPosition.HasValue )
        {
            float step = movespeed * Time.deltaTime;

            // We are now sure we have a target
            Vector3 currentTarget = (Vector3)targetPosition;
            float distance = Vector3.Distance(transform.position, currentTarget);
            if (distance < step) {
                targetPosition = null;
            } else {
                transform.position = Vector3.MoveTowards(transform.position, currentTarget, step);
            }
        }


    }
    void HandleInput() {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(inputRay, out hit)) {
            TouchObject(hit.transform.gameObject);
        }
    }

    void TouchObject(GameObject obj)  {
        
        if(obj.tag == "Cell")
        {
            Cell cell = obj.GetComponent<Cell>();
            Debug.Log("touched at " + cell.index );
            cell.color = Color.gray;
            // We only want to move in 2D at the moment
            this.targetPosition = new Vector3(obj.transform.position.x, transform.position.y, obj.transform.position.z);
        }
        
    }
}

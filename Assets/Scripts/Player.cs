using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float movespeed = 150.0f;
    public float jumpspeed = 25.0f;

    public int x;
    public int z;

    public int health;

    
    private struct TargetPosition  {
        public Vector3 target;
        public bool active;
        
    }

    private TargetPosition targetPosition;

    // Use this for initialization
    void Start () {
        //rigidbody.freezeRotation = true;
        GetComponent<Rigidbody>().freezeRotation = true;

    }
	
	// Update is called once per frame
	void Update () {
       
        HandleInput();

        if (this.targetPosition.active )
        {
            float step = movespeed * Time.deltaTime;

            // We are now sure we have a target
            Vector3 currentTarget = (Vector3)this.targetPosition.target;
            float distance = Vector3.Distance(transform.position, currentTarget);
            if (distance < step) {
                this.targetPosition.active = false;
            } else {
                transform.position = Vector3.MoveTowards(transform.position, currentTarget, step);
            }
        }


    }
    void HandleInput() {
       // var x = Input.GetAxis("Horizontal") * Time.deltaTime * movespeed;
       // var z = Input.GetAxis("Vertical") * Time.deltaTime * movespeed;
       // var y = Input.GetAxis("Jump") * Time.deltaTime * jumpspeed;
       // transform.Translate(x, y, z);

        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(inputRay, out hit, float.PositiveInfinity, 5)) {
            if (Input.GetMouseButton(0)) {
                TouchObject(hit.transform.gameObject);
            } 
            HoverObject(hit.transform.gameObject);
        }
    }

    void TouchObject(GameObject obj)  {
        
        if(obj.tag == "Cell") {
            if (! this.targetPosition.active)
            {
                Cell cell = obj.GetComponent<Cell>();
                cell.color = Color.gray;
                // We only want to move in 2D at the moment
                this.targetPosition.active = true;
                this.targetPosition.target = new Vector3(obj.transform.position.x, transform.position.y, obj.transform.position.z);
                this.x = obj.GetComponent<Cell>().x;
                this.z = obj.GetComponent<Cell>().z;
            }
        }
    }

    void HoverObject(GameObject obj)
    {

        if (obj.tag == "Cell") {
            Cell cell = obj.GetComponent<Cell>();
            cell.underCursor = true;

            if(cell.x == this.x && cell.z == this.z)
            {
                Debug.Log("Show player tooltip: "+ this.health + " " + this.x + " " + this.z);
            }
        }

    }
}

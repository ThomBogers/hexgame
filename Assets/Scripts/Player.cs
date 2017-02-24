using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int x;
    public int z;

    public int health;
    public float movespeed = 150.0f;
    public float jumpspeed = 25.0f;


    private struct TargetPosition
    {
        public Vector3 target;
        public bool active;

    }

    private TargetPosition targetPosition;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame

    public bool canMove () {
        return this.targetPosition.active;
    }

    public void moveTo (Vector3 target)
    {
        // We only want to move in 2D at the moment, so use our own y for height
        this.targetPosition.target = new Vector3(target.x, transform.position.y, target.z);
        this.targetPosition.active = true;
    }

    void move ()
    {
        float step = movespeed * Time.deltaTime;

        // We are now sure we have a target
        Vector3 currentTarget = (Vector3)this.targetPosition.target;
        float distance = Vector3.Distance(transform.position, currentTarget);
        if (distance < step)
        {
            this.targetPosition.active = false;
            State.finishTurn();
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, step);
        }

        CellCoordinates coords = CellCoordinates.getCoordinatesFromPostion(transform.position);
        this.x = coords.x;
        this.z = coords.z;
    } 

    public void hover() { 
        Debug.Log("Show player tooltip: " + this.health + " " + this.x + " " + this.z);
    }
    void Update()
    {
        if (this.targetPosition.active)
        {
            this.move();
        }


    }
}

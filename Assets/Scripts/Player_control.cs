using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_control : MonoBehaviour {

    
    // Update is called once per frame
    private void Update()
    {
        HandleInput();
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
            if (! State.getPlayer().canMove())
            {
                obj.GetComponent<Cell>().touch();
                State.getPlayer().moveTo(obj.transform.position);

            }
        }
    }

    void HoverObject(GameObject obj)
    {

        if (obj.tag == "Cell") {
            Cell cell = obj.GetComponent<Cell>();
            Player player = State.getPlayer();
            cell.hover();
            
            if(cell.x == player.x && cell.z == player.z)
            {
                player.hover();
            } else {
                foreach (var enemy in State.enemies)
                {
                    if (cell.x == enemy.x && cell.z == enemy.z)
                    {
                        enemy.hover();
                        break;
                    }
                }
            }
        }

    }
}

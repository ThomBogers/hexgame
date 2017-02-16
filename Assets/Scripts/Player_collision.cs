using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            string currentScene = SceneManager.GetActiveScene().name;
            if (currentScene == "scene_combat")
            {
                SceneManager.LoadScene("scene_map");
            } else
            {
                SceneManager.LoadScene("scene_combat");
            }
            
            Destroy(collision.gameObject, 0.5f);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour {

    public Grid gridPrefab;
    public Player playerPrefab;
    public Enemy enemyPrefab;

    public int numberOfEnemies;

	// Use this for initialization
	void Start () {

        Grid grid = Instantiate<Grid>(gridPrefab);
        grid.transform.SetParent(transform, false);

        int x = 0; // (int)Random.Range(0, grid.width);
        int y = 0; // (int)Random.Range(0, grid.height);

        Vector3 playerPosition = grid.getPositionFromCoordinate(x, y);

        Player player = Instantiate<Player>(playerPrefab);
        player.transform.SetParent(grid.transform, false);
        player.transform.localPosition = playerPosition;

        for(int i = 0; i < numberOfEnemies; i++)
        {
            x = (int)Random.Range(0, grid.width);
            y = (int)Random.Range(0, grid.height);

            Vector3 enemyPosition = grid.getPositionFromCoordinate(x, y);
            Enemy enemy = Instantiate<Enemy>(enemyPrefab);
            enemy.transform.SetParent(grid.transform, false);
            enemy.transform.localPosition = enemyPosition;



        }


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

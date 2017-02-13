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
        grid.name = "Grid";
        grid.transform.SetParent(transform, false);

        int x = 0; // (int)Random.Range(0, grid.width);
        int y = 0; // (int)Random.Range(0, grid.height);

        Vector3 playerPosition = grid.getPositionFromCoordinate(x, y);
        playerPosition.y = 10;
        Player player = Instantiate<Player>(playerPrefab);
        player.name = "Player";
        player.transform.SetParent(transform, false);
        player.transform.localPosition = playerPosition;

        for(int i = 0; i < numberOfEnemies; i++)
        {
            x = (int)Random.Range(0, grid.width);
            y = (int)Random.Range(0, grid.height);

            Vector3 enemyPosition = grid.getPositionFromCoordinate(x, y);
            enemyPosition.y = 10;
            Enemy enemy = Instantiate<Enemy>(enemyPrefab);
            enemy.name = "Enemy " + i;
            enemy.transform.SetParent(transform, false);
            enemy.transform.localPosition = enemyPosition;

        }


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

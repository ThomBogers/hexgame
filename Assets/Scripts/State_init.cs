using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_init : MonoBehaviour {

    public Grid gridPrefab;
    public Player playerPrefab;
    public Enemy enemyPrefab;

    public static Grid grid = null;
    public static Player player = null;
    public static List<Enemy> enemies = new List<Enemy>();

    public int numberOfEnemies;
    
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

        if(!grid)
        {
            grid = Instantiate<Grid>(gridPrefab);
            grid.name = "Grid";
            grid.transform.SetParent(transform, false);
        }
        if (!player)
        {
            int x = 0; // (int)Random.Range(0, grid.width);
            int z = 0; // (int)Random.Range(0, grid.height);

            Vector3 playerPosition = CellCoordinates.getPositionFromCoordinate(x, z);
            playerPosition.y = 10;
            player = Instantiate<Player>(playerPrefab);
            player.x = x;
            player.z = z;
            player.name = "Player";
            player.transform.SetParent(transform, false);
            player.transform.localPosition = playerPosition;
            player.health = 100;
        }

        if(enemies.Count == 0)
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                int x;
                int z;
                while (true)
                {
                    x = (int)Random.Range(0, grid.width);
                    z = (int)Random.Range(0, grid.height);

                    if(x != player.x || z != player.z) { break; }

                }

                Vector3 enemyPosition = CellCoordinates.getPositionFromCoordinate(x, z);
                enemyPosition.y = 10;
                Enemy enemy = Instantiate<Enemy>(enemyPrefab);
                enemy.name = "Enemy " + i;
                enemy.health = 100;
                enemy.transform.SetParent(transform, false);
                enemy.transform.localPosition = enemyPosition;
                enemies.Add(enemy);

            }

        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour {

    public Grid gridPrefab;
    public Player playerPrefab;
    public Enemy enemyPrefab;

    public static Grid grid = null;
    public static List<Player> players = new List<Player>();
    public static List<Enemy> enemies = new List<Enemy>();

    private static int currentPlayer = 0;

    public static int numberOfPlayers = 3;
    public static int numberOfEnemies = 10;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

        if(!grid)
        {
            grid = Instantiate<Grid>(gridPrefab);
            grid.name = "Grid";
            grid.transform.SetParent(transform, false);
        }

        if (players.Count == 0)
        {
            for (int i = 0; i < numberOfPlayers; i++)
            {
                int x = i; // (int)Random.Range(0, grid.width);
                int z = i; // (int)Random.Range(0, grid.height);

                Vector3 playerPosition = CellCoordinates.getPositionFromCoordinate(x, z);
                playerPosition.y = 10;
                Player player = Instantiate<Player>(playerPrefab);
                player.x = x;
                player.z = z;
                player.name = "Player";
                player.transform.SetParent(transform, false);
                player.transform.localPosition = playerPosition;
                player.health = 100;
                players.Add(player);
            }
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
                    break;
                    //if(x != player.x || z != player.z) { break; }

                }

                Vector3 enemyPosition = CellCoordinates.getPositionFromCoordinate(x, z);
                enemyPosition.y = 10;
                Enemy enemy = Instantiate<Enemy>(enemyPrefab);
                enemy.name = "Enemy " + i;
                enemy.health = 100;
                enemy.x = x;
                enemy.z = z;
                enemy.transform.SetParent(transform, false);
                enemy.transform.localPosition = enemyPosition;
                enemies.Add(enemy);

            }

        }

    }

    public static Player getPlayer() {
        return players[currentPlayer];
    }

    public static void finishTurn()
    {
        currentPlayer++;
        if(currentPlayer == numberOfPlayers)
        {
            Debug.Log("ENEMY TURN");
            currentPlayer = 0;
        }
    }
}

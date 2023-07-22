using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrolGenerator : MonoBehaviour
{
    private GameObject enemyPatrols;
    private enemySpawn es;
    private GameObject left;
    private GameObject right;

    private List<Spawn> spawnPoints;
    private List<Spawn> currentLevelSpawnPoints;

    private int currentLevel = 0;

    private GameObject walls;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = Game.GetSpawnList();
        currentLevelSpawnPoints = new List<Spawn>();
        spawnCurrentLevel();
        spawnEnemyPatrolAreas();
        spawnWalls();
    }


    void spawnCurrentLevel()
    {
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            if (spawnPoints[i].spawnID.Contains(currentLevel.ToString()))
            {
                currentLevelSpawnPoints.Add(spawnPoints[i]);
            }
        }
    }

    void spawnEnemyPatrolAreas()
    {
        AssetManager.LoadPrefabs("EnemyPatrol", (GameObject s) =>
        {
            for (int i = 0; i < currentLevelSpawnPoints.Count; i++)
            {
                transform.position = new Vector3(currentLevelSpawnPoints[i].spawnPatrolX, currentLevelSpawnPoints[i].spawnPatrolY);

                enemyPatrols = s;
                enemyPatrols.name = "EnemyPatrol" + i;
                Instantiate(enemyPatrols, transform.position, Quaternion.identity);

                left = GameObject.Find("/" + enemyPatrols.name + "(Clone)/LeftEdge");
                right = GameObject.Find("/" + enemyPatrols.name + "(Clone)/RightEdge");
                es = GameObject.Find("/" + enemyPatrols.name + "(Clone)/EnemySpawn").GetComponent<enemySpawn>();

                es.patrolcount = i;

                es.enemyID = currentLevelSpawnPoints[i].mobID;
                es.weaponID = currentLevelSpawnPoints[i].weaponID;
                es.enemyHealth = currentLevelSpawnPoints[i].mobHp;
                es.noOfEnemies = currentLevelSpawnPoints[i].spawnFrequency;
                es.enemyXP = currentLevelSpawnPoints[i].mobXPDrop;

                left.transform.localPosition = new Vector3(-currentLevelSpawnPoints[i].spawnPatrolEdges, 0);
                right.transform.localPosition = new Vector3(currentLevelSpawnPoints[i].spawnPatrolEdges, 0);
            }
        });  
    }

    void spawnWalls()
    {
        AssetManager.LoadPrefabs("Wall", (GameObject s) =>
        {
            for (int i = 0; i < currentLevelSpawnPoints.Count; i++)
            {
                transform.position = new Vector3(currentLevelSpawnPoints[i].spawnWallX, currentLevelSpawnPoints[i].spawnWallY);
                walls = s;
                walls.name = "Wall_" + i;

                Instantiate(walls, transform.position, Quaternion.identity);
            }
        });
    }
}

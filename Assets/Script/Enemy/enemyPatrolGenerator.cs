using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrolGenerator : MonoBehaviour
{
    [SerializeField] private GameObject enemyPatrols;
    private GameObject es;
    private GameObject left;
    private GameObject right;
    private List<Spawn> spawnPoints;
    private List<Spawn> currentLevelSpawnPoints;

    private int currentLevel = 0;

    [SerializeField] private GameObject walls;

    // Start is called before the first frame update
    void Start()
    {
        
        spawnPoints = Game.GetSpawnList();
        spawnCurrentLevel();
        spawnEnemyPatrolAreas();
        spawnWalls();
    }

    void spawnCurrentLevel()
    {
        Debug.Log(spawnPoints);
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
        for (int i = 0; i < currentLevelSpawnPoints.Count; i++)
        {
            transform.position = new Vector3(currentLevelSpawnPoints[i].spawnPatrolX, currentLevelSpawnPoints[i].spawnPatrolY);
            

            enemyPatrols.name = "EnemyPatrol" + i;

            Instantiate(enemyPatrols, transform.position, Quaternion.identity);


            left = GameObject.Find("/" + enemyPatrols.name + "(Clone)/LeftEdge");
            right = GameObject.Find("/" + enemyPatrols.name + "(Clone)/RightEdge");
            es = GameObject.Find("/" + enemyPatrols.name + "(Clone)/EnemySpawn");
            es.GetComponent<enemySpawn>().patrolcount = i;

            left.transform.localPosition = new Vector3(-currentLevelSpawnPoints[i].spawnPatrolEdges, 0);
            right.transform.localPosition = new Vector3(currentLevelSpawnPoints[i].spawnPatrolEdges, 0);

        }
    }

    void spawnWalls()
    {
        for (int i = 0; i < currentLevelSpawnPoints.Count; i++)
        {
            transform.position = new Vector3(currentLevelSpawnPoints[i].spawnWallX, currentLevelSpawnPoints[i].spawnWallY);
            walls.name = "Wall_" + i;

            Instantiate(walls, transform.position, Quaternion.identity);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrolGenerator : MonoBehaviour
{
    [SerializeField] private GameObject enemyPatrols;
    private GameObject es;
    private GameObject left;
    private GameObject right;
    private float[][] spawnPoints;

    [SerializeField] private GameObject walls;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = new float[][]
        {
            new float[] {33.0f, 0f, 4.0f, 40.35f, 1.95f},
            new float[] {51.0f, 0f, 6.0f, 59.35f, 0.95f},
            new float[] {65.5f, 0f, 4.0f, 75.35f, 3.95f}
        };
        spawnEnemyPatrolAreas();
        spawnWalls();
    }

    void spawnEnemyPatrolAreas()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            transform.position = new Vector3(spawnPoints[i][0], spawnPoints[i][1]);

            enemyPatrols.name = "EnemyPatrol" + i;

            Instantiate(enemyPatrols, transform.position, Quaternion.identity);


            left = GameObject.Find("/" + enemyPatrols.name + "(Clone)/LeftEdge");
            right = GameObject.Find("/" + enemyPatrols.name + "(Clone)/RightEdge");
            es = GameObject.Find("/" + enemyPatrols.name + "(Clone)/EnemySpawn");
            es.GetComponent<enemySpawn>().patrolcount = i;

            left.transform.localPosition = new Vector3(-spawnPoints[i][2], 0);
            right.transform.localPosition = new Vector3(spawnPoints[i][2], 0);

        }
    }

    void spawnWalls()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            transform.position = new Vector3(spawnPoints[i][3], spawnPoints[i][4]);
            walls.name = "Wall_" + i;

            Instantiate(walls, transform.position, Quaternion.identity);
        }
    }
}

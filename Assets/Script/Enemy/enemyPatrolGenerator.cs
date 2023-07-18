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

    // Start is called before the first frame update
    void Start()
    {
        spawnEnemyPatrolAreas();
    }

    void spawnEnemyPatrolAreas()
    {
        spawnPoints = new float[][]
        {
            new float[] {33.0f, 0f, 4.0f},
            new float[] {51.0f, 0f, 6.0f},
            new float[] {65.5f, 0f, 4.0f}
        };
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
}

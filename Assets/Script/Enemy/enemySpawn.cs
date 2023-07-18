using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    [SerializeField] public GameObject enemy;
    public int patrolcount;
    private enemyPatrol ep;

    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;

    [SerializeField] private float noOfEnemies;

    private float timeTilSpawn;

    private float[][] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        SetTimeTilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        timeTilSpawn -= Time.deltaTime;
        if(timeTilSpawn <= 0 && noOfEnemies > 0)
        {
            enemy.name = "Slime_" + patrolcount;
            ep = enemy.GetComponent<enemyPatrol>();
            edgeSetting(patrolcount);

            Instantiate(enemy, transform.position, Quaternion.identity);
            noOfEnemies -= 1;
            SetTimeTilSpawn();
        }
    }

    private void SetTimeTilSpawn()
    {
        timeTilSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }

    void edgeSetting(int pos)
    {
        ep.leftEdge = GameObject.Find("/EnemyPatrol" + patrolcount + "(Clone)/LeftEdge").transform;
        ep.rightEdge = GameObject.Find("/EnemyPatrol" + patrolcount + "(Clone)/RightEdge").transform;
    }
}

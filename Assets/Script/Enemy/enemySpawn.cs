using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    //[SerializeField] private enemyPatrol enemyPatrol;

    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;

    [SerializeField] private float noOfEnemies;

    //[SerializeField] private Animator ani;

    private float timeTilSpawn;
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
            Instantiate(enemy, transform.position, Quaternion.identity);
            noOfEnemies -= 1;
            SetTimeTilSpawn();
        }

    }

    private void SetTimeTilSpawn()
    {
        timeTilSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }
}

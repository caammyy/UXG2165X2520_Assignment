using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    private GameObject enemy;
    public string enemyID;
    public string weaponID;
    private int weaponDmg;
    private string mobType;
    public int enemyHealth;

    private List<Mob> mobs;
    private List<Weapon> weapons;

    public int patrolcount;
    private enemyPatrol ep;

    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;

    public float noOfEnemies;

    private float timeTilSpawn;

    // Start is called before the first frame update
    void Start()
    {

        SetEnemy();

        SetDamage();
        SetTimeTilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        timeTilSpawn -= Time.deltaTime;
        if(timeTilSpawn <= 0 && noOfEnemies > 0)
        {
            AssetManager.LoadPrefabs(mobType, (GameObject s) =>
            {
                enemy = s;
                enemy.GetComponent<enemyAttack>().damage = weaponDmg;
                enemy.GetComponent<enemyLife>().iniHealth = enemyHealth;
                enemy.name = "Slime_" + patrolcount;

                ep = enemy.GetComponent<enemyPatrol>();

                ep.leftEdge = GameObject.Find("/EnemyPatrol" + patrolcount + "(Clone)/LeftEdge").transform;
                ep.rightEdge = GameObject.Find("/EnemyPatrol" + patrolcount + "(Clone)/RightEdge").transform;

                Instantiate(enemy, transform.position, Quaternion.identity);
            });
            noOfEnemies -= 1;
            SetTimeTilSpawn();
        }
    }

    void SetDamage()
    {
        weapons = Game.GetWeaponList();

        foreach (Weapon w in weapons)
        {
            if (w.weaponID == weaponID)
            {
                Debug.Log(w.damageAmount);
                weaponDmg = w.damageAmount;
            }
        }
    }
    void SetEnemy()
    {
        mobs = Game.GetMobList();
        foreach (Mob m in mobs)
        {
            if (m.mobID == enemyID)
            {
                mobType = m.mobType;
            }
        }
    }

    private void SetTimeTilSpawn()
    {
        timeTilSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }
}

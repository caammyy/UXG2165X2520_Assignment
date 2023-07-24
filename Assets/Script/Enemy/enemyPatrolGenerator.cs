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
    public int weapon;
    private GameObject weaponFloat;

    public int noOfEnemies;
    public int noOfSectionsCompleted = 0;
    private int noOfSections;

    // Start is called before the first frame update
    void Start()
    {
        
        //spawnCurrentLevel();
        
    }
    private void Update()
    {
        DisableWall();
    }


    public void spawnCurrentLevel()
    {
        spawnPoints = Game.GetSpawnList();
        currentLevelSpawnPoints = new List<Spawn>();
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            if (spawnPoints[i].spawnID.Contains(currentLevel.ToString()))
            {
                currentLevelSpawnPoints.Add(spawnPoints[i]);
            }
        }
        noOfSections = currentLevelSpawnPoints.Count;
        noOfEnemies = currentLevelSpawnPoints[noOfSectionsCompleted].spawnFrequency;

        spawnEnemyPatrolAreas();
        spawnWalls();
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

    void DisableWall()
    {
        if (noOfSectionsCompleted < noOfSections)
        {
            foreach (var gObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
            {
                string wallname = "Wall_" + noOfSectionsCompleted;
                if (gObj.name.Contains(wallname))
                {

                    walls = gObj;
                }
            }
            if (noOfEnemies == 0)
            {
                if (weapon < 2)
                {
                    transform.position = walls.transform.position;
                    spawnWeapon(walls);
                }
                Destroy(walls.gameObject);
                if (noOfSections > 0 &&(noOfSectionsCompleted < noOfSections-1))
                {
                    noOfSectionsCompleted += 1;
                    noOfEnemies = currentLevelSpawnPoints[noOfSectionsCompleted].spawnFrequency;
                }
            }
        }
    }
    void spawnWeapon(GameObject wall)
    {
        weapon += 1;
        string weaponName = "WeaponFloat_" + weapon + ".png";
        AssetManager.LoadPrefabs("Weapon", (GameObject s) =>
        {
            weaponFloat = s;
            AssetManager.LoadSprite(weaponName, (Sprite s) =>
            {
                weaponFloat.GetComponent<SpriteRenderer>().sprite = s;
                Instantiate(weaponFloat, transform.position, Quaternion.identity);
            });
        });
    }
}

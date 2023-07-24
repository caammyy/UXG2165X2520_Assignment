using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    public string initAvatar, initCharID,initPlayID;
    public DateTime initCreation;
    public float initDamageTaken,initShort;
    public string initWeaponID;
    public int initEnemyKill,initPlayerXP,InitPlayerLevel;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        DataManager datamanager = GetComponent<DataManager>();
        datamanager.LoadRefData(OnDataLoad);

        
    }

    public void OnDataLoad()
    {
        //run what u want after the data has finished loading
        GetComponent<playerController>().SetCharacter();
        GameObject.Find("EnemyPatrolGenerator").GetComponent<enemyPatrolGenerator>().spawnCurrentLevel();
        //Game.SetPlayer(new Player("1",initCreation,initCharID,initPlayerXP,InitPlayerLevel,initWeaponID,initEnemyKill,initDamageTaken,initShort));
    }       

    private void Awake()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

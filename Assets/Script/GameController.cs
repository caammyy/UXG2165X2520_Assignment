using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //public string initAvatar, initCharID,initPlayID;
    //public DateTime initCreation;
    //public float initDamageTaken,initShort;
    //public string initWeaponID;
    //public int initEnemyKill,initPlayerXP,InitPlayerLevel;

    public int currentCutsceneID = 101;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        DataManager datamanager = GetComponent<DataManager>();
        datamanager.LoadRefData(OnDataLoad);
    }

    public void OnDataLoad()
    {
        //run what u want after the data has finished loading
        
        //Game.SetPlayer(new Player("1",initCreation,initCharID,initPlayerXP,InitPlayerLevel,initWeaponID,initEnemyKill,initDamageTaken,initShort));
        if (!SceneManager.GetActiveScene().name.Contains("Level"))
        {
            DialogueAttempt da = GameObject.Find("DialogueManager").GetComponent<DialogueAttempt>();
            da.DialogueStarter();
        }

        else
        {
            GetComponent<SceneController>().GetLevelforScene();
            GetComponent<SceneController>().SetSpawnandEnd();
            GetComponent<playerController>().SetCharacter();
            GameObject.Find("EnemyPatrolGenerator").GetComponent<enemyPatrolGenerator>().spawnCurrentLevel();
        }
            
    }      //test 

    private void Awake()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

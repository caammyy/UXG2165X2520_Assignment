using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

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

        if (!datamanager.LoadPlayerData())
        {
            Game.SetPlayer(new Player(DateTime.Now, "1", "C01", 0, 0, "W01", 0, 0, 0f));
            Debug.Log("Player saved");
        }
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
        else if (SceneManager.GetActiveScene().name == "CharacterSelect")
        {

        }
        else
        {
            GetComponent<SceneController>().GetLevelforScene();
            GetComponent<SceneController>().SetSpawnandEnd();
            GetComponent<playerController>().SetCharacter();
            //pl.UpdateCharacter();
            GameObject.Find("EnemyPatrolGenerator").GetComponent<enemyPatrolGenerator>().spawnCurrentLevel();
        }
            
    }      //test 

    //public void OnClickCharacter()
    //{
    //    pl.selectedCharacterName = EventSystem.current.currentSelectedGameObject.name;
    //    pl.UpdateCharacter();
    //}
}

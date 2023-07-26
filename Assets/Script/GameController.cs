using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

//Ashley
public class GameController : MonoBehaviour
{
    //public int currentCutsceneID = 101;


    void Start()
    {
        //DontDestroyOnLoad(this.gameObject);
        DataManager datamanager = GetComponent<DataManager>();
        datamanager.LoadRefData(OnDataLoad);

        if (!datamanager.LoadPlayerData())
        {
            Game.SetPlayer(new Player(DateTime.Now, "1", "C01", 0, 0, "W01", 0, 0, 0f));
        }
    }

    public void OnDataLoad()
    {
        //run what u want after the data has finished loading
        Debug.Log(Game.GetPlayer().GetPlayerCreation());
        if (SceneManager.GetActiveScene().name.Contains("dialogue"))
        {
            DialogueAttempt da = GameObject.Find("DialogueManager").GetComponent<DialogueAttempt>();
            da.DialogueStarter();
        }
        else if (SceneManager.GetActiveScene().name == "CharacterSelect")
        {

        }
        else if (SceneManager.GetActiveScene().name.Contains("Level"))
        {
            GetComponent<SceneController>().GetLevelforScene();
            GetComponent<SceneController>().SetSpawnandEnd();
            GetComponent<playerController>().SetCharacter();
            //pl.UpdateCharacter();
            GameObject.Find("EnemyPatrolGenerator").GetComponent<enemyPatrolGenerator>().spawnCurrentLevel();
        }
            
    }
}

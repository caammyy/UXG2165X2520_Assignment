using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Cammy
public class SceneController : MonoBehaviour
{
    public int gameLevelID;
    public GameLevel gameLevel;

    public void GetLevelforScene()
    {
        List<Scene> sList = Game.GetSceneList();
        foreach (Scene s in sList)
        {
            if (s.sceneName == SceneManager.GetActiveScene().name)
            {
                gameLevelID = s.gameLevelID;
            }
        }
        List<GameLevel> glList = Game.GetGameLevelList();
        foreach (GameLevel gl in glList)
        {
            if (gl.gameLevelID == gameLevelID)
            {
                gameLevel = gl;
            }
        }
    }
    public void SetSpawnandEnd()
    {
        GetComponent<playerController>().playerSpawn = new Vector3(gameLevel.gameSpawnPointX, gameLevel.gameSpawnPointY);
        GameObject.Find("EndDoor").transform.position = new Vector3(gameLevel.gameEndPointX, gameLevel.gameEndPointY);
    }
}

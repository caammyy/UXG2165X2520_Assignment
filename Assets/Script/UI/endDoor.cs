using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endDoor : MonoBehaviour
{
    public void NextLevel()
    {
        GameObject.Find("GameController").GetComponent<DataManager>().SavePlayerData();
        Invoke("GoNextLevel", 2.0f);
    }
    public void GoNextLevel()
    {
        SceneManager.LoadScene("Dialogue");
    }
}

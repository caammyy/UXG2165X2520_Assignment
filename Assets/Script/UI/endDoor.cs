using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Ashley
public class endDoor : MonoBehaviour
{
    public void NextLevel()
    {
        Game.SetPlayer(GameObject.Find("GameController/Player(Clone)").GetComponent<playerLife>().currentPlayer);
        GameObject.Find("GameController").GetComponent<DataManager>().SavePlayerData();
        Invoke("GoNextLevel", 2.0f);
    }
    public void GoNextLevel()
    {
        PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Summary");
    }
}

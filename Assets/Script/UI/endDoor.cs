using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endDoor : MonoBehaviour
{
    public void NextLevel()
    {
        Invoke("GoNextLevel", 2.0f);
    }
    public void GoNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

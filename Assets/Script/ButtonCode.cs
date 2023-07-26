using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Ashley
public class ButtonCode : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadSceneAsync("dialogue");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Ashley
public class endScreen : MonoBehaviour
{
    public void BacktoHome()
    {
        SceneManager.LoadScene("startScreen");
    }
}

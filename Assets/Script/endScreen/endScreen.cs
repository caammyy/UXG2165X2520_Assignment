using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endScreen : MonoBehaviour
{
    public void BacktoHome()
    {
        SceneManager.LoadScene("startScreen");
    }
}

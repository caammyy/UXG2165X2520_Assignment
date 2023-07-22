using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



/**all pandakitori LOLOLOL
public class ChangeSceneStartToLvl1 : MonoBehaviour
{
    [SerializeField] public GameObject endTransition;

    public void MoveToScene()
    {
        SoundManager.Instance.PlaySFX("Start");
        if (PlayerPrefs.HasKey("currentLevel"))
        {
            endTransition.SetActive(true);
            Invoke("Scene2", 1.5f);
        }
        else
        {
            endTransition.SetActive(true);
            Invoke("Scene9", 1.5f);
        }
    }
    public void Home()
    {
        endTransition.SetActive(true);
        Invoke("Scene0", 1.5f);
    }

    public void MoveToPrologue()
    {
        SoundManager.Instance.PlaySFX("ButtonClick");
        endTransition.SetActive(true);
        Invoke("Scene8", 1.5f);
    }

    public void MoveToTutorial()
    {
        SoundManager.Instance.PlaySFX("ButtonClick");
        endTransition.SetActive(true);
        Invoke("Scene9", 1.5f);
    }
    public void Scene0()
    {
        SceneManager.LoadScene(0);
    }
    public void Scene2()
    {
        SceneManager.LoadScene(2);
    }
    public void Scene8()s
    {
        SceneManager.LoadScene(8);
    }
    public void Scene9()
    {
        SceneManager.LoadScene(9);
    }
}
**/

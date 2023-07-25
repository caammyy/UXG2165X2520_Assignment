using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class settingsController : MonoBehaviour
{
    [SerializeField] public GameObject settingsPanel;
    public bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Pause()
    {
        Debug.Log("pause");
        isPaused = true;
        settingsPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        settingsPanel.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        Destroy(GameObject.Find("/GameController/Player(Clone)").gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void BackToHome()
    {
        //Destroy(GameObject.Find("GameController"));
        isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(0);
    }
}

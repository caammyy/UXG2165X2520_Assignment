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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

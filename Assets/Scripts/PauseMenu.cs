using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public InputHelper Helper;
    [SerializeField] GameObject pauseMenu;

    bool isPaused;

    private void Update()
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
        pauseMenu.SetActive(true);
        Helper.ShowCursor();
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Helper.HideCursor();
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Home(int SampleScene)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScene");
    }
}

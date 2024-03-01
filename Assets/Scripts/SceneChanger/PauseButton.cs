using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseButton : MonoBehaviour
{
    public bool IsPaused;
    public GameObject PauseMenu;
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject BACKGROUND;

    public GameObject winui;
    // public GameObject timer;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
    public void TogglePause()
    {
        IsPaused = !IsPaused;

        if (IsPaused)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }

    public void Resume()
    {
        IsPaused = false;
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Button1.SetActive(false);
        Button2.SetActive(false);
        Button3.SetActive(false);
        BACKGROUND.SetActive(false);
        
        winui.SetActive(false);
        //timer.SetActive(true);
    }

    public void ResumeGame()
    {
        winui.SetActive(false);
        Time.timeScale = 1f;
       
        //timer.SetActive(true);
    }

    public void Pause()
    {
        IsPaused = true;
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        Button1.SetActive(true);
        Button2.SetActive(true);
        Button3.SetActive(true);
        BACKGROUND.SetActive(true);
       // timer.SetActive(false);
        //settings.SetActive(false);
    }

    public void Settings()
    {
        IsPaused = true;
        PauseMenu.SetActive(false);
        Time.timeScale = 0f;
       // settings.SetActive(true);

    }
    public void Menu()
    {
        //Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        Time.timeScale = 1;
        // Reloads the current scene, effectively restarting the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

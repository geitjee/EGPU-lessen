using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using UnityEngine.UI;

public class GameMenuScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject finishMenu;
    public TextMeshProUGUI finishedTimeText;
    public TextMeshProUGUI bestTimeText;

    // Start is called before the first frame update
    /// <summary>
    /// Closes the pause & finish menu.
    /// </summary>
    void Start()
    {
        pauseMenu.SetActive(false);
        finishMenu.SetActive(false);
    }

    /// <summary>
    /// Just so you can also pause and restart with the keyboard.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }

    /// <summary>
    /// Will load the current level again and makes sure the time is continouing again.
    /// </summary>
    public static void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Stops the time from running and opens the pause menu.
    /// </summary>
    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    /// <summary>
    /// closes the pause menu and continous the time.
    /// </summary>
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    /// <summary>
    /// Loads the scene of the menu.
    /// </summary>
    public void ToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    /// <summary>
    /// First sets the time in which the level was finished and sets all the other texts and opens the finish menu.
    /// </summary>
    /// <param name="finishedTime">The time in which the player crossed the finish line. </param>
    public void OpenFinishMenu(float finishedTime)
    {
        TimeSpan currentTime = TimeSpan.FromSeconds(finishedTime);
        finishedTimeText.text = String.Format(@"{0:mm\:ss\.ff}", currentTime);
        float bestTime = PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name);
        if (finishedTime == bestTime)
        {
            bestTimeText.text = "New best time!";
        }
        else
        {
            TimeSpan time = TimeSpan.FromSeconds(bestTime);
            bestTimeText.text = "Best time: " + String.Format(@"{0:mm\:ss\.ff}", time);
        }
        pauseMenu.SetActive(false);
        finishMenu.SetActive(true);
    }
}

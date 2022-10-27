using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameMenuScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject finishMenu;
    public TextMeshProUGUI finishedTimeText;
    public TextMeshProUGUI bestTimeText;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        finishMenu.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

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

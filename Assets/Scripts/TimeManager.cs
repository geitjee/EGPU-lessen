using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private static float currentTime;
    private bool isRacing;

    public TextMeshProUGUI timer;

    /// <summary>
    /// Says that the player is racing and resets the 'stopwatch'.
    /// </summary>
    void Start()
    {
        isRacing = true;
        currentTime = 0;
    }

    /// <summary>
    /// If the player is racing the time increases and the timer shown is updated with a good format.
    /// </summary>
    void Update()
    {
        if (isRacing)
        {
            currentTime += Time.deltaTime;
            TimeSpan time = TimeSpan.FromSeconds(currentTime);
            timer.text = String.Format(@"{0:mm\:ss\.ff}", time);
        }
    }
    /// <summary>
    /// Function to stop the timer and save the time if it is the best time.
    /// </summary>
    public void Finished()
    {
        Time.timeScale = 0;
        isRacing = false;
        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name))
        {
            if(currentTime < PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name))
            {
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name, currentTime);
            }
        }
        else
        {
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name, currentTime);
        }
        GameObject.Find("IngameCanvas").GetComponent<GameMenuScript>().OpenFinishMenu(currentTime);
    }
}

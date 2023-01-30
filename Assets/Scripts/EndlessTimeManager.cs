using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndlessTimeManager : MonoBehaviour
{
    [SerializeField]
    private static float currentTime;
    private bool isRacing;

    private int questionPeriodInSeconds = 60;
    private float questionCooldownAmount = 2;
    private float questionCooldown;
    public TextMeshProUGUI timer;

    /// <summary>
    /// Says that the player is racing and resets the 'stopwatch'.
    /// </summary>
    void Start()
    {
        isRacing = true;
        currentTime = 0;
        questionCooldown = questionCooldownAmount;
    }

    /// <summary>
    /// If the player is racing the time increases and the timer shown is updated with a good format.
    /// </summary>
    void Update()
    {
        if (isRacing)
        {
            currentTime += Time.deltaTime;

            if (questionCooldown > 0)
            {
                questionCooldown -= Time.deltaTime;
            }

            TimeSpan time = TimeSpan.FromSeconds(currentTime);
            timer.text = String.Format(@"{0:mm\:ss\.ff}", time);
            if (currentTime % questionPeriodInSeconds < 1 && questionCooldown <= 0)
            {
                questionCooldown = questionCooldownAmount;
                EnvironmentManager.ChangeSeason();
                RoadSpawner.StaticSpawnQuizRoad();
            }
        }
    }
    /// <summary>
    /// Function to stop the timer and save the time if it is the best time.
    /// </summary>
    public void Finished()
    {
        Time.timeScale = 0;
        isRacing = false;
        if (PlayerPrefs.HasKey("EndlessMode"))
        {
            if (currentTime > PlayerPrefs.GetFloat("EndlessMode"))
            {
                PlayerPrefs.SetFloat("EndlessMode", currentTime);
            }
        }
        else
        {
            PlayerPrefs.SetFloat("EndlessMode", currentTime);
        }
        GameObject.Find("IngameCanvas").GetComponent<GameMenuScript>().OpenFinishMenu(currentTime);
    }
}

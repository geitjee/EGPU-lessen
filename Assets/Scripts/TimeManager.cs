using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private float currentTime;
    private bool isRacing;

    public TextMeshProUGUI timer;
    // Start is called before the first frame update
    void Start()
    {
        isRacing = true;
        currentTime = 0;
    }

    // Update is called once per frame
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

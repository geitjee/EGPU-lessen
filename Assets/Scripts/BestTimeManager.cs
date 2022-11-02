using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class BestTimeManager : MonoBehaviour
{
    //
    public List<Transform> levels = new List<Transform>();
    /// <summary>
    /// Loops through all the levels on Awake and sets their best time and sets them interactable or not (So if you unlocked that one or not).
    /// </summary>
    void Awake()
    {
        bool IsAccessable = true;
        for (int i = 0; i < this.transform.childCount-1; i++)
        {
            if (PlayerPrefs.HasKey(this.transform.GetChild(i).name))
            {
                Debug.Log(this.transform.GetChild(i).name);
                TimeSpan time = TimeSpan.FromSeconds(PlayerPrefs.GetFloat(this.transform.GetChild(i).name));
                this.transform.GetChild(i).GetChild(2).GetComponent<TextMeshProUGUI>().text = String.Format(@"{0:mm\:ss\.ff}", time);
            }
            else
            {
                this.transform.GetChild(i).GetChild(2).GetComponent<TextMeshProUGUI>().text = "N/A";
                if (!IsAccessable)
                {
                    this.transform.GetChild(i).GetComponent<Button>().interactable = false;
                }
                IsAccessable = false;
            }
        }
        /*
        for (int i = 0; i < levels.Count; i++)
        {
            if(PlayerPrefs.HasKey(levels[i].parent.name))
            {
                Debug.Log(levels[i].parent.name);
                TimeSpan time = TimeSpan.FromSeconds(PlayerPrefs.GetFloat(levels[i].parent.name));
                levels[i].GetComponent<TextMeshProUGUI>().text = String.Format(@"{0:mm\:ss\.ff}", time);
            }
            else
            {
                levels[i].GetComponent<TextMeshProUGUI>().text = "N/A";
                if (!IsAccessable)
                {
                    levels[i].parent.GetComponent<Button>().interactable = false;
                }
                IsAccessable = false;
            }
        }*/
    }
}

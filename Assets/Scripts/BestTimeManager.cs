using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
        for (int i = 0; i < levels.Count; i++)
        {
            if(PlayerPrefs.HasKey(levels[i].parent.name))
            {
                Debug.Log(levels[i].parent.name);
                levels[i].GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString(levels[i].parent.name);
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
        }
    }
}

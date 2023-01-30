using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to make sure the background music is being continued in every scene.
/// </summary>
public class MusicDontDestroyOnLoad : MonoBehaviour
{
    private static GameObject thisInstance;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (thisInstance == null)
        {
            thisInstance = this.gameObject;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}

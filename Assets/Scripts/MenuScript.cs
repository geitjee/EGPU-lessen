using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject levelsMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        levelsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToMainMenu()
    {
        levelsMenu.SetActive(false);
    }

    public void OpenLevenMenu()
    {
        levelsMenu.SetActive(true);
    }

    public void OpenLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

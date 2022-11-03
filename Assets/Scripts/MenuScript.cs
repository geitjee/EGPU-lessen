using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject levelsMenu;
    public GameObject infoMenu;
    
    // Start is called before the first frame update
    /// <summary>
    /// Sets the levels menu inactive so just the main menu is shown.
    /// </summary>
    void Start()
    {
        levelsMenu.SetActive(false);
        infoMenu.SetActive(false);
    }

    /// <summary>
    /// Disables the levels menu so only the main menu is shown.
    /// </summary>
    public void ToMainMenu()
    {
        levelsMenu.SetActive(false);
        infoMenu.SetActive(false);
    }

    /// <summary>
    /// Enables the levels menu.
    /// </summary>
    public void OpenLevenMenu()
    {
        levelsMenu.SetActive(true);
        infoMenu.SetActive(false);
    }

    /// <summary>
    /// Opens the menu which explains how the game works.
    /// </summary>
    public void OpenInfoMenu()
    {
        infoMenu.SetActive(true);
        levelsMenu.SetActive(false);
    }

    /// <summary>
    /// Opens the scene with the name of the Clicked button so this name is very important for the level to load!
    /// </summary>
    public void OpenLevel()
    {
        SceneManager.LoadScene(EventSystem.current.currentSelectedGameObject.name);
    }

    /// <summary>
    /// Quits the application.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}

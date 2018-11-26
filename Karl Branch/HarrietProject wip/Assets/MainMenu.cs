using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour{

    public static bool GameIsFrozen = false;

    public GameObject mainMenuUI;

    public Button playButton;

    public Button optionsButton;
     

    void Update()
    {
        if (Input.GetButtonDown("playButton"))
        {
            StartGame();
        }

        else 
        {
            PauseGame();
        }

        if (Input.GetButtonDown("optionsButton"))
        {
            OptionsMenu();
        }
    }

    public void OptionsMenu()
    {
        mainMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsFrozen = true;

    }

    public void StartGame()
    {
        mainMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsFrozen = false;

    }



    public void PauseGame()
    {
        mainMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsFrozen = true;

    }

}

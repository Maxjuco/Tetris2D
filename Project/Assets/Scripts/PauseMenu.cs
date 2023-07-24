using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    //to know if the game is on pause : 
    public static bool gameisPaused = false;

    public GameObject pauseMenuUI;
    public GameObject settingWindow;
    public GameObject scoreTable;

    private GameObject playerController;

    private void Start()
    {
        //in case where the language was change on an other scene : 
        WriteLanguage();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameisPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }


    void Paused()
    {
        //desactivating the possibility of using input for the player controller :
        playerController = GameObject.FindGameObjectsWithTag("Player")[0];
        playerController.SetActive(false);
        //activating the Pause menu : 
        pauseMenuUI.SetActive(true);
        //stoping the time in the game 
        Time.timeScale = 0; //Time.timeScale = portion of time passed  (if zero time freeze)
        //change the game statut...
        gameisPaused = true;
    }

    public void Resume()
    {
        //desactivating the Pause menu : 
        pauseMenuUI.SetActive(false);
        settingWindow.SetActive(false);
        //reactivating the possibility of using input for the player movement :
        playerController.SetActive(true);
        //resuming the time in the game 
        Time.timeScale = 1; //Time.timeScale = portion of time passed  (if 0 time freeze, if 1 = normal time)
        //change the game statut...
        gameisPaused = false;
    }


    public void OpenSettings()
    {
        settingWindow.SetActive(true);
    }

    public void CloseSettings()
    {
        settingWindow.SetActive(false);
        //in case of language changes : 
        WriteLanguage();
    }

    public void LoadMainMenu()
    {


        //to avoid freeze on the next game : 
        Resume();

        //to load the main menu 
        SceneManager.LoadScene("MainMenu");
        
    }


    public void WriteLanguage()
    {
        Text[] menuTexts = pauseMenuUI.GetComponentsInChildren<Text>();
        switch (LoadAndSaveData.instance.GetLanguage()) 
        {
            case "English":
                menuTexts[0].text = "GAME PAUSED";
                menuTexts[1].text = "Resume";
                menuTexts[2].text = "Settings";
                menuTexts[3].text = "Main Menu";

                break;


            case "Français":
                menuTexts[0].text = "JEU EN PAUSE";
                menuTexts[1].text = "Reprendre";
                menuTexts[2].text = "Paramètres";
                menuTexts[3].text = "Menu Principal";

                break;
        }

    }

    public void HighScore()
    {
        scoreTable.SetActive(true);
    }

    public void CloseHighScore()
    {
        scoreTable.SetActive(false);
    }
}

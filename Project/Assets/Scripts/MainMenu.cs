using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public GameObject settingWindow;
    public string levelToLoad;
    public GameObject ScoreTable;

    private void Start()
    {
        //in case where the language was change on an other scene : 
        WriteLanguage();
    }
    public void StarGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void SettingsButton()
    {
        settingWindow.SetActive(true);   
    }
    public void HighScore()
    {
        ScoreTable.SetActive(true);
    }
    public void CloseSettingsWindow()
    {
        settingWindow.SetActive(false);
        WriteLanguage();
    }

    public void CloseHighScore()
    {
        ScoreTable.SetActive(false);
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void WriteLanguage()
    {
        Text[] menuTexts = GetComponentsInChildren<Text>();
        switch (LoadAndSaveData.instance.GetLanguage())
        {
            case "English":
                menuTexts[0].text = "START GAME";
                menuTexts[1].text = "SETTINGS";
                menuTexts[2].text = "HIGH SCORE";
                //menuTexts[3].text = "CREDITS";
                menuTexts[3].text = "QUIT GAME";

                break;


            case "Français":
                menuTexts[0].text = "DÉMARRER";
                menuTexts[1].text = "PARAMÈTRES";
                menuTexts[2].text = "SCORES";
                //menuTexts[3].text = "CRÉDITS";
                menuTexts[3].text = "QUITTER";

                break;
        }

    }
}

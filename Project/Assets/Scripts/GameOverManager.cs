using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;

    //create a Singleton instance 
    public static GameOverManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Two instance of GameOverManager are in the scene !");
            return;
        }

        instance = this;
    }

    /*function wich manage on snake death : */
    public void OnSnakeDeath()
    {
        //register the score (if it worth it ) : 

        LoadAndSaveData.instance.CheckHighscore();

        
      
    }

    public void displayGameOverMenu()
    {
        //display the game over menu 
        gameOverUI.SetActive(true);
    }

    public void hideGameOverMenu()
    {
        //display the game over menu 
        gameOverUI.SetActive(false);
    }

    public void RetryButton()
    {
        //resart on the game screen : 
        // reload the scene : 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        

        //re hide the game over menu : 
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}

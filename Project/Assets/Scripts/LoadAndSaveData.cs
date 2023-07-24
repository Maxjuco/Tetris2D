using UnityEngine;

public class LoadAndSaveData : MonoBehaviour
{

    public GameObject scoreInput;


    private int n;


    //singleton : 

    public static LoadAndSaveData instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("more than one instance of LoadAndSaveData in the scene");
            return;
        }

        instance = this;

    }

    void Start()
    {
        n = 0;
     
    }


    public void CheckHighscore()
    {
        GameOverManager.instance.displayGameOverMenu();

        for (int i = 0; i < 5; i++)
        {
            if (PlayerPrefs.GetInt(string.Concat("Highscore", i)) < ScoreScript.instance.getScore())
            {
                

                

                //to save the index to switch : 
                this.n = i;

                //ask the player's name : 
                scoreInput.SetActive(true);

                //to higligth the line of the player : 
                LoadHighScore.instance.HighscoreActive();

                //hide the game over menu behind : 
                GameOverManager.instance.hideGameOverMenu();
                break;
            }
            
        }

        
    }


    public void SaveData(string PlayerName)
    {
        int ScoreTemp = -1;
        int ScoreTemp2 = -1;
        //we set 5 highscore max : 


        //we save the score to put it under : 
        ScoreTemp = PlayerPrefs.GetInt(string.Concat("Highscore", n));

        PlayerPrefs.SetInt(string.Concat("Highscore", n), ScoreScript.instance.getScore());
        PlayerPrefs.SetString(string.Concat("HighscorePlayerName", n), PlayerName);

        for (int i = n+1; i < 5; i++)
        {
            if (PlayerPrefs.GetInt(string.Concat("Highscore", i)) < ScoreTemp)
            {
                //to put under the last highscore : 
                ScoreTemp2 = PlayerPrefs.GetInt(string.Concat("Highscore", i));

                
                PlayerPrefs.SetInt(string.Concat("Highscore", i), ScoreTemp);

                ScoreTemp = ScoreTemp2;
            } 
        }


        //finally we desactivate the menu : .
        scoreInput.SetActive(false);
       
    }

    public void SaveLanguage(string language)
    {
        PlayerPrefs.SetString("PlayerLanguage", language);
    }

    public string GetLanguage()
    {
        return PlayerPrefs.GetString("PlayerLanguage");
    } 

    public int getRankSaved()
    {
        return n;
    }

    public string loadPlayerName(int playerRank)
    {
        string name = PlayerPrefs.GetString(string.Concat("HighscorePlayerName", playerRank));
        return PlayerPrefs.GetString(string.Concat("HighscorePlayerName", playerRank));

    }

    public int loadScore(int scoreRank)
    {
        return PlayerPrefs.GetInt(string.Concat("Highscore", scoreRank));
    }
}

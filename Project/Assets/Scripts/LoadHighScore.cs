using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadHighScore : MonoBehaviour
{

    public Text[] PlayerNames;

    public Text[] ScoresText;


    //singleton : 

    public static LoadHighScore instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("more than one instance of LoadHighScore in the scene");
            return;
        }
            
        //we load and set the highscore : 
        for (int i = 0; i < PlayerNames.Length; i++)
        {
            PlayerNames[i].text = string.Concat(i + 1, " - ",
                                                        LoadAndSaveData.instance.loadPlayerName(i));

            ScoresText[i].text = string.Concat(LoadAndSaveData.instance.loadScore(i));
        }

        instance = this;
    }

        // Start is called before the first frame update
        void Start()
    {
        
        
    }

   public void HighscoreActive()
    {
        int n = LoadAndSaveData.instance.getRankSaved();
        PlayerNames[n].text = string.Concat(n + 1, " -  ... ");

        ScoresText[n].text = string.Concat(ScoreScript.instance.getScore());

        //to highlight the line : 
        PlayerNames[n].color = Color.yellow;
        ScoresText[n].color = Color.yellow;
    }
}

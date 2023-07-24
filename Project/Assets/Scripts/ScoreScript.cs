using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private int score;
    public Text scoreText;

    public static ScoreScript instance;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("more than one instance of ScoreScript in the scene");
            return;
        }

        instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {

        //score at 0 :
        score = 0;
        scoreText.text = string.Concat("Score is : ", score);
    }

    public void addScore()
    {
        //gain score : 
        score++;
        //modify the Text : 
        scoreText.text = string.Concat("Score is : ", score);
    }


    public int getScore()
    {
        return score;
    }
}

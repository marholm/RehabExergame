using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Feedback : MonoBehaviour
{
    public static Feedback instance;
    //public Text scoreText;
    //public Text highScoreText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    int score = 0;
    int highScore = 0;
    [HideInInspector] StopOnCollision stopOnCollision;
    
    void Awake()
    {
        // set an instance of this script even before the start of the game
        instance = this;
    }

    void Start()
    {
        highScore = PlayerPrefs.GetInt("highscore", 0);
        // reset counter
        scoreText.text = score.ToString() + " POINTS";
        highScoreText.text = "HIGHSCORE: " + highScore.ToString();
    }

    public void AddPoint()
    {
        // calculate and save player score
        score += 1;
        scoreText.text = score.ToString() + " POINTS";

        if (highScore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }



    }
}

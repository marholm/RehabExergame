using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Score Manager script that counts points and tracks the highscore
/// </summary>

public class Feedback : MonoBehaviour
{
    public static Feedback instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    int score = 0;
    int highScore = 0;
    
    void Awake()
    {
        // set an instance of this script even before the start of the game
        instance = this;
    }

    void Start()
    {
        highScore = PlayerPrefs.GetInt("highscore", 0);
        
        // reset counter at start of each game
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

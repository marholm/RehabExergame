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
    public TextMeshProUGUI scoreTextMovement_1;
    public TextMeshProUGUI scoreTextMovement_2;
    public TextMeshProUGUI highScoreText;
    int scoreMovement_1 = 0;
    int scoreMovement_2 = 0;
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
        scoreTextMovement_1.text = scoreMovement_1.ToString() + " POINTS";
        scoreTextMovement_2.text = scoreMovement_2.ToString() + " POINTS";
        highScoreText.text = "HIGHSCORE: " + highScore.ToString();
    }

    public void AddPointMovement_1()
    {
        // calculate and save player score
        scoreMovement_1 += 1;
        scoreTextMovement_1.text = scoreMovement_1.ToString() + " POINTS";

        if (highScore < (scoreMovement_1 + scoreMovement_2))
        {
            PlayerPrefs.SetInt("highscore", (scoreMovement_1 + scoreMovement_2));
        }
    }

    public void AddPointMovement_2()
    {
        // calculate and save player score
        scoreMovement_2 += 1;
        scoreTextMovement_2.text = scoreMovement_2.ToString() + " POINTS";

        if (highScore < (scoreMovement_1 + scoreMovement_2))
        {
            PlayerPrefs.SetInt("highscore", (scoreMovement_1 + scoreMovement_2));
        }
    }
}

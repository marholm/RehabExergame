using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;    // Only one version of this variable and no copies can be made of it
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                // do something
            }
        }
    }

    public bool _isGameOver;
    

    
    // determine when a game is over

    // restart the game 


    void Awake()
    {

    }



    public void GameOver(bool flag)
    {
        _isGameOver = flag;
    }

    public bool IsGameOver()
    {
        return _isGameOver;
    }

}

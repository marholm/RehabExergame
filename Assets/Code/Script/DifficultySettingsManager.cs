using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DifficultySettingsManager : MonoBehaviour
{
    //private Dropdown dropdown;
    public TMPro.TMP_Dropdown dropdown;
    [HideInInspector] static public int spawnRepetitions = 5;    // how many spawns in a game, default 5
    [HideInInspector] static public float spawnDelay = 5;        // how fast new fruit spawns, default 5

    void Awake()
    {
        dropdown = GetComponent<TMPro.TMP_Dropdown>();
    }

    public void SetDifficultySettings()
    {
        // change variables in the spawner script
        if (dropdown.value == 0)
        {
            // do easy mode
            spawnRepetitions = 10;
            spawnDelay = 20f;
            Debug.Log("Set to EASY mode");
        }
        else if (dropdown.value == 1)
        {
            // do medium mode
            spawnRepetitions = 15;
            spawnDelay = 10f;
            Debug.Log("Set to MEDIUM mode");
        }
        else if (dropdown.value == 2)
        {
            // do hard mode
            spawnRepetitions = 20;
            spawnDelay = 5f; 
            Debug.Log("Set to HARD mode");
        }
    }
}

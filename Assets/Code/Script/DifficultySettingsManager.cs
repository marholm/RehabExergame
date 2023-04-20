using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultySettingsManager : MonoBehaviour
{
    public int spawnRepetitions;    // how many spawns in a game

    public int spawnFrequency;      // how fast new fruit spawns

    public void SetSpawnRepetitions(int newSpawnRepetition)
    {
        spawnRepetitions = newSpawnRepetition;
    }

    public void SetSpawnFrequency(int newSpawnFrequency)
    {
        spawnFrequency = newSpawnFrequency;
    }

    public void SetDifficultySettings()
    {
        // change variables in the spawner script
    }









}

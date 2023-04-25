using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Spawns fruit objects at random locations
/// </summary>

public class Spawner : MonoBehaviour
{
    public GameObject[] fruitsPrefab;
    public GameObject peanutPrefab;
    [HideInInspector] public StopOnCollision stopOnCollision;
    private float delayTime = 0;
    private int totalRepetitions;
    
    
    void Awake()
    {
        // use to stop spawner when a fruit is caught
        stopOnCollision = GetComponent<StopOnCollision>();

        // Get the difficulty settings from DifficultyManager
        delayTime = DifficultySettingsManager.spawnDelay;
        totalRepetitions = DifficultySettingsManager.spawnRepetitions;        
    }
    
    void Start()
    {
        Debug.Log("SPAWN DELAY TIME: " + delayTime);
        Debug.Log("SPAWN REPETITIONS: " + totalRepetitions);
        StartCoroutine(SpawnRandomGameObject());
    }

    IEnumerator SpawnRandomGameObject()
    {
        yield return new WaitForSeconds(Random.Range(1, 2));
        int randomFruitIndex = Random.Range(0, fruitsPrefab.Length);
        //Vector3 randomSpawnPosition = new Vector3(Random.Range(-1,2), 4, Random.Range(-1,2));
        Vector3 randomSpawnPosition = new Vector3(0, 4, 0);                                                        // Force position of spawns to always hit player (for testing)

        
        if (Random.value <= .6f)
        {
            Instantiate(fruitsPrefab[randomFruitIndex], randomSpawnPosition, Quaternion.identity);
        }
        
        else
        {
            Instantiate(peanutPrefab, randomSpawnPosition, Quaternion.identity);
        }

        yield return new WaitForSeconds(delayTime); // Wait time between each spawn
        StartCoroutine(SpawnRandomGameObject());
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

/// <summary>
/// Spawns fruit objects at random locations
/// </summary>

public class Spawner : MonoBehaviour
{
    public GameObject[] fruitsPrefab;
    [HideInInspector] public StopOnCollision stopOnCollision;
    private float delayTime = 0;
    private int totalRepetitions;
    
    
    void Awake()
    {
        // Use to stop spawner when a fruit is caught
        stopOnCollision = GetComponent<StopOnCollision>();

        // Get the difficulty settings from DifficultyManager
        delayTime = DifficultySettingsManager.spawnDelay;
        //delayTime = 5;
        
        totalRepetitions = DifficultySettingsManager.spawnRepetitions; 
        //totalRepetitions = 10;

    }
    
    void Start()
    {
        Debug.Log("Spawn delay time: " + delayTime);
        Debug.Log("Spawn repetitions: " + totalRepetitions);
        
        StartCoroutine(SpawnRandomGameObject());
    }

    IEnumerator SpawnRandomGameObject()
    {
        for (int i = 0; i < totalRepetitions; i++)
        {
            // Wait for a set time
            yield return new WaitForSeconds(delayTime);

            // Pick a fruit randomly   
            int randomFruitIndex = Random.Range(0, fruitsPrefab.Length);

            // Pick a random position for the fruit to spawn 
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-1.2f,1.2f), 4, Random.Range(0.1f,0.25f));

            //spawn a fruit prefab
            Instantiate(fruitsPrefab[randomFruitIndex], randomSpawnPosition, Quaternion.identity);
            Debug.Log("# spawns: " + i);
        }

        // End game by loading the credit scene
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Credits"); 
    }  
}


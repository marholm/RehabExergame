using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns fruit objects at random locations
/// </summary>

public class Spawner : MonoBehaviour
{
    public GameObject[] fruitsPrefab;
    public GameObject peanutPrefab;
    private float delayTime = 20f;

    [HideInInspector] public StopOnCollision stopOnCollision;
    
    void Awake()
    {
        // use to stop spawner when a fruit is caught
        stopOnCollision = GetComponent<StopOnCollision>();
    }
    
    void Start()
    {
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

        yield return new WaitForSeconds(delayTime); // Wait between each spawn
        StartCoroutine(SpawnRandomGameObject());
    }

}


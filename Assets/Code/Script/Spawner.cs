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
    //GameObject newFruit;
    private float delayTime = 3f;

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
        Vector3 randomSpawnPosition = new Vector3(0, 2, 0);

        
        if (Random.value <= .6f)
        {
            //GameObject newFruit = Instantiate(fruitsPrefab[randomFruitIndex], randomSpawnPosition, Quaternion.identity);      // Try: set instantiated prefab explicitly as a gameobject
            Instantiate(fruitsPrefab[randomFruitIndex], randomSpawnPosition, Quaternion.identity);
           
            //Instantiate(fruitsPrefab[1], randomSpawnPosition, Quaternion.identity);                                            // Test - spawn only apples
        }
        
        else
        {
            //GameObject newFruit = Instantiate(peanutPrefab, randomSpawnPosition, Quaternion.identity);
            Instantiate(peanutPrefab, randomSpawnPosition, Quaternion.identity);
        }

        yield return new WaitForSeconds(delayTime); // Wait between each spawn
        StartCoroutine(SpawnRandomGameObject());
    }

}


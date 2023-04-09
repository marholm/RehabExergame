using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns fruit objects at random locations
/// </summary>

public class Spawner : MonoBehaviour
{
    public GameObject[] fruits;
    public GameObject peanutBomb;
    private float delayTime = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRandomGameObject());
    }

    IEnumerator SpawnRandomGameObject()
    {
        yield return new WaitForSeconds(Random.Range(1, 2));
        int randomFruitIndex = Random.Range(0, fruits.Length);
        //Vector3 randomSpawnPosition = new Vector3(Random.Range(-1,2), 4, Random.Range(-1,2));
        Vector3 randomSpawnPosition = new Vector3(0, 2, 0);

        
        if (Random.value <= .6f)
        {
            Instantiate(fruits[randomFruitIndex], randomSpawnPosition, Quaternion.identity);    // Use this in the final result
            //Instantiate(fruits[0], randomSpawnPosition, Quaternion.identity);                 // Test - spawn only apples
        }
        
        else
        {
            Instantiate(peanutBomb, randomSpawnPosition, Quaternion.identity);
        }
        
        yield return new WaitForSeconds(delayTime); // Wait time between each spawn
        StartCoroutine(SpawnRandomGameObject());
    }

}


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
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRandomGameObject());
    }

    IEnumerator SpawnRandomGameObject()
    {
        yield return new WaitForSeconds(Random.Range(1, 2));
        int randomFruitIndex = Random.Range(0, fruits.Length);
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-10,11), 5, Random.Range(-10,11));

        
        if (Random.value <= .6f)
        {
            Instantiate(fruits[randomFruitIndex], randomSpawnPosition, Quaternion.identity);
        }
        
        else
        {
            Instantiate(peanutBomb, randomSpawnPosition, Quaternion.identity);
        }
        
        StartCoroutine(SpawnRandomGameObject());
    }

}


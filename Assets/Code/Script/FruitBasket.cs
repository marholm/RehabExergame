using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Add points for completing Movement 2 by taking the fruit to the basket after its been caught.
/// </summary>
public class FruitBasket : MonoBehaviour
{
    [HideInInspector] public StopOnCollision stopOnCollision; 
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Basket collides with: " + other.gameObject.tag);

        if (other.gameObject.tag == "SpawnedFruit")
        {   
            Feedback.instance.AddPointMovement_2();     // Add point for movement 2
            Destroy(other.gameObject);
        }
    }

    void Update()
    {
        if (stopOnCollision.caughtByLeft || stopOnCollision.caughtByRight)
        {
            // oncollisionenter();
        }
    }
}

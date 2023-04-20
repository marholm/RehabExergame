using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceInBasket : MonoBehaviour
{
    [HideInInspector] public StopOnCollision stopOnCollision;
    
    void Start()
    {
        if (stopOnCollision is null)
        {
            stopOnCollision = GetComponent<StopOnCollision>();
        }
    }

    void OnTriggerEnter(Collider other)
    {   
        // Check if fruit has been caught AND if it has hit the Basket   
        if ((stopOnCollision.caughtByLeft || stopOnCollision.caughtByRight) && (other.gameObject.tag == "FruitBasket"))
        {
            Debug.Log("FRUIT HIT BASKET. ADD POINT MOVEMENT 2");
            Feedback.instance.AddPointMovement_2();     // Add point for movement 2
            Debug.Log("DESTROY THIS FRUIT");
            Destroy(this.gameObject);
        }
    }
}

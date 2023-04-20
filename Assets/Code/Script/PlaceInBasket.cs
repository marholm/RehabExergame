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

    /*void OnTriggerEnter(Collider other)
    {
        Debug.Log("FRUIT collides with: " + other.gameObject.tag);
        
        if (stopOnCollision.caughtByLeft || stopOnCollision.caughtByRight)
        {
            Debug.Log("Fruit has been caught. Check if its triggered by the Basket.");
            
            if (other.gameObject.tag == "FruitBasket")
            {   
                Debug.Log("FRUIT HIT BASKET. ADD POINT MOVEMENT 2");
                Feedback.instance.AddPointMovement_2();     // Add point for movement 2
                Debug.Log("DESTROY THIS FRUIT");
                Destroy(this.gameObject);
            }
        }
    }*/

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("FRUIT collides with: " + other.gameObject.tag);
        
        if ((stopOnCollision.caughtByLeft || stopOnCollision.caughtByRight) && (other.gameObject.tag == "FruitBasket"))
        {
            Debug.Log("FRUIT HIT BASKET. ADD POINT MOVEMENT 2");
            Feedback.instance.AddPointMovement_2();     // Add point for movement 2
            Debug.Log("DESTROY THIS FRUIT");
            Destroy(this.gameObject);
        }
    }
}

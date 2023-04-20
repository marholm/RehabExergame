using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopOnCollision : MonoBehaviour
{   
    public Rigidbody rb;
    [HideInInspector] public bool caughtByLeft = false;
    [HideInInspector] public bool caughtByRight = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }
    
    void OnCollisionEnter(Collision other)
    {
        Debug.Log(gameObject.tag + " collides with " + other.gameObject.tag); 
        if (other.gameObject.tag == "Player")                                                           // TODO!: == LeftHand
        {
            Feedback.instance.AddPointMovement_1();                                                               // Add point to score
            Debug.Log("Fruit caught by LeftHand!");
            rb.isKinematic = true;
            caughtByLeft = true;
            
        }
        else if (other.gameObject.tag == "RightHand")   
        {
            Feedback.instance.AddPointMovement_1();
            Debug.Log("Fruit caught by RightHand!");
            rb.isKinematic = true;
            caughtByRight = true;
        }
    }
}

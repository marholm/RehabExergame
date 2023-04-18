using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopOnCollision : MonoBehaviour
{   
    public Rigidbody rb;
    //public GameObject newFruit; 
    [HideInInspector] public bool caughtByLeft = false;
    [HideInInspector] public bool caughtByRight = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }
    
    void OnCollisionEnter(Collision other)
    {
        Debug.Log(gameObject.tag + " collides with " + other.gameObject.tag); 
        // TODO!: if ((other.gameObject.tag == "LeftHand") || (other.gameObject.tag == "RightHand"))
        if (other.gameObject.tag == "Player")                                                           // TODO!: == LeftHand
        {
            Feedback.instance.AddPoint();                                                               // Add point to score
            Debug.Log("Fruit caught by LeftHand!");
            rb.isKinematic = true;
            caughtByLeft = true;
            
        }
        else if (other.gameObject.tag == "RightHand")   
        {
            Debug.Log("Fruit caught by RightHand!");
            rb.isKinematic = true;
            caughtByRight = true;
        }
    }
}

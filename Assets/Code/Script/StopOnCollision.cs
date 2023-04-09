using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopOnCollision : MonoBehaviour
{   
    public Rigidbody rb;
    [HideInInspector] public bool isCaught = false;   
    [HideInInspector] public bool caughtByLeftHand = false;
    [HideInInspector] public bool caughtByRightHand = false;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
    }
    
    void OnCollisionEnter(Collision other)
    {
        // Debug.Log(gameObject.tag + " collides with " + other.gameObject.tag); 
        // TODO!: if ((other.gameObject.tag == "LeftHand") || (other.gameObject.tag == "RightHand"))
         if ((other.gameObject.tag == "Player"))
        {
            isCaught = true;
            rb.isKinematic = true;
            
            if (other.gameObject.tag == "Player")   // TODO!: == LeftHand
            {
                Debug.Log("Fruit caught by LeftHand!");
                rb.isKinematic = true;
                caughtByLeftHand = true;
            }
            else if (other.gameObject.tag == "RightHand")   // ? EVT: Bare ha else
            {
                Debug.Log("Fruit caught by RightHand!");
                rb.isKinematic = true;
                caughtByRightHand = true;
            }
        }
    }

    // Let the rigidbody take control and detect collisions.
    void EnableRagdoll()
    {
        rb.isKinematic = false;
        rb.detectCollisions = true;
    }

    // Let animation/ script control the rigidbody and ignore collisions.
    void DisableRagdoll()
    {
        rb.isKinematic = true;
        rb.detectCollisions = false;
    }

    /*
    // Makes fruit stop on collision with anything:
    void Awake()
    {
	    rb = GetComponent<Rigidbody> ();
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log(gameObject.tag + " COLLIDES WITH " + other.gameObject.tag);
	    rb.isKinematic = true;
    }
    */
}

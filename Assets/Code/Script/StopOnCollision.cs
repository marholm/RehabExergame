using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopOnCollision : MonoBehaviour
{
    // TODO: Change script so isKinematic only turn on when fruit collides with gameobject with tag LeftHand OR RightHand!
    private Rigidbody rb;
    public bool isCaught = false;   // må være public så follower scriptet kan bruke den
    
    /*
    // Makes fruit stop on collision with anything
    void Awake()
    {
	    rb = GetComponent<Rigidbody> ();
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log(gameObject.tag + " COLLIDES WITH " + other.gameObject.tag);
	    rb.isKinematic = true;
    }*/
    
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void OnCollisionEnter(Collision other)
    {
        Debug.Log(gameObject.tag + " COLLIDES WITH " + other.gameObject.tag);
        // Endre tag til LeftHand og RightHand når du er ferdig teste
         if (other.gameObject.tag == "Player")
        {
            rb.isKinematic = true;
            isCaught = true;
            //Debug.Log("STOP game object movement");
        }
    }
    /*void OnCollisionStay(Collision other)
    {
        //Debug.Log(gameObject.tag + " COLLIDES WITH " + other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            rb.isKinematic = true;
            //Debug.Log("STOP game object movement");
        }
    }*/
}

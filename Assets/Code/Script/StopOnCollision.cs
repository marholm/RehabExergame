using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopOnCollision : MonoBehaviour
{
    // TODO: Change script so isKinematic only turn on when fruit collides with gameobject with tag LeftHand OR RightHand!
    private Rigidbody rb;
    
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
    
    
    
    // This code does NOT function the same way as the code above. Not quite sure why.
    // Might want to make it work later, now it stops on contact with any collider, bu ideally it should only stop on contact with hands. 
    
    void Awake()
    {
        rb = GetComponent<Rigidbody> ();
    }
    
    void OnCollisionEnter(Collision other)
    {
        Debug.Log(gameObject.tag + " COLLIDES WITH " + other.gameObject.tag);
         if (other.gameObject.tag == "Player")
        {
            rb.isKinematic = true;
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

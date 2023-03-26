using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopOnCollision : MonoBehaviour
{
    
    private Rigidbody rb;

    void Awake()
    {
	    rb = GetComponent<Rigidbody> ();
    }

    void OnCollisionEnter()
    {
	    rb.isKinematic = true;
        Debug.Log("TURN ON isKINEMATIC");
    }
    
    /*
    // This code does NOT function the same way as the code above. Not quite sure why.
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<Rigidbody>().isKinematic = true;
            Debug.Log("TURN OFF KINEMATIC ");
        }
    }*/
    

   



}

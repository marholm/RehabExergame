using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FollowPlayer : MonoBehaviour
{
    public Rigidbody rb;
    
    [HideInInspector] public StopOnCollision stopOnCollision; 

    public Transform targetLeft; 
    public Transform targetRight; 
    
    //Vector3 direction;
    //public float speed = 2f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetLeft = GameObject.FindWithTag("LeftHand").GetComponent<Transform>();
        targetRight = GameObject.FindWithTag("RightHand").GetComponent<Transform>();

        if (stopOnCollision is null)
        {
            stopOnCollision = GetComponent<StopOnCollision>();
        }
    }

    /*void Update()
    {
        // Should I use MovePosition in FixedUpdate() isntead since it matches the timesteps of the physics engine
        // Debug.Log("Referenced object: " + stopOnCollision);

        if (stopOnCollision.caughtByLeft)
        {
            rb.MovePosition(targetLeft.position);
        }
        else if (stopOnCollision.caughtByRight)
        {
            rb.MovePosition(targetRight.position);
        }
    }*/

    
    void FixedUpdate()
    {
        // rb.MovePosition(targetLeft.position);     

        if (stopOnCollision.caughtByLeft)
        {
            rb.MovePosition(targetLeft.position);
        }
        else if (stopOnCollision.caughtByRight)
        {
            rb.MovePosition(targetRight.position);
        }
    }
    
}


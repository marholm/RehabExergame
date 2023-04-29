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
 
    void FixedUpdate()
    {   
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


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FollowPlayer : MonoBehaviour
{
    public Rigidbody rb;
    
    [HideInInspector] public StopOnCollision stopOnCollision; 

    [HideInInspector] public Transform targetLeft; 
    
    [HideInInspector] public Transform targetRight; 
    Vector3 direction;
    public float speed = 2f;

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

    void Update()
    {
        Debug.Log("Referenced object: " + stopOnCollision);
        if (stopOnCollision.caughtByLeft)
        {
            followLeftTarget();
        }
        else if (stopOnCollision.caughtByRight)
        {
            followRightTarget();
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);     
    }

    void followLeftTarget()
    {
        direction = (targetLeft.position - transform.position).normalized;
        Debug.Log("Follow LEFT hand");
        Debug.Log("Kinematic set to: "+ rb.isKinematic);
    }

    void followRightTarget()
    {
        direction = (targetRight.position - transform.position).normalized;
        Debug.Log("Follow RIGHT hand");
        Debug.Log("Kinematic set to: "+ rb.isKinematic);
    }
    
    /*
    void FollowTarget()
    {
        if (stopOnCollision.isCaught)
        {
            if (stopOnCollision.caughtByLeftHand)
            {
                Debug.Log("Follow LEFT hand");
                Debug.Log("is kinematic set to "+ rb.isKinematic);
                direction = (targetLeft.position - transform.position).normalized;
            }

            else if (stopOnCollision.caughtByRightHand)
            {
                Debug.Log("Follow RIGHT hand");
                direction = (targetRight.position - transform.position).normalized;
            }
        }
    }
    */
}


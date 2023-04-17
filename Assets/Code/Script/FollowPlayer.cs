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
        //rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);     
        rb.MovePosition(targetLeft.position);     
    }

    void followLeftTarget()
    {
        direction = (targetLeft.position - transform.position).normalized;
        Debug.Log("Follow LEFT hand");
    }

    void followRightTarget()
    {
        direction = (targetRight.position - transform.position).normalized;
        Debug.Log("Follow RIGHT hand");
    }
    
    
    
    // EMANUELS FORSLAG

        /*void Awake()
    {
        targetLeft = GameObject.FindWithTag("LeftHand").GetComponent<Transform>();
    }

    void Start()
    {
        if (stopOnCollision is null)
        {
            stopOnCollision = GetComponent<StopOnCollision>();
        }
    }

    void Update()
    {
        if (stopOnCollision.caughtByLeft)
        {
            transform.position = targetLeft.position;
            transform.rotation = targetLeft.rotation;
        }
    }*/
}


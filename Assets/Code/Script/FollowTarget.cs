using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{   
    [HideInInspector] public Transform targetTransform;
    Vector3 direction; 
    public Rigidbody rb;
    public float m_Speed = 2f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        targetTransform = GameObject.FindWithTag("LeftHand").GetComponent<Transform>();
    }
    void Update()
    {
        direction = (targetTransform.position - transform.position).normalized;
    }
    void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction * m_Speed * Time.fixedDeltaTime);  
        // Debug.Log("TargetPos: " + targetTransform.position);
    }
}

// Ting jeg har prøvd:
        //transform.Translate(targetMovement, Space.Self);
        
        //transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
        //transform.rotation = target.transform.rotation;
        //Debug.Log(transform.position + " : " + target.transform.position);

        // Try using localPosition  - total failure dont use localPosition
        //transform.position = target.transform.localPosition;
        
        
        
        // TRY: using MovePosition
        //rb.MovePosition(target.transform.position);
        //rb.MovePosition(targetTransform.position); 
        //rb.MovePosition(rbTargetPos);
        //rb.MoveRotation(target.transform.rotation);
        // Unity documentation of Moveposition
        // Vector3 m_Input = new Vector3(rbTargetPos.x, rbTargetPos.y, rbTargetPos.z);
        // rb.MovePosition(transform.position + m_Input * Time.deltaTime * m_Speed);

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
    }
}

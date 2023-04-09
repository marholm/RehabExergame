using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPosition : MonoBehaviour
{
    public Rigidbody rb;
    Transform tran;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tran = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log("transform.localPosition of " + gameObject.tag + ": " + transform.localPosition);
        Debug.Log("transform.position of " + gameObject.tag + ": " + transform.position);
        Debug.Log("rb position of " + gameObject.tag + rb.position);
        Debug.Log("tran position of " + gameObject.tag + tran.position);
        Debug.Log("centerofmass pos: " + rb.worldCenterOfMass);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHMDPosition : MonoBehaviour
{
    Transform targetTransform;
    Vector3 scalePosition = new Vector3(0, 0, -2);
    
    
    // Start is called before the first frame update
    void Start()
    {
        // Kanskje target må være back of head?
        targetTransform = GameObject.FindWithTag("Head").GetComponent<Transform>();
        // targetTransform = GameObject.FindWithTag("CamPosition").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (targetTransform.position + scalePosition);
        Debug.Log("Move camera here: " + transform.position);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHMDPosition : MonoBehaviour
{
    Transform targetTransform;
    
    
    // Start is called before the first frame update
    void Start()
    {
        // targetTransform = GameObject.FindWithTag("XROrigin").GetComponent<Transform>();
        targetTransform = GameObject.FindWithTag("Head").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = targetTransform.position;
    }
}

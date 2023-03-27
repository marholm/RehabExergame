using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FollowPlayer : MonoBehaviour
{
    //public Transform caughtFruitPosition;
    //public Transform rHandPosition; // = GameObject.FindGameObjectWithTag("RightHand").GetComponent<Transform>();
    //public Transform lHandPosition; // = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<Transform>();

    public Transform testTarget; 
    Vector3 testVectorPosition;
    //float mSpeed = 10.0f;

    void Awake()
    {
        testTarget = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<Transform>();
    }

    void Update()
    {
        // transform.position er position til objektet scriptet er festet til
        testVectorPosition = (testTarget.position - transform.position).normalized;
        //transform.Translate(testVectorPosition * Time.deltaTime * mSpeed);

    
    }

    

    /*
    public Transform objectToFollow;
    public Vector3 offset;
    void Update()
    {
    transform.position = objectToFollow.position + offset;
    }
*/
    // private bool isCaught;
    // player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    void followHandMovement()
    {
        // Hvis den ble stoppet av høyre hånd
        //caughtFruitPosition = rHandPosition;

        //caughtFruitPosition = lHandPosition;
    }

}

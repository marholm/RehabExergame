using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FollowPlayer : MonoBehaviour
{
    
    public StopOnCollision stopOnCollision; // ii vet ikke om den kan være private
    
    [HideInInspector]
    public Transform objectToFollow_1; // transform of target object to follow 1 - LEFT hand
    
    [HideInInspector]
    public Transform objectToFollow_2; // transform of target object to follow 2 - RIGHT hand

     void Awake()
    {
        // Ingen forskjell på FindWithTag og FingGameObjectWithTag ifølge Unity forum
        objectToFollow_1 = GameObject.FindWithTag("LeftHand").GetComponent<Transform>();
        objectToFollow_2 = GameObject.FindWithTag("RightHand").GetComponent<Transform>();
    }
    
    void Update()
    {
        if (stopOnCollision.isCaught)
        {
            Debug.Log("Fruit caught!");
            if (objectToFollow_1.CompareTag("LeftHand"))
            {
                // transform.position - position til objektet scriptet festes til
                Debug.Log("Follow LEFT hand");
                transform.position = objectToFollow_1.position;
            }
            else 
            {
                Debug.Log("Follow RIGHT hand");
                transform.position = objectToFollow_2.position;
            }

        }
    }

    /*
    public Transform target; // target to follow
    Vector3 follower; // follower vector 
    public Vector3 offset;  // buffer
    
    void Update()
    {
        // transform.position er position til objektet scriptet er festet til
        follower = (target.position - transform.position).normalized;
    }
    
    void Update()
    {
        transform.position = objectToFollow.position + offset;
    }
    */

}

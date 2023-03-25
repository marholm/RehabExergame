using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class defines the interaction between user and gameObjects
/// User can reach to catch a falling spawned object
/// User can put spawned object in head-basket
/// </summary>
public class UserInteraction : MonoBehaviour
{
    /*
    public bool isCaught = false;
    Vector3 rightHandPosition;
    Vector3 leftHandPosition;

    void Update()
    {
        // Getposition to skeleton - Does not provide the real position, maybe bc the transform gives the set coordinates
        //Debug.Log("Player right hand position: " + GameObject.FindGameObjectWithTag("Hand").transform.position);
        //Debug.Log("Player right wrist position: " + GameObject.FindGameObjectWithTag("Wrist").transform.position);
        //Debug.Log("Player chest position: " + GameObject.FindGameObjectWithTag("Chest").transform.position);
    }
    */

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SpawnedFruit")
        {
            // isCaught = true;
            Debug.Log("USER CAUGHT GAME OBJECT");
        }

    }


}

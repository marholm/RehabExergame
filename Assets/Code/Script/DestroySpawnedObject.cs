using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Destroys all SpawnedFruit objects upon collision
/// </summary>
public class DestroySpawnedObject : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("Plane collides with: " + collision.gameObject.tag);
        if (collision.gameObject.tag == "SpawnedFruit")
        {   
            Destroy(collision.gameObject);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feedback : MonoBehaviour
{

    [HideInInspector] StopOnCollision stopOnCollision;
    public float scoreCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void playerScore()
    {
        // calculate and save player score
        if (stopOnCollision.isCaught)
        {
            scoreCounter += 1;
        }

    }
}

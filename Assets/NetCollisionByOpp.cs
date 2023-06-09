using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetCollisionByOpp : MonoBehaviour
{
    //public int scoreValue = 1; // Score value to add when collected
    public ScoreManager scoreManager; // Reference to the ScoreManager script
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
    	//scoreManager.IncrementOpponentScore();
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Increase the score when the player collects the object
            scoreManager.IncrementPlayerScore();
            //Destroy(gameObject); // Destroy the collectible object
        }
        // if (collision.gameObject.CompareTag("Plane_red"))
        // {
        //     // Increase the score when the player collects the object
        //     scoreManager.IncrementPlayerScore();
        //     //Destroy(gameObject); // Destroy the collectible object
        // }
    }
}




using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDetectorWin : MonoBehaviour
{
    //public int scoreValue = 1; // Score value to add when collected
    public ScoreManager scoreManager; // Reference to the ScoreManager script
    public bool hasCollision = false;
    private float elapsedTime = 0f;
    private float collisionTimeThreshold = .1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(hasCollision && elapsedTime > collisionTimeThreshold){
            hasCollision = false;
            scoreManager.IncrementOpponentScore();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
    	//scoreManager.IncrementOpponentScore();
        if (collision.gameObject.CompareTag("Ball") && !hasCollision)
        {
            hasCollision = true;
            elapsedTime = 0f;
            // Increase the score when the player collects the object
            //scoreManager.IncrementOpponentScore();
            //Destroy(gameObject); // Destroy the collectible object
        }
    }
}




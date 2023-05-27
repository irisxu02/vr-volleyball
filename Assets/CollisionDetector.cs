using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Valleyball"))
        {
            // Increase the score when the player collects the object
            scoreManager.IncrementOpponentScore();
            //Destroy(gameObject); // Destroy the collectible object
        }
    }
}

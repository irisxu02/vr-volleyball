using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScoring : MonoBehaviour
{
    public ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ball scoring started");
    }

    // Opponent scoring zone is opponent's side of court (so the player will try to score there)
    // Player scoring zone is player's side of court (so opponent will try to score there)
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("OpponentScoringZone")) {
            scoreManager.IncrementPlayerScore();
        }
        else if (collision.gameObject.CompareTag("PlayerScoringZone")) {
            scoreManager.IncrementOpponentScore();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

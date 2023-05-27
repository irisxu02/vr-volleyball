using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int playerScore = 0;
    public int opponentScore = 0;

    public Text playerScoreText;
    public Text opponentScoreText;

    public bool isGameFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreUI();
    }

    public void IncrementPlayerScore() {
        playerScore++;
        UpdateScoreUI();
        CheckWinCondition();
    }

    public void IncrementOpponentScore() {
        opponentScore++;
        UpdateScoreUI();
        CheckWinCondition();
    }

    // Update is called once per frame
    void UpdateScoreUI()
    {
        playerScoreText.text = playerScore.ToString();
        opponentScoreText.text = opponentScore.ToString();
    }

    // Game finished if reached 25 points with a minimunm 2 point lead.
    private void CheckWinCondition() {
        if (!isGameFinished) {
            if (playerScore >= 25 && playerScore - opponentScore >= 2) {
                Debug.log("player win");
                isGameFinished = true;
            }
            else if (opponentScore >= 25 && opponentScore - playerScore >= 2) {
                Debug.log("opponent win");
                isGameFinished = true;
            }
        }
    }

    public void ResetScores() {
        playerScore = 0;
        opponentScore = 0;
        isGameFinished = false;
        UpdateScoreUI();
    }

}

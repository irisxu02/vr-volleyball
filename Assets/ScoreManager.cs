using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int playerScore = 0;
    public int opponentScore = 0;

    public TMPro.TextMeshProUGUI playerScoreText;
    public TMPro.TextMeshProUGUI opponentScoreText;
    public TMPro.TextMeshProUGUI winUI;
    public TMPro.TextMeshProUGUI lossUI;

    public BallGenerator BallGenerator;

    public bool isGameFinished = false;

    public AudioSource win;
    public AudioSource lose;


    // Start is called before the first frame update
    void Start()
    {
        win = GetComponent<AudioSource>();
        lose = GetComponent<AudioSource>();
        UpdateScoreUI();
    }

    public void IncrementPlayerScore() {
        playerScore++;
        BallGenerator.DestroyBall();
        UpdateScoreUI();
        CheckWinCondition();
    }

    public void IncrementOpponentScore() {
        opponentScore++;
        BallGenerator.DestroyBall();
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
            if (playerScore >= 10 && playerScore - opponentScore >= 2) {
                //Debug.log("player win");
                isGameFinished = true;
                winUI.alpha = 1;
                win.Play();
            }
            else if (opponentScore >= 10 && opponentScore - playerScore >= 2) {
                //Debug.log("opponent win");
                isGameFinished = true;
                lossUI.alpha = 1;
                lose.Play();
            }else{
            	BallGenerator.GenerateBall();
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

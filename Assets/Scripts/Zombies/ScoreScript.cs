using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreText2;
    public TextMeshProUGUI scoreText3;
    public TextMeshProUGUI scoreNext;
    public int score = 0;
    public GameObject winui;
    private bool hasWon = false;

    public void AddScore(int points)
    {
        score += points;
        hasWon = false;
        scoreText.text = "Score: " + score;
        scoreText2.text = "Your Score: " + score;
        scoreText3.text = "Your Score: " + score;
        Debug.Log(scoreText);
        CheckWinCondition();
    }

    private void CheckWinCondition()
    {
        if (!hasWon && score == 500)
        {
            Time.timeScale = 0f;
            hasWon = true;
            winui.SetActive(true); // Show the win UI object
            scoreNext.text = "Next prize is at 2000";
        }

        if (!hasWon && score == 2000)
        {
            Time.timeScale = 0f;
            scoreNext.text = "Nex prize is at 5000";
            hasWon = true;
            winui.SetActive(true);
        }
        if (!hasWon && score == 5000)
        {
            Time.timeScale = 0f;
            scoreNext.text = "Nex prize is at 10000";
            hasWon = true;
            winui.SetActive(true);
        }
        if (!hasWon && score == 10000)
        {
            Time.timeScale = 0f;
            scoreNext.text = "Nex prize is at 50000";
            hasWon = true;
            winui.SetActive(true);
        }
        if(!hasWon && score == 50000)
        {
            Time.timeScale = 0f;
            scoreNext.text = "Nex prize is at 50000";
            hasWon = true;
            winui.SetActive(true);
        }
    }
}

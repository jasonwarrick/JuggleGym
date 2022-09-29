using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] GameObject gameEventHandler;

    int score = 0;
    [SerializeField] float scoreFactor;
    public int Score { get { return score; } }
    [SerializeField] int health = 3;
    // int mainMenuIndex = 0;

    void Awake() {
        score = 0;
        UpdateText();
    }

    public void IncreaseScore(float yPos) {
        yPos += 4; // Makes the lowest point 0 instead of a negative
        score += 25 - (int) (yPos * scoreFactor); // The lower the ball is when it is hit, the less is subtracted from the score

        UpdateText();
    }

    public void DamageHealth() {
        health -= 1;

        if (health == 0) {
            gameEventHandler.GetComponent<GameEventHandler>().EndGame();
        }

        UpdateText();
    }

    public void DecreaseScore() {
        score -= 25;
        if (score < 0) {
            DamageHealth();
            score = 0;
        }

        UpdateText();
    }

    private void UpdateText() {
        scoreText.text = score.ToString();
        healthText.text = health.ToString();
    }
}

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
    public int Score { get { return score; } }
    int health = 3;
    // int mainMenuIndex = 0;

    void Awake() {
        score = 0;
        UpdateText();
    }

    public void IncreaseScore() {
        score += 25;
        Debug.Log(score);

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Experimental.Rendering.Universal;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject gameEventHandler;
    [SerializeField] Light2D redLight;

    int score = 0;
    [SerializeField] float scoreFactor;
    public int Score { get { return score; } }
    float health = 100;
    [SerializeField] float regenRate;
    [SerializeField] float damageValue;
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

    void FixedUpdate() {
        if (health < 100) {
            health += regenRate;
            redLight.intensity = (float) -((health / 33.3f) - 3f); // Normalize the health so it ranges from 0 to 3, and then invert it so it increases
        }

        UpdateText();
    }

    public void DamageHealth() {
        health -= damageValue;

        if (health <= 0) {
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
    }

    private void UpdateText() {
        scoreText.text = score.ToString();
    }
}

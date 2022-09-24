using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    int score = 0;

    void Awake() {
        score = 0;
        Debug.Log(score);
    }

    public void IncreaseScore() {
        score += 25;
        Debug.Log(score);
    }

    public void DecreaseScore() {
        score -= 10;
    }

    // Update is called once per frame
    void Update() {
        scoreText.text = score.ToString();
    }
}

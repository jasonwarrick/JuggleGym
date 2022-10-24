using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameEventHandler : MonoBehaviour
{
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject endUI;
    [SerializeField] GameObject gameUI;
    [SerializeField] TextMeshProUGUI finalScoreText;
    [SerializeField] GameObject scoreHandler;
    [SerializeField] GameObject touchController;
    
    bool paused;
    bool ended;
    int menuIndex = 0;
    int gameIndex = 1;
    
    // Start is called before the first frame update
    void Start() {
        Application.targetFrameRate = 60;
        Pause(false);
        ended = false;
        endUI.SetActive(false);
        touchController.SetActive(true);
    }

    public void Pause(bool pausing) {
        paused = pausing;
        
        if (paused) {
            Time.timeScale = 0;
        } else {
            Time.timeScale = 1;
        }

        pauseUI.SetActive(paused);
        gameUI.SetActive(!paused);
    }

    public void EndGame() {
        finalScoreText.text = "Score: " + scoreHandler.GetComponent<ScoreHandler>().Score.ToString();
        ended = true;
        Time.timeScale = 0.01f;
        pauseUI.SetActive(false);
        endUI.SetActive(true);
        gameUI.SetActive(false);
        touchController.SetActive(false);
    }

    public void MenuButton(int buttonCode) {
        switch (buttonCode) {
            case 0: // Resume game
                Pause(false);
                break;
            
            case 1: // Options
                break;

            case 2: // Main menu
                SceneManager.LoadScene(menuIndex);
                break;
            
            case 3: // Play Again
                SceneManager.LoadScene(gameIndex);
                break;
            
            default:
                break;
        }

        Debug.Log(buttonCode);
    }
}

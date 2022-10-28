using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class GameEventHandler : MonoBehaviour
{
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject endUI;
    [SerializeField] GameObject gameUI;
    [SerializeField] TextMeshProUGUI finalScoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI soundText1;
    [SerializeField] TextMeshProUGUI soundText2;
    [SerializeField] GameObject scoreHandler;
    [SerializeField] GameObject touchController;
    [SerializeField] AudioMixer audioMixer;
    
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
        UpdateSoundText();
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
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        finalScoreText.text = "Score: " + scoreHandler.GetComponent<ScoreHandler>().Score.ToString();

        ended = true;
        pauseUI.SetActive(false);
        endUI.SetActive(true);
        gameUI.SetActive(false);
        touchController.SetActive(false);

        Time.timeScale = 0.01f;
    }

    public void MenuButton(int buttonCode) {
        switch (buttonCode) {
            case 0: // Resume game
                Pause(false);
                break;

            case 1: // Options
                ToggleSound();
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

    void ToggleSound() {
        if (PlayerPrefs.GetInt("SFX", 0) == 0) { // Toggle audio on
            PlayerPrefs.SetInt("SFX", 1);
            audioMixer.SetFloat("SFXAudio", 1); // Audio code taken from: https://www.youtube.com/watch?time_continue=218&v=C1gCOoDU29M&feature=emb_title
        } else { // Toggle audio off
            audioMixer.SetFloat("SFXAudio", -80);
            PlayerPrefs.SetInt("SFX", 0);
        }

        UpdateSoundText();
    }

    void UpdateSoundText() {
        if (PlayerPrefs.GetInt("SFX", 0) == 1) { // Toggle audio on
            soundText1.text = "Sound ON";
            soundText2.text = "Sound ON";
        } else { // Toggle audio off
            soundText1.text = "Sound OFF";
            soundText2.text = "Sound OFF";
        }
    }
}

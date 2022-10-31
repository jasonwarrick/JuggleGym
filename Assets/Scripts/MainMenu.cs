using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI soundText;
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] TextMeshProUGUI highScore;

    [SerializeField] GameObject mainCanvas;
    [SerializeField] GameObject howToCanvas;

    bool howTo = false;
    int gameIndex = 1;

    void Awake() {
        Application.targetFrameRate = 60;
        highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    void Start() {
        SoundSetUp(); // Set up the audio levels in start, as it wasn't working properly in awake
    }

    public void PlayGame() {
        SceneManager.LoadScene(gameIndex);
    }

    void SoundSetUp() { // Separate function that sets the audio levels to the player prefs without changing them
        if (PlayerPrefs.GetInt("SFX", 0) == 0) {
            Debug.Log("Off");
            audioMixer.SetFloat("SFXAudio", -80); // Audio code taken from: https://www.youtube.com/watch?time_continue=218&v=C1gCOoDU29M&feature=emb_title
        } else { // Toggle audio off
            Debug.Log("On");
            audioMixer.SetFloat("SFXAudio", 1);
        }

        UpdateSoundText();
    }

    public void Options() {
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
            soundText.text = "Sound ON";
        } else { // Toggle audio off
            soundText.text = "Sound OFF";
        }
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void HowTo() { // Alternates between tutorial and main menu screens
        howTo = !howTo;
        mainCanvas.SetActive(!howTo);
        howToCanvas.SetActive(howTo);
    }
}

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


    int gameIndex = 1;

    void Awake() {
        Application.targetFrameRate = 60;
        UpdateSoundText();
    }

    public void PlayGame() {
        SceneManager.LoadScene(gameIndex);
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
}

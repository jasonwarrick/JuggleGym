using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    int gameIndex = 1;

    public void PlayGame() {
        SceneManager.LoadScene(gameIndex);
    }

    public void Options() {
        
    }

    public void ExitGame() {
        Application.Quit();
    }
}

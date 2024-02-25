using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public void Retry()
    {
        // Load the next scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }

    public void MainMenu()
    {
        // Quit the game
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
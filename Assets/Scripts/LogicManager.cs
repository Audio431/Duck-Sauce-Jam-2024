using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    public Text ScoreText;
    public GameObject gameOverScreen;
    public void AddScore()
    {
        score++;
        ScoreText.text = score.ToString();
    }
    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameOver()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }
}

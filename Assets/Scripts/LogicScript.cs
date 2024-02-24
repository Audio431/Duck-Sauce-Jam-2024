using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    public Text ScoreText;
    public void AddScore()
    {
        score++;
        ScoreText.text = score.ToString();
    }
}

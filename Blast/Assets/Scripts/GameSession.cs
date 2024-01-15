using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameSession : MonoBehaviour
{
    int score = 0;

    [SerializeField] TextMeshProUGUI scoreText;
    private void Update()
    {
        DisplayScore();
        
    }

    private void DisplayScore()
    {
        scoreText.text = score.ToString();
    }

    public void increaseScore(int points )
    {
        score += points;
        print(score);
    }
}

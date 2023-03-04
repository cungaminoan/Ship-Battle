using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public TextMeshProUGUI[] scoreText;
    private int score;
    private void Start()
    {
        score = 0;
        this.updateScore(0);
       
    }
   public void updateScore(int scoreToAdd)
    {
        score += scoreToAdd;

        scoreText[0].text = "Score: " + score;
        scoreText[1].text = "Score: " + score;
        scoreText[2].text = "Score: " + score;
    }
}

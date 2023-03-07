using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    private int scoreStep;
    public TextMeshProUGUI[] scoreText;
    [SerializeField] private GameObject[] spawners;
    private int score;
    private void Start()
    {
        scoreStep= 75;
        score = 0;
        this.updateScore(0);
       
    }
   public void updateScore(int scoreToAdd)
    {
        
        // DISPLAYS SCORE /////////////////////////////////////////
        score += scoreToAdd;
        scoreText[0].text = "Score: " + score;
        scoreText[1].text = "Score: " + score;
        scoreText[2].text = "Score: " + score;
        // CHANGES THE SPAWNER STATES ACCORDING TO SCORE /////////////
        if (score > 0 && score % scoreStep == 0) // Makes changes to the spawner every 25 points
        {
            scoreStep += 25; // As the game progresses, you need to gain more score to change the spawner states
            foreach (var spawner in spawners)
            {
                int state = Random.Range(0, 2); // Randomizes the state of the spawners
                if (spawner.activeSelf)
                {
                    spawner.SetActive(state == 1 ? true : false); // Set the state: 1 means "true" and != 1 means "false" 
                }
                else if (state == 1)
                {
                    spawner.SetActive(true); // Activate the already in active spawner. 
                }
                else
                {
                    continue; // If the spawner is already in the "in active" state, there's a chance that it will be left that way :D. 
                }
            }
        }
    }
}

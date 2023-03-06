using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField] private GameObject pausePannel, gameOverPannel;
    private bool isPaused;
    private void Awake()
    {
        MakeInstance();
    }

    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }    
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnPause();
        }
        if(gameOverPannel.activeSelf && Input.GetKeyDown(KeyCode.Space)) 
        {
            RestartButton(); // Behaves simillar to the button :D
        }
    }
    public void PauseUnPause()
    {
        if (!isPaused)
        {
            pausePannel.SetActive(true);

            isPaused = true;

            Time.timeScale = 0f;
        }
        else
        {
            pausePannel.SetActive(false);

            isPaused = false;

            Time.timeScale = 1f;
        }
    }
    public void ResumeButton()
    {
        PauseUnPause();
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }
   public void ShipDead()
    {
        Time.timeScale = 0f;
        gameOverPannel.SetActive(true);
    }
    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }


}

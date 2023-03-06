using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    private void Awake()
    {
        MakeInstance();
    }

    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }    
    [SerializeField]private GameObject pausePannel, gameOverPannel;

    public void PauseGameButton()
    {
        pausePannel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeButton()
    {
        pausePannel.SetActive(false);
        Time.timeScale = 1f;
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
    }


}

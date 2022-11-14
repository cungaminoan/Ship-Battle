using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void GameButton()
    {
        SceneManager.LoadScene("Game");

    }
    public void QuitButton()
    {
        Application.Quit();
    }
}

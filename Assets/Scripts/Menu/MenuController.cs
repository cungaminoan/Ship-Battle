using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private int index;
    public string[] konamiCode = { "up", "up", "down", "down", "left", "right", "left", "right", "b", "a" };

    private void Start()
    {
        index = 0;
    }
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(konamiCode[index]))
            {
                index++;
            }
            else index = 0;
        }
        if (index == konamiCode.Length)
        {
            Debug.Log("CheatCodeActiv");
            CheatCodeStats.instance.cooldown = 0.5f;
            index = 0;
        }
    }
    public void GameButton()
    {
        SceneManager.LoadScene("Game");

    }
    public void QuitButton()
    {
        Application.Quit();
    }
}

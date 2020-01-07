using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public GameObject WinPanel;
    public GameObject WrongPanel;
    public GameObject TimePanel;

    void Start()
    {
        instance = this;
    }

    public void PlayGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("Testing");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("Testing");
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GameWin()
    {
        Time.timeScale = 0f;

        WinPanel.SetActive(true);
    }

    public void WrongSuspectLose()
    {
        Time.timeScale = 0f;

        WrongPanel.SetActive(true);
    }

    public void TimeRanOutLose()
    {
        Time.timeScale = 0f;

        TimePanel.SetActive(true);
    }
}

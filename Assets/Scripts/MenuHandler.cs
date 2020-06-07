using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    static bool gameIsPaused = false;
    public GameObject pauseMenu;

    private GameObject mainText;
    private GameObject statsText;
    private GameObject resumRetryButton;
    private GameObject exitToMenuButton;

    private void Start()
    {
        mainText = pauseMenu.transform.GetChild(0).gameObject;
        statsText = pauseMenu.transform.GetChild(1).gameObject;
        resumRetryButton = pauseMenu.transform.GetChild(2).gameObject;
        exitToMenuButton = pauseMenu.transform.GetChild(3).gameObject;
        Resume();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                resumRetryButton.SetActive(true);
                resumRetryButton.transform.GetChild(0).GetComponent<Text>().text = "Resume";
                PauseGame();
            }
        }

        if (GameManager.Instance.IsGameOver)
        {
            resumRetryButton.SetActive(true);
            resumRetryButton.transform.GetChild(0).GetComponent<Text>().text = "Restart";
            PauseGame();
        }

        if (GameManager.Instance.IsGameWon)
        {
            resumRetryButton.SetActive(false);
            PauseGame();
        }
    }

    void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void ExitToMenuButtonPressed()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void ResumeRetryButtonPressed()
    {
        if (gameIsPaused)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            gameIsPaused = false;
        }
        else if (GameManager.Instance.IsGameOver)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }

    }

}

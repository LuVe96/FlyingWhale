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
            PauseGame();
            resumRetryButton.SetActive(true);
            mainText.GetComponent<Text>().text = "Game Over";
            statsText.GetComponent<Text>().text = createStatsText();
            resumRetryButton.transform.GetChild(0).GetComponent<Text>().text = "Restart";
            
        }

        if (GameManager.Instance.IsGameWon)
        {
            PauseGame();
            resumRetryButton.SetActive(false);
            mainText.GetComponent<Text>().text = "You have won";
            statsText.GetComponent<Text>().text = createStatsText();
            
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
        mainText.GetComponent<Text>().text = "Pause";
        statsText.GetComponent<Text>().text = createStatsText();
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    string createStatsText()
    {
        string text = "";
        int fish = GameManager.Instance.statsFish;
        int harpunes = GameManager.Instance.statsHarpune;
        int rainClouds = GameManager.Instance.statsRainCloud;
        int sunClouds = GameManager.Instance.statsSunnCloud;

         text = string.Format("Your Stats: \n\n" +
                "Shot by Harpunes: {0} \nFish eaten: {1} \nFlown through Sun Clouds: {2} \nFlown through Rain Clouds: {3}. "
                , harpunes, fish, sunClouds, rainClouds);

        return text;
    }

    public void ExitToMenuButtonPressed()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void ResumeRetryButtonPressed()
    {
        if (gameIsPaused)
        {
            Resume();
        }
        else if (GameManager.Instance.IsGameOver)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }

    }

}

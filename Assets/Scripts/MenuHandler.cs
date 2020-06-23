using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    static bool gameIsPaused = false;
    public GameObject menu;

    public Sprite gameOverImage;
    public Sprite pauseImage;
    public Sprite wonImage;

    private GameObject statsText_f;
    private GameObject statsText_h;
    private GameObject statsText_sc;
    private GameObject statsText_rc;

    private GameObject resumRetryButton;
    private GameObject exitToMenuButton;

    private void Start()
    {
        statsText_h = menu.transform.GetChild(0).gameObject;
        statsText_f = menu.transform.GetChild(1).gameObject;
        statsText_sc = menu.transform.GetChild(2).gameObject;
        statsText_rc = menu.transform.GetChild(3).gameObject;

        resumRetryButton = menu.transform.GetChild(4).gameObject;
        exitToMenuButton = menu.transform.GetChild(5).gameObject;
        GameManager.Instance.setupOnStart();
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
            menu.GetComponent<Image>().sprite = gameOverImage;
            //mainText.GetComponent<Text>().text = "Game Over";
            createStatsText();
            resumRetryButton.transform.GetChild(0).GetComponent<Text>().text = "Restart";
            
        }

        if (GameManager.Instance.IsGameWon)
        {
            PauseGame();
            resumRetryButton.SetActive(false);
            menu.GetComponent<Image>().sprite = wonImage;
            //mainText.GetComponent<Text>().text = "You have won";
             createStatsText();
            
        }
    }

    void Resume()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void PauseGame()
    {
        //mainText.GetComponent<Text>().text = "Pause";
        menu.GetComponent<Image>().sprite = pauseImage;
        createStatsText();
        menu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    void createStatsText()
    {
        //string text = "";
        int fish = GameManager.Instance.statsFish;
        int harpunes = GameManager.Instance.statsHarpune;
        int rainClouds = GameManager.Instance.statsRainCloud;
        int sunClouds = GameManager.Instance.statsSunnCloud;

        //text = string.Format("Your Stats: \n\n" +
        //       "Shot by Harpunes: {0} \nFish eaten: {1} \nFlown through Sun Clouds: {2} \nFlown through Rain Clouds: {3}. "
        //       , harpunes, fish, sunClouds, rainClouds);

        statsText_h.GetComponent<Text>().text = harpunes + " Shots";
        statsText_f.GetComponent<Text>().text = fish + " Fishes";
        statsText_sc.GetComponent<Text>().text = sunClouds + " SunnyClouds";
        statsText_rc.GetComponent<Text>().text = rainClouds + " RainyClouds";

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

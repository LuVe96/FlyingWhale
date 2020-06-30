using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    static bool gameIsPaused = false;
    public GameObject menu;
    public GameObject clipMenu;

    public Sprite gameOverImage;
    public Sprite pauseImage;
    public Sprite wonImage;
    public UnityEngine.Video.VideoClip wonClip;
    public UnityEngine.Video.VideoClip gameOverClip;
    private UnityEngine.Video.VideoPlayer videoPlayer;

    private GameObject statsText_f;
    private GameObject statsText_h;
    private GameObject statsText_sc;
    private GameObject statsText_rc;

    private GameObject resumRetryButton;
    private GameObject exitToMenuButton;

    private bool isClipStarted = false;
    private float videoClipTime = 0;

    private void Start()
    {
        videoPlayer = clipMenu.GetComponent<UnityEngine.Video.VideoPlayer>();
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
                PauseGame(true);
            }
        }

        if (isClipStarted)
        {
            videoClipTime += Time.deltaTime;
            if(GameManager.Instance.IsGameOver)
            {
                showGameOverMenu();
            }
            else if (GameManager.Instance.IsGameWon)
            {
                showWonMenu();
            }

            FadeIn(FadeInOpt.VideoClip);
        }  

    }

    void FadeIn(FadeInOpt opt)
    {
        if (videoPlayer.targetCameraAlpha < 1 && opt == FadeInOpt.VideoClip)
        {
            videoPlayer.targetCameraAlpha += 1f * Time.deltaTime;
        }
        else if (opt == FadeInOpt.Menu && menu.GetComponent<Image>().color.a < 1)
        {
            menu.GetComponent<Image>().color += new Color(0, 0, 0, 1f * Time.deltaTime / Time.timeScale);
            statsText_h.GetComponent<Text>().color += new Color(0, 0, 0, 1f * Time.deltaTime / Time.timeScale);
            statsText_f.GetComponent<Text>().color += new Color(0, 0, 0, 1f * Time.deltaTime / Time.timeScale);
            statsText_sc.GetComponent<Text>().color += new Color(0, 0, 0, 1f * Time.deltaTime / Time.timeScale);
            statsText_rc.GetComponent<Text>().color += new Color(0, 0, 0, 1f * Time.deltaTime / Time.timeScale);
            resumRetryButton.GetComponent<Image>().color += new Color(0, 0, 0, 1f * Time.deltaTime / Time.timeScale);
            resumRetryButton.GetComponentInChildren<Text>().color += new Color(0, 0, 0, 1f * Time.deltaTime / Time.timeScale);
            exitToMenuButton.GetComponent<Image>().color += new Color(0, 0, 0, 1f * Time.deltaTime / Time.timeScale);
            exitToMenuButton.GetComponentInChildren<Text>().color += new Color(0, 0, 0, 1f * Time.deltaTime / Time.timeScale);
        }
        else if(opt == FadeInOpt.Reset)
        {
            menu.GetComponent<Image>().color += new Color(0, 0, 0, -menu.GetComponent<Image>().color.a);
            statsText_h.GetComponent<Text>().color += new Color(0, 0, 0, -statsText_h.GetComponent<Text>().color.a);
            statsText_f.GetComponent<Text>().color += new Color(0, 0, 0, -statsText_f.GetComponent<Text>().color.a);
            statsText_sc.GetComponent<Text>().color += new Color(0, 0, 0, -statsText_sc.GetComponent<Text>().color.a);
            statsText_rc.GetComponent<Text>().color += new Color(0, 0, 0, -statsText_rc.GetComponent<Text>().color.a);
            resumRetryButton.GetComponent<Image>().color += new Color(0, 0, 0, -resumRetryButton.GetComponent<Image>().color.a);
            resumRetryButton.GetComponentInChildren<Text>().color += new Color(0, 0, 0, -resumRetryButton.GetComponentInChildren<Text>().color.a);
            exitToMenuButton.GetComponent<Image>().color += new Color(0, 0, 0, -exitToMenuButton.GetComponent<Image>().color.a);
            exitToMenuButton.GetComponentInChildren<Text>().color += new Color(0, 0, 0, -exitToMenuButton.GetComponentInChildren<Text>().color.a);
        }
        else if (opt == FadeInOpt.Instant)
        {
            menu.GetComponent<Image>().color += new Color(0, 0, 0,1);
            statsText_h.GetComponent<Text>().color += new Color(0, 0, 0, 1);
            statsText_f.GetComponent<Text>().color += new Color(0, 0, 0, 1);
            statsText_sc.GetComponent<Text>().color += new Color(0, 0, 0, 1);
            statsText_rc.GetComponent<Text>().color += new Color(0, 0, 0, 1);
            resumRetryButton.GetComponent<Image>().color += new Color(0, 0, 0, 1);
            resumRetryButton.GetComponentInChildren<Text>().color += new Color(0, 0, 0, 1);
            exitToMenuButton.GetComponent<Image>().color += new Color(0, 0, 0, 1);
            exitToMenuButton.GetComponentInChildren<Text>().color += new Color(0, 0, 0, 1);
        }



    }

    public void showGameOverMenu()
    {
       
        if (!isClipStarted)
        {
            clipMenu.SetActive(true);
            videoPlayer.clip = gameOverClip;
            videoPlayer.Play();
            isClipStarted = true;
            
        }
        if ( videoClipTime >= gameOverClip.length)
        {
            FadeIn(FadeInOpt.Menu);          
            PauseGame(false);
            resumRetryButton.SetActive(true);
            menu.GetComponent<Image>().sprite = gameOverImage;
            //mainText.GetComponent<Text>().text = "Game Over";
            createStatsText();
            resumRetryButton.transform.GetChild(0).GetComponent<Text>().text = "Restart";
        }
    }

    public void showWonMenu()
    {
        if (!isClipStarted)
        {
            clipMenu.SetActive(true);
            videoPlayer.clip = wonClip;
            videoPlayer.Play();
            isClipStarted = true;
        }

        if ( videoClipTime >= wonClip.length)
        {
            FadeIn(FadeInOpt.Menu);
            PauseGame(false);
            resumRetryButton.SetActive(false);
            menu.GetComponent<Image>().sprite = wonImage;
            //mainText.GetComponent<Text>().text = "You have won";
            createStatsText();
        }
       
    }

    void Resume()
    {
        menu.SetActive(false);
        clipMenu.SetActive(false);
        FadeIn(FadeInOpt.Reset);
        Time.timeScale = 1f;
        gameIsPaused = false;
        isClipStarted = false;
    }

    void PauseGame(bool showInstant)
    {
        //mainText.GetComponent<Text>().text = "Pause";
        menu.GetComponent<Image>().sprite = pauseImage;
        createStatsText();
        menu.SetActive(true);
        if (showInstant)
        {
            FadeIn(FadeInOpt.Instant);
        }
    
        Time.timeScale = 0.000001f;
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
        GameManager.Instance.exitToMainMenu();
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void ResumeRetryButtonPressed()
    {
        if (gameIsPaused && !GameManager.Instance.IsGameOver)
        {
            Debug.Log("Resume");
            Resume();
        }
        else if (GameManager.Instance.IsGameOver)
        {
            Debug.Log("Retry");
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }

    }

}

enum FadeInOpt
{
    VideoClip,
    Menu,
    Instant,
    Reset
}
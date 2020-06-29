using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject Instructions;
    public GameObject main;

    public UnityEngine.Video.VideoClip clip;
    private float timeSum = 0;

    private void Start()
    {
        main.GetComponent<UnityEngine.Video.VideoPlayer>().clip = clip;
        main.GetComponent<UnityEngine.Video.VideoPlayer>().Play();
        timeSum = 0;
        Time.timeScale = 1;
        FadeIn(FadeInOpt.Reset);
    }

    private void Update()
    {
        timeSum += Time.deltaTime;
        Debug.Log("Fade...: " + timeSum);

        if (timeSum >= clip.length)
        {
           
            FadeIn(FadeInOpt.Menu);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void ToInstructions()
    {
        Instructions.SetActive(true);
        main.SetActive(false);
    }

    public void BackToMain()
    {
        main.SetActive(true);
        Instructions.SetActive(false);
    }

    public void HandleDropdown(int val)
    {
        //switch (val){
        //    case 0:
        //        GameManager.Instance.setLevelDificulty(LevelDifficulty.Easy);
        //        break;
        //    case 1:
        //        GameManager.Instance.setLevelDificulty(LevelDifficulty.Normal);
        //        break;
        //    case 2:
        //        GameManager.Instance.setLevelDificulty(LevelDifficulty.Hard);
        //        break;
        //    default:
        //        GameManager.Instance.setLevelDificulty(LevelDifficulty.Easy);
        //        break;
        //}
    }

    void FadeIn(FadeInOpt opt)
    {
         if (opt == FadeInOpt.Menu )
        {
            main.GetComponent<Image>().color += new Color(0, 0, 0, 0.5f * Time.deltaTime );
            main.GetComponentInChildren<CanvasGroup>().alpha += 0.5f * Time.deltaTime;
        }
        else if (opt == FadeInOpt.Reset)
        {
            main.GetComponent<Image>().color += new Color(0, 0, 0,-main.GetComponent<Image>().color.a);
            main.GetComponentInChildren<CanvasGroup>().alpha =0;
        }
    }
}


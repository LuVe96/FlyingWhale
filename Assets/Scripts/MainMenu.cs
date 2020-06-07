﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
   
    public void ExitGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void HandleDropdown(int val)
    {
        switch (val){
            case 0:
                GameManager.Instance.setLevelDificulty(LevelDifficulty.Easy);
                break;
            case 1:
                GameManager.Instance.setLevelDificulty(LevelDifficulty.Normal);
                break;
            case 2:
                GameManager.Instance.setLevelDificulty(LevelDifficulty.Hard);
                break;
            default:
                GameManager.Instance.setLevelDificulty(LevelDifficulty.Easy);
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    public bool IsGameOver { get; private set; } = false;
    public bool IsGameWon { get; private set; } = false;
    //public PlayerSpeed playerSpeed { get; private set; } = PlayerSpeed.Normal;
    public LevelDifficulty levelDifficulty { get; private set; } = LevelDifficulty.Easy;

    public PlayerHorPos playerHorPos { get; private set; } = PlayerHorPos.Middle;
    public bool createNextTile { get; private set; } = false;
    private float dificultyTimeSum = 0;
    public float timeForEachDificulty = 60;

    //public float speedPeriode = 1.2f;
    //private float defaultSpeedPeriode = 0;
    //public bool playerIsInCloud { get; private set; } = false;
    //public float whaleUpDownVel = 1.5f;
    public GameObject menuhandler;

    public int statsFish { get; private set; } = 0;
    public int statsHarpune { get; private set; } = 0;
    public int statsRainCloud { get; private set; } = 0;
    public int statsSunnCloud { get; private set; } = 0;

    private AudioSource backgroundAudio;
    private WhaleArea whaleInArea  = WhaleArea.Middle;
    private WhaleArea currentWhaleInArea;
    //public AudioClip clipNear;
    public AudioClip clipMiddle;
    //public AudioClip clipAway;

    private float time0Sum = 0;

    private void Awake()
    {
        backgroundAudio = this.GetComponent<AudioSource>(); 
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);  // the Singelton Obj get not deleted when change szene
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void setupOnStart()
    {
        backgroundAudio.Play();
        IsGameOver  = false;
        IsGameWon = false;

        levelDifficulty = LevelDifficulty.Easy;
        playerHorPos = PlayerHorPos.Middle;
        dificultyTimeSum = 0;

        statsFish = 0;
        statsHarpune  = 0;
        statsRainCloud  = 0;
        statsSunnCloud  = 0;
    }

    public void exitToMainMenu()
    {
        backgroundAudio.Stop();
    }

    // Update is called once per frame
    void Update()
    { 
        
        //if(whaleInArea == WhaleArea.Near && currentWhaleInArea != WhaleArea.Near)
        //{
        //    backgroundAudio.Pause();
        //    backgroundAudio.clip = clipNear;
        //    currentWhaleInArea = WhaleArea.Near;
        //    backgroundAudio.Play();
        //    Debug.Log("Near");
        //}
        //else if (whaleInArea == WhaleArea.Away && currentWhaleInArea != WhaleArea.Away)
        //{
        //    backgroundAudio.Pause();
        //    backgroundAudio.clip = clipAway;
        //    currentWhaleInArea = WhaleArea.Away;
        //    backgroundAudio.Play();
        //}
        //else if (whaleInArea == WhaleArea.Middle && currentWhaleInArea != WhaleArea.Middle)
        //{
        //    Debug.Log("Middle");
        //    backgroundAudio.Pause();
        //    backgroundAudio.clip = clipMiddle;
        //    currentWhaleInArea = WhaleArea.Middle;
        //    backgroundAudio.Play();
        //}

        dificultyTimeSum += Time.deltaTime;
        setLevelDificulty(dificultyTimeSum);
    }

    public void setStatsFor(string stat)
    {
        switch (stat)
        {
            case "statsFish": statsFish++; break;
            case "statsHarpune" : statsHarpune++; break;
            case "statsRainCloud" : statsRainCloud++; break;
            case "statsSunnCloud": statsSunnCloud++; break;
            default: return;
        }
    }

    void setLevelDificulty(float timeSum)
    {
        if (timeSum >= (timeForEachDificulty * 2) + timeForEachDificulty/2)
        {
            levelDifficulty = LevelDifficulty.End;
        }
        else if(timeSum >= timeForEachDificulty * 2)
        {
            levelDifficulty = LevelDifficulty.Hard;
        }
        else if(timeSum >= timeForEachDificulty)
        {
            levelDifficulty = LevelDifficulty.Normal;
        }
        else
        {
            levelDifficulty = LevelDifficulty.Easy;
        }
    }

    public void setPlayerHozPos(PlayerHorPos pos)
    {
        playerHorPos = pos;
    }

    public void PlayerIsDead()
    {
        IsGameOver = true;
        menuhandler.GetComponent<MenuHandler>().showGameOverMenu();
        backgroundAudio.Stop();
    }

    public void PlayerHasWon()
    {
        IsGameWon = true;
        menuhandler.GetComponent<MenuHandler>().showWonMenu();
        backgroundAudio.Stop();
    }

    public void setWhaleInArea(WhaleArea area)
    {
        whaleInArea = area;

    }

    public void setCreateNextTile(bool create)
    {
        createNextTile = create;
    }
}



public enum PlayerHorPos
{
    Top,
    Middle,
    Bottom
}

public enum WhaleArea
{
    Near,
    Middle,
    Away
}

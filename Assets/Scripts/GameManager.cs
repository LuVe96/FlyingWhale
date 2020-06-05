using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    public static GameManager Instance = null;

    public bool IsGameOver { get; private set; }
    public PlayerSpeed playerSpeed { get; private set; } = PlayerSpeed.Normal;
    public LevelDifficulty levelDifficulty { get; private set; } = LevelDifficulty.Easy;
    public float speedPeriode = 1.2f;
    private float defaultSpeedPeriode = 0;
    public bool playerIsInCloud = false;


    private float time0Sum = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // the Singelton Obj get not deleted when change szene
        }
        else
        {
            Destroy(this.gameObject);
        }
        defaultSpeedPeriode = speedPeriode;
    }


    // Update is called once per frame
    void Update()
    {
        time0Sum += Time.deltaTime;
        if (time0Sum >= speedPeriode)
        {
            playerSpeed = PlayerSpeed.Normal;
            playerIsInCloud = false;
            time0Sum = 0;
        }
        
    }

    public void PlayerGotSlower(bool isHarpune, PlayerSpeed speed = PlayerSpeed.Slower)
    {
        if (isHarpune)
        {
            speedPeriode = defaultSpeedPeriode;
            //Debug.Log("slower by harpune");
        } else
        {
            speedPeriode = 0.3f;
            //Debug.Log("slower by cloud");
            playerIsInCloud = true;
        }

        playerSpeed = speed;
        time0Sum = 0;
    }

    public void PlayerGotFaster(PlayerSpeed speed = PlayerSpeed.Faster)
    {
        
        speedPeriode = defaultSpeedPeriode;
        playerSpeed = speed;
        time0Sum = 0;
    }

    public void setLevelDificulty(LevelDifficulty ld)
    {
        levelDifficulty = ld;
    }

    public void PlayerIsDead()
    {

    }

}


public enum PlayerSpeed
{
    Slower,
    SunSlower,
    Normal,
    Faster

}


// extension für enum: PlayerSpeed
static class PlayerSpeedMethods
{

    public static float GetSpeed(this PlayerSpeed p1)
    {
        switch (p1)
        {
            case PlayerSpeed.Slower:
                return 0.5f;
            case PlayerSpeed.SunSlower:
                return 0.2f;
            case PlayerSpeed.Normal:
                return 0.0f;
            case PlayerSpeed.Faster:
                return -1f;
            default:
                return 0.0f;

        }
    }
}

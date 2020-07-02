using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public static MovementManager Instance = null;

    public bool playerIsInCloud { get; private set; } = false;
    public float whaleUpDownVel = 1.5f;

    public PlayerSpeed speedClouds { get; private set; } = PlayerSpeed.Normal;
    public PlayerSpeed speedFish { get; private set; } = PlayerSpeed.Normal;
    public PlayerSpeed speedHarpune { get; private set; } = PlayerSpeed.Normal;

    public float speedPeriodeClouds = 0.3f;
    public float speedPeriodeHarpune = 1.2f;
    public float speedPeriodeFish = 1.2f;

    private float timeSumClouds = 0;
    private float timeSumHarpune = 0;
    private float timeSumFish = 0;

    public float realWhaleSpeed {get; private set; } = 0; 
    public float realWhaleUpDownVel { get; private set; } = 0;

    private void Awake()
    {
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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSumClouds += Time.deltaTime;
        timeSumHarpune += Time.deltaTime;
        timeSumFish += Time.deltaTime;


        if (timeSumClouds >= speedPeriodeClouds)
        {
            speedClouds = PlayerSpeed.Normal;
            playerIsInCloud = false;
            //timeSumClouds = 0;
        }

        if (timeSumFish >= speedPeriodeFish)
        {
            speedFish = PlayerSpeed.Normal;
            //timeSumFish = 0;
        }

        if (timeSumHarpune >= speedPeriodeHarpune)
        {
            speedHarpune = PlayerSpeed.Normal;
            //timeSumHarpune = 0;
        }

        realWhaleSpeed = speedClouds.GetSpeed() + speedHarpune.GetSpeed() + speedFish.GetSpeed();
        realWhaleUpDownVel = whaleUpDownVel * speedClouds.GetVerticalSpeedMultiplier() * speedHarpune.GetVerticalSpeedMultiplier() * speedFish.GetVerticalSpeedMultiplier();
     
    }

    public void PlayerGotSlower(bool isHarpune, PlayerSpeed speed = PlayerSpeed.Slower)
    {
        if (isHarpune)
        {
            timeSumHarpune = 0;
            speedHarpune = speed;
            //Debug.Log("slower by harpune");
        }
        else
        {
            timeSumClouds = 0;
            speedClouds = speed;
            //Debug.Log("slower by cloud");
            playerIsInCloud = true;
        }
    }

    public void PlayerGotFaster(PlayerSpeed speed = PlayerSpeed.Faster)
    {
        speedFish = speed;
        timeSumFish = 0;
    }
}

public enum PlayerSpeed
{
    Slower,
    SunSlower,
    HarpuneSlower,
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
                return 0.8f; // 0.5
            case PlayerSpeed.SunSlower:
                return 0.2f;
            case PlayerSpeed.HarpuneSlower:
                return 1.2f;
            case PlayerSpeed.Normal:
                return 0.0f;
            case PlayerSpeed.Faster:
                if (GameManager.Instance.levelDifficulty == LevelDifficulty.Hard)
                {
                    return -1.3f;
                }
                return -1f;
            default:
                return 0.0f;

        }
    }

    public static float GetVerticalSpeedMultiplier(this PlayerSpeed p1)
    {
        switch (p1)
        {
            case PlayerSpeed.Slower:
                return 0.5f; // 0.5
            case PlayerSpeed.SunSlower:
                return 0.8f;
            case PlayerSpeed.HarpuneSlower:
                return 0.4f;
            case PlayerSpeed.Normal:
                return 1f;
            case PlayerSpeed.Faster:
                if (GameManager.Instance.levelDifficulty == LevelDifficulty.Hard)
                {
                    return 1.8f;
                }
                return 1.5f;
            default:
                return 1f;

        }
    }
}

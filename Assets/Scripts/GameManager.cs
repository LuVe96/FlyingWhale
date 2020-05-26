using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    public static GameManager Instance = null;

    public bool IsGameOver { get; private set; }
    public PlayerSpeed playerSpeed { get; private set; } = PlayerSpeed.Normal;
    public float speedPeriode = 1.2f;

    private float time0 = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

    }


    // Update is called once per frame
    void Update()
    {
        time0 += Time.deltaTime;
        if (time0 >= speedPeriode)
        {
            playerSpeed = PlayerSpeed.Normal;
            time0 = 0;
        }
        
    }

    public void PlayerGotSlower( PlayerSpeed speed = PlayerSpeed.Slower)
    {
        playerSpeed = speed;
        time0 = 0;
    }

    public void PlayerGotFaster(PlayerSpeed speed = PlayerSpeed.Faster)
    {
        playerSpeed = speed;
        time0 = 0;
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
                return 0.5f;
            default:
                return 0.0f;

        }
    }
}

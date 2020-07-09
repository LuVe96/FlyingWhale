﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpuneCreater : MonoBehaviour
{
    public GameObject Harpune;
    public Transform shotPointHunter;
    public float spawnTime = 2;

    private float timeSum = 0;
    private float t2Sum = 0;
    private ShotType shotType = ShotType.None;
    private float threeShotTimeSum = 0;
    private int threeShotShots = 0;

    private Transform referenz;
    private float currentRefPos;

    private void Awake()
    {
        referenz = GameObject.Find("MovingObjectReferenz").transform; 
        spawnTime -= 0.5f;
        if (gameObject.tag == "whaleHunterSpecial")
        {
            spawnTime -= 0.5f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        timeSum += Time.deltaTime;
        threeShotTimeSum += Time.deltaTime;

        if ( timeSum >= spawnTime && !MovementManager.Instance.playerIsInCloud && !GameManager.Instance.IsGameOver && !GameManager.Instance.IsGameWon)
        {

            t2Sum += Time.deltaTime;
            if (t2Sum >= 0.5f)
            {
                t2Sum = 0;
                timeSum = 0;

                if( gameObject.tag == "whaleHunter")
                {
                    shotType = ShotType.ThreeSalve;
                }
                else if (gameObject.tag == "whaleHunterSpecial")
                {
                    shotType = ShotType.FourSchrot;
                }
            }

        }

        if (shotType == ShotType.ThreeSalve && threeShotTimeSum >= 0.3)
        {
            ShotValve();
        }  
        else if(shotType == ShotType.FourSchrot)
        {
            if(GameManager.Instance.levelDifficulty == LevelDifficulty.Hard)
            {
                ShotSchrot(4);
            } else
            {
                ShotSchrot(5);
            }

        }
    }

    void ShotSchrot(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject newHarpune = Instantiate(Harpune);
            newHarpune.transform.position = shotPointHunter.transform.position;
            newHarpune.transform.localScale *= 1.3f;
            HarpuneShot hp = newHarpune.GetComponent<HarpuneShot>();
            hp.Shot(0, true);
        }
        shotPointHunter.GetComponent<Animator>().SetTrigger("ExplosionTrigger");
        shotType = ShotType.None;
    }

    void ShotValve()
    {
        threeShotTimeSum = 0;
        threeShotShots++;
        if (threeShotShots == 1)
        {
            currentRefPos = referenz.position.y;
            shotPointHunter.GetComponent<Animator>().SetTrigger("ExplosionTrigger");

        }

        GameObject newHarpune = Instantiate(Harpune);
        newHarpune.transform.position = shotPointHunter.transform.position;
        newHarpune.transform.localScale *= 1.3f;
        HarpuneShot hp = newHarpune.GetComponent<HarpuneShot>();
        hp.Shot(currentRefPos - referenz.position.y);

        if (threeShotShots >= 3)
        {
            shotType = ShotType.None;
            threeShotShots = 0;
        }
    }
}


enum ShotType
{
    ThreeSalve,
    FourSchrot,
    None
}



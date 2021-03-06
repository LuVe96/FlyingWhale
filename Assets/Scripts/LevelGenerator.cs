﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public Transform referenz;
    public GameObject rainClouds;
    public GameObject sunnyClouds;
    public GameObject fish;

    //public int numberOfFish = 20;
    //public int numberOfRainCloud = 20;
    //public int numberOfSunnyCloud = 20;

    private GameObject[] objectPool;

    // Start is called before the first frame update
    void Start()
    {
        //the amount of the objects belongs to the dificulty
        int numberOfFish = GameManager.Instance.levelDifficulty.getNumberofObj()["numberOfFish"];
        int numberOfRainCloud = GameManager.Instance.levelDifficulty.getNumberofObj()["numberOfRainCloud"];
        int numberOfSunnyCloud = GameManager.Instance.levelDifficulty.getNumberofObj()["numberOfSunnyCloud"];

        // create Objects
        int numberOfObjects = numberOfFish + numberOfRainCloud + numberOfSunnyCloud;
        objectPool = new GameObject[numberOfObjects];
        Transform parent = GameObject.Find("MovingObjects").transform;

        for (int i = 0; i < numberOfObjects; i++)
        {
            float randomX = Random.Range(-10.0f, 10.0f);
            float randomY = Random.Range(-10.0f, 10.0f);
            float randomScale = Random.Range(0.5f, 1.5f);

            if (i < numberOfSunnyCloud)
            {
                int num = Random.Range(0, 2);
                GameObject obj = Instantiate(sunnyClouds.transform.GetChild(num).gameObject, parent);
                obj.transform.position = new Vector3(randomX, randomY, 0);
                obj.transform.localScale *= randomScale;
                objectPool[i] = obj;
                //obj.GetComponent<Generatedobject>().setReferenz(referenz);
            }
            else if (i < (numberOfRainCloud + numberOfSunnyCloud))
            {
                int num = Random.Range(0, 2);
                GameObject obj = Instantiate(rainClouds, parent);
                obj.transform.position = new Vector3(randomX, randomY, 0);
                obj.transform.localScale *= randomScale;
                objectPool[i] = obj;
                //obj.GetComponent<Generatedobject>().setReferenz(referenz);
            }
            else if (i < numberOfObjects)
            {
                GameObject obj = Instantiate(fish, parent);
                obj.transform.position = new Vector3(randomX, randomY, 0);
                objectPool[i] = obj;
                //obj.GetComponent<Generatedobject>().setReferenz(referenz);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {

        //foreach (GameObject obj in objectPool)
        //{
        //    if (obj.transform.position.x < -10)
        //    {
        //        float randomX = Random.Range(10.0f, 20.0f);
        //        float randomY = Random.Range(-10.0f, 10.0f);
        //        obj.transform.position = new Vector3(randomX, randomY + referenz.position.y, 0);
        //    }
        //}

    }


}

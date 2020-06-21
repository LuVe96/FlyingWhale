using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpuneCreater : MonoBehaviour
{
    public GameObject Harpune;
    public Transform hunter;
    public float spawnTime = 2;

    private float timeSum = 0;
    private float t2Sum = 0;
    private bool isThreeShot = true;
    private float threeShotTimeSum = 0;
    private int threeShotShots = 0;

    private Transform referenz;
    private float currentRefPos;

    private void Awake()
    {
        referenz = GameObject.Find("MovingObjectReferenz").transform; 
      spawnTime -= 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        timeSum += Time.deltaTime;
        threeShotTimeSum += Time.deltaTime;

        if ( timeSum >= spawnTime && !GameManager.Instance.playerIsInCloud)
        {

            t2Sum += Time.deltaTime;
            if (t2Sum >= 0.5f)
            {
                t2Sum = 0;
                timeSum = 0;
                isThreeShot = true;
            }

        }

        if (isThreeShot && threeShotTimeSum >= 0.3)
        {
            threeShotTimeSum = 0;
            threeShotShots++;
            if(threeShotShots == 1)
            {
                currentRefPos = referenz.position.y;

            }

            GameObject newHarpune = Instantiate(Harpune);
            newHarpune.transform.position = hunter.transform.position;
            newHarpune.transform.localScale *= 1.3f;
            HarpuneShot hp = newHarpune.GetComponent<HarpuneShot>();          
            hp.Shot(currentRefPos - referenz.position.y);

            if(threeShotShots >= 3)
            {
                isThreeShot = false;
                threeShotShots = 0;
            }

        }

      
    }

   
}

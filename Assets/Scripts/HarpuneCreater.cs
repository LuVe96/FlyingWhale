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
   



    // Start is called before the first frame update
    void Start()
    {
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

            GameObject newHarpune = Instantiate(Harpune);
            newHarpune.transform.position = hunter.transform.position;
            //newHarpune.transform.localScale *= 0.15f;
            HarpuneShot hp = newHarpune.GetComponent<HarpuneShot>();
            hp.Shot();

            if(threeShotShots >= 3)
            {
                isThreeShot = false;
                threeShotShots = 0;
            }

        }

      
    }

   
}

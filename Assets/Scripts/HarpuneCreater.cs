using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpuneCreater : MonoBehaviour
{
    public GameObject Harpune;
    public Transform hunter;
    public float spawnTime = 2;

    private float timeSum = 0;
    private bool isThreeShot = true;
    private float threeShotTimeSum = 0;
    private int threeShotShots = 0;
   



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSum += Time.deltaTime;
        threeShotTimeSum += Time.deltaTime;

        if ( timeSum >= spawnTime)
        {
            timeSum = 0;
            isThreeShot = true;

        }

        if (isThreeShot && threeShotTimeSum >= 0.4)
        {
            threeShotTimeSum = 0;
            threeShotShots++;

            GameObject newHarpune = Instantiate(Harpune);
            newHarpune.transform.position = hunter.transform.position;
            newHarpune.transform.localScale *= 0.3f;
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

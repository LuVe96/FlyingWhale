using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpuneCreater : MonoBehaviour
{
    public GameObject Harpune;
    public int NumberOfHarpunes = 15;
    public Transform hunter;
    public float spawnTime = 2;

    private float seconds = 0;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;

        if ( seconds >= spawnTime)
        {
            seconds = 0;

            GameObject newHarpune = Instantiate(Harpune);
            newHarpune.transform.position = hunter.transform.position;
            newHarpune.transform.localScale *= 0.5f ;


            
        }
        
    }
}

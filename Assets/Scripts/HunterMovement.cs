using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterMovement : MonoBehaviour
{

    public Transform whale;

    // Update is called once per frame
    void Update()
    {
        float differenz_y = whale.transform.position.y - transform.position.y;
        transform.position += new Vector3(0, differenz_y * Random.Range(0.001f, 0.008f), 0);

    }
}

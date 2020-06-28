using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterMovement : MonoBehaviour
{

    private Transform whale;
    private float collisionTime = 0;
    private float timeSum = 0;
    private float yOffset = 1;
    public float differenz_y { get; private set; } = 0;

    private void Start()
    {
        whale = GameObject.Find("wal").transform;
    }

    // Update is called once per frame
    void Update()
    {
        timeSum += Time.deltaTime;
        differenz_y = whale.transform.position.y - transform.position.y;

        if( timeSum < collisionTime)
        {
            differenz_y = differenz_y / Mathf.Abs(differenz_y) * -0.3f;
        }

        transform.position += new Vector3(0, (differenz_y + yOffset) * Random.Range(0.08f, 0.5f) * Time.deltaTime, 0);

    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "whaleHunter" || collision.gameObject.tag == "whaleHunterSpecial")
        {
            if(Mathf.Abs(collision.GetComponent<HunterMovement>().differenz_y + yOffset) < Mathf.Abs(differenz_y + yOffset))
            {
                timeSum = 0;
                collisionTime = 1;
            }

        }
    }
}

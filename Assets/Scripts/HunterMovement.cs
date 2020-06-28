using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterMovement : MonoBehaviour
{

    private Transform whale;
    private float collisionTime = 0;
    private float collisionStayTime = 0;
    private float timeSum = 0;
    private float yOffset = 1;
    public float differenz_y { get; private set; } = 0;
    public HunterPos hunterPosition { get; private set; } = HunterPos.normal;
    private GameObject otherhunter;

    private void Start()
    {
        whale = GameObject.Find("wal").transform;
    }

    // Update is called once per frame
    void Update()
    {
        timeSum += Time.deltaTime;
        differenz_y = whale.transform.position.y - transform.position.y;
        transform.position += new Vector3(0, (differenz_y + hunterPosition.getOffset_y()) * Random.Range(0.08f, 0.5f) * Time.deltaTime, 0);


        //if (otherhunter == null)
        //{
        //    transform.position += new Vector3(0, (differenz_y + yOffset) * Random.Range(0.08f, 0.5f) * Time.deltaTime, 0);
        //}
        //else
        //{

        //    if (timeSum < collisionTime)
        //    {
        //        differenz_y = differenz_y / Mathf.Abs(differenz_y) * -1.3f;
        //    }
        //    else
        //    {
        //        differenz_y = differenz_y / Mathf.Abs(differenz_y) * 0.8f;
        //    }
        //    transform.position += new Vector3(0, (differenz_y + yOffset) * Random.Range(0.08f, 0.5f) * Time.deltaTime, 0);

        //    //if ( Mathf.Abs(otherhunter.transform.position.y - transform.position.y) > 3)
        //    //{

        //    //}
        //    //else
        //    //{
        //    //    differenz_y = (otherhunter.transform.position.y - transform.position.y) / Mathf.Abs(otherhunter.transform.position.y - transform.position.y) * -0.5f;
        //    //    transform.position += new Vector3(0, (differenz_y ) * Random.Range(0.08f, 0.5f) * Time.deltaTime, 0);
        //    //}
        //}

    }

    public void setHunterPos(HunterPos pos)
    {
        hunterPosition = pos;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "whaleHunter" || collision.gameObject.tag == "whaleHunterSpecial")
        //{
        //    if(Mathf.Abs(collision.GetComponent<HunterMovement>().differenz_y + yOffset) < Mathf.Abs(differenz_y + yOffset))
        //    {
        //        timeSum = 0;
        //        collisionTime = 1;
        //    }

        //    otherhunter = collision.gameObject;
        //}
    }
}

public enum HunterPos
{
    Top,
    normal,
    Bottom
}

static class HunterPosMethods
{
    // here define how many obj the levelgenerat uses on each dificulty
    public  static float getOffset_y(this HunterPos h1)
    {
        switch (h1)
        {
            case HunterPos.Top:
                return 2f;
            case HunterPos.normal:
                return 1f;
            case HunterPos.Bottom:
                return -2f;   
            default:
                return 0;
        }
    
    }
}
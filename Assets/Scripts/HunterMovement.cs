using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterMovement : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //PlayerSpeed pss = PlayerSpeed.Slower;
        //if (GameManager.Instance.playerSpeed  == pss )
        //{
        //    transform.position += new Vector3(pss.GetSpeed() * Time.deltaTime, 0, 0);
        //}

        //PlayerSpeed psSun = PlayerSpeed.SunSlower;
        //if (GameManager.Instance.playerSpeed == psSun)
        //{
        //    transform.position += new Vector3(psSun.GetSpeed() * Time.deltaTime, 0, 0);
        //}

        transform.position += new Vector3(GameManager.Instance.playerSpeed.GetSpeed() * Time.deltaTime, 0, 0);

    }
}

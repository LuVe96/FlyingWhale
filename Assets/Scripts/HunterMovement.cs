using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterMovement : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        PlayerSpeed ps = PlayerSpeed.Slower;
        if (GameManager.Instance.playerSpeed  == ps )
        {
            transform.position += new Vector3(ps.GetSpeed() * Time.deltaTime, 0, 0);
        }
        
    }
}

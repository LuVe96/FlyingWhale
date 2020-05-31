using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScrolling_2 : MonoBehaviour
{
    public float speed = -1.5f;
    public float waleVelocity = 1f;
    //public Transform hunters;

    private Rigidbody2D rBody;

    private bool isUpPressed = false;
    private bool isDownPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        rBody = this.GetComponent<Rigidbody2D>();
        rBody.velocity = new Vector2(speed, 0f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }


}

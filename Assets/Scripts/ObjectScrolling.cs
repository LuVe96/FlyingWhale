using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScrolling : MonoBehaviour
{
    public float speed = -1.5f;
    private Rigidbody2D rBody;

    // Start is called before the first frame update
    void Start()
    {
        rBody = this.GetComponent<Rigidbody2D>();
        rBody.velocity = new Vector2(speed, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);

    }
}

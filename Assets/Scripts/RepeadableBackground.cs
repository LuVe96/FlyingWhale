using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeadableBackground : MonoBehaviour
{
    private float horizontalOffset = 19.2f;
    public BoxCollider2D borderCollider;


    // Start is called before the first frame update
    void Start()
    {
        horizontalOffset = borderCollider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x < -horizontalOffset)
        {
            this.transform.position += Vector3.right * horizontalOffset * 2f;
        }
    }
}

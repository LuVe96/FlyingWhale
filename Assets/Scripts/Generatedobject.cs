using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generatedobject : MonoBehaviour
{

    private Transform referenz;

    public void setReferenz(Transform _referenz)
    {
        //referenz = _referenz;
    }

    private void Start()
    {
       referenz= GameObject.Find("MovingObjectReferenz").transform;    
    }

    // Update is called once per frame
    void Update()
    {
        //if (transform.position.x < -10)
        //{
        //    float randomX = Random.Range(10.0f, 20.0f);
        //    float randomY = Random.Range(-10.0f, 10.0f);
        //    transform.position = new Vector3(randomX, randomY + referenz.position.y, 0);
        //    transform.GetChild(0).GetComponent<PolygonCollider2D>().enabled = true;
        //}
    }
}

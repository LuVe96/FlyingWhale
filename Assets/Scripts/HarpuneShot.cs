using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpuneShot : MonoBehaviour
{

    public Transform wale;
    public float velocity;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        wale = GameObject.Find("wal").transform;
        direction = wale.position - transform.position;
        float x_leng = Mathf.Abs(wale.position.x - transform.position.x);
        float y_leng = Mathf.Abs(wale.position.y - transform.position.y);


        transform.LookAt(wale);
        transform.Rotate(new Vector3(0, 90, 0));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * velocity ;
    }
}

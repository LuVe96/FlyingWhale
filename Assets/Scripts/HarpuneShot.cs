using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpuneShot : MonoBehaviour
{

    private Transform wale;
    public float velocity;
    public float timeDeletion = 2;
    private Vector3 direction;
   

    private bool isShooting = false;
    private float timeSum = 0;

  

    private void Awake()
    {
        wale = GameObject.Find("wal").transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (isShooting)
        {
            transform.position += direction * velocity * Time.deltaTime;
            timeSum += Time.deltaTime;

            if (timeSum >= timeDeletion)
            {
                ResetShot();
            }
        }
        
    }

    public void Shot()
    {

        //random position near wale
        float randomNumber = Random.Range(-0.8f, 0.8f);
        //Transform modWale = wale;
        //modWale.position += new Vector3(0.2f, randomNumber, 0);
        Vector3 pos = wale.position + new Vector3(1f, randomNumber, 0);

        //shoting direction by position
        direction = pos - transform.position;
        float x_leng = Mathf.Abs(wale.position.x - transform.position.x);
        float y_leng = Mathf.Abs(wale.position.y - transform.position.y);
        //direction += new Vector3(0, GameManager.Instance.playerOffsetY, 0);

        transform.LookAt(pos);
        transform.Rotate(new Vector3(0, -90, 0));
        isShooting = true;
    }

    private void ResetShot()
    {
        timeSum = 0;
        isShooting = false;
        Destroy(gameObject);
    }
}

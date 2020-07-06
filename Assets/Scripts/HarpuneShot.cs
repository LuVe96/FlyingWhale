using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpuneShot : MonoBehaviour
{

    private Transform wale;
    public float velocity;
    public float timeDeletion = 6;
    private Vector3 direction;

    private bool isShooting = false;
    private float timeSum = 0;

    private AudioSource shot;
    private bool whaleHitten = false;

    private void Awake()
    {
        wale = GameObject.Find("wal").transform;
        shot = this.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        timeSum += Time.deltaTime;
        if (whaleHitten)
        {      
            if (timeSum >= timeDeletion)
            {
                ResetShot();
            }
            return;
        }

        if (isShooting)
        {
            
            transform.position += direction * velocity * Time.deltaTime;
            if (timeSum >= timeDeletion)
            {
                ResetShot();
            }
        }

        if(GameManager.Instance.playerHorPos == PlayerHorPos.Top || GameManager.Instance.playerHorPos == PlayerHorPos.Bottom){
            gameObject.GetComponent<ObjectScrolling_2>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<ObjectScrolling_2>().enabled = true;
        }
        
    }

    public void Shot(float adjustRefY, bool spreading = false)
    {
        shot.Play();
        //random position near wale
        float randomNumber = Random.Range(-0.8f, 0.8f);
        if (spreading)
        {
            randomNumber = Random.Range(-3f, 3f);
        }
        //Transform modWale = wale;
        //modWale.position += new Vector3(0.2f, randomNumber, 0);
        Vector3 pos = wale.position + new Vector3(1f, adjustRefY + randomNumber, 0);

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

    public void WhaleHitten()
    {
        whaleHitten = true;
    }
}

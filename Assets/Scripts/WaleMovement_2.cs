﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaleMovement_2 : MonoBehaviour
{

    public float turnVelocty = 35;
    private float waleHoizontalVelocity;
    public GameObject redZone;
    ////public Transform hunter;

    private bool isUpPressed = false;
    private bool isDownPressed = false;
    private bool isNoKeyPressed = true;
    private Animator animator;
    private AudioSource whaleshot;
    private AudioSource rainCloud;
    private AudioSource sunnyCloud;
    private AudioSource fish;



    // Start is called before the first frame update
    void Start()
    {
     
        animator = GetComponent<Animator>();
       
        AudioSource[] audios = GetComponents<AudioSource>();
        whaleshot = audios[0];
        rainCloud = audios[1];
        sunnyCloud = audios[2];
        fish = audios[3];
    }

    // Update is called once per frame
    void Update()
    {
        waleHoizontalVelocity = MovementManager.Instance.realWhaleUpDownVel / 1f;

        // horizontal Movement
        if (Input.GetKeyDown(KeyCode.W) || isUpPressed)
        {
           
            if (transform.rotation.z <= 0.25)
            {
                transform.Rotate(new Vector3(0, 0, turnVelocty * Time.deltaTime));               
            }

            if (GameManager.Instance.playerHorPos == PlayerHorPos.Top)
            {
                if(transform.localPosition.y <= 7.8)
                {
                    transform.position += new Vector3(0, waleHoizontalVelocity * Time.deltaTime, 0);
                }   
            }
            if (GameManager.Instance.playerHorPos == PlayerHorPos.Bottom)
            {
                transform.position += new Vector3(0, waleHoizontalVelocity * Time.deltaTime, 0);
                if (transform.localPosition.y >= 0)
                {
                    GameManager.Instance.setPlayerHozPos(PlayerHorPos.Middle);
 
                }
            }


            isUpPressed = true;
            isNoKeyPressed = false;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            isUpPressed = false;
            isNoKeyPressed = true;
        }

        if (Input.GetKeyDown(KeyCode.S) || isDownPressed)
        {
            if (transform.rotation.z >= -0.25)
            {
                transform.Rotate(new Vector3(0, 0, -turnVelocty * Time.deltaTime));
            }

            if (GameManager.Instance.playerHorPos == PlayerHorPos.Bottom)
            {
                if (transform.localPosition.y >= -7.8)
                {
                    transform.position += new Vector3(0, -waleHoizontalVelocity  * Time.deltaTime, 0);
                } 
            }
            if (GameManager.Instance.playerHorPos == PlayerHorPos.Top)
            {
                transform.position += new Vector3(0, -waleHoizontalVelocity * Time.deltaTime, 0);
                if (transform.localPosition.y <= 0)
                {
                    GameManager.Instance.setPlayerHozPos(PlayerHorPos.Middle);
                }
            }

            isDownPressed = true;
            isNoKeyPressed = false;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            isDownPressed = false;
            isNoKeyPressed = true;
        }


        if (isNoKeyPressed)
        {
            if (transform.rotation.z > 0)
            {
                transform.Rotate(new Vector3(0, 0, -turnVelocty * Time.deltaTime));
            }

            if (transform.rotation.z < 0)
            {
                transform.Rotate(new Vector3(0, 0, turnVelocty * Time.deltaTime));
            }

        }
         
        // vertical movement with limit in the end
        if (transform.localPosition.x <= 14 || !(MovementManager.Instance.realWhaleSpeed < 0))
        {   
            transform.position += new Vector3(-MovementManager.Instance.realWhaleSpeed * Time.deltaTime, 0, 0);
        }
        

        //Animations
        if(MovementManager.Instance.speedFish == PlayerSpeed.Faster)
        {
            animator.speed = 2f;
        }
        else
        {
            animator.speed = 1f;
        }

        if(transform.localPosition.x < -5)
        {
            GameManager.Instance.setWhaleInArea(WhaleArea.Near);
        }
        else if (transform.localPosition.x > 7)
        {
            GameManager.Instance.setWhaleInArea(WhaleArea.Away);
        }
        else
        {
            GameManager.Instance.setWhaleInArea(WhaleArea.Middle);
        }

        //RedZone

        float dif = Mathf.Abs(transform.position.x - redZone.transform.position.x);
        if(dif < 4 && dif > 0)
        {
            redZone.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, (4 - dif) / 4) ;
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "harpune" || collision.gameObject.tag == "harpune(Clone)")
        {
            //hunter.transform.position += new Vector3(1.5f, 0, 0);
            GameManager.Instance.setStatsFor("statsHarpune");
            MovementManager.Instance.PlayerGotSlower(true, PlayerSpeed.HarpuneSlower);
            whaleshot.Play();
            GameObject.Find("HurtScreen").GetComponent<HurtScreenHandler>().showHurtScreen();

            // when harpune hits, it stucks in whale
            collision.transform.parent = gameObject.transform;
            collision.GetComponent<ObjectScrolling_2>().enabled = false;
            collision.GetComponent<HarpuneShot>().WhaleHitten();
            collision.GetComponent<BoxCollider2D>().enabled = false;
            Vector3 dif = collision.transform.position - transform.position;
            collision.transform.position -= dif * 0.4f;

            //Destroy(collision.gameObject);

        }

        if (collision.gameObject.tag == "netz" || collision.gameObject.tag == "harpune(Clone)")
        {
            GameManager.Instance.PlayerIsDead();
        }

        if (collision.gameObject.tag == "fish")
        {
            GameManager.Instance.setStatsFor("statsFish");
            MovementManager.Instance.PlayerGotFaster();
            Destroy(collision.gameObject);
            fish.Play();
        }

        if (collision.gameObject.tag == "goal")
        {
            GameManager.Instance.PlayerHasWon();
        }

        if( collision.tag == "rainCloudOneTimeCollider")
        {
            collision.GetComponent<PolygonCollider2D>().enabled = false;
            GameManager.Instance.setStatsFor("statsRainCloud");
            rainCloud.Play();
        }

        if (collision.tag == "sunnyCloudOneTimeCollider")
        {
            collision.GetComponent<PolygonCollider2D>().enabled = false;
            GameManager.Instance.setStatsFor("statsSunnCloud");
            sunnyCloud.Play();
        }

       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "rainCloud")
        {
            MovementManager.Instance.PlayerGotSlower(false);
        }

        if (collision.gameObject.tag == "sunnyCloud")
        {
            MovementManager.Instance.PlayerGotSlower(false, PlayerSpeed.SunSlower);
        }
    }
}

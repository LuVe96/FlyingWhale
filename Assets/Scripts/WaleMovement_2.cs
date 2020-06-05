using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaleMovement_2 : MonoBehaviour
{

    public float turnVelocty = 35;
    public float waleVelocity = 1f;
    ////public Transform hunter;

    private bool isUpPressed = false;
    private bool isDownPressed = false;
    private bool isNoKeyPressed = true;
    private Animator animator;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // horizontal Movement
        if (Input.GetKeyDown(KeyCode.W) || isUpPressed)
        {
            if (transform.rotation.z <= 0.25)
            {
                transform.Rotate(new Vector3(0, 0, turnVelocty * Time.deltaTime));               
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

        // vertical movement
        transform.position += new Vector3(-GameManager.Instance.playerSpeed.GetSpeed() * Time.deltaTime, 0, 0);

        //Animations
        if(GameManager.Instance.playerSpeed == PlayerSpeed.Faster)
        {
            animator.speed = 2f;
        }
        else
        {
            animator.speed = 1f;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "harpune" || collision.gameObject.tag == "harpune(Clone)")
        {
            //hunter.transform.position += new Vector3(1.5f, 0, 0);

            GameManager.Instance.PlayerGotSlower(true);

        }

        if (collision.gameObject.tag == "netz" || collision.gameObject.tag == "harpune(Clone)")
        {
            Debug.Log("Game over");
            GameManager.Instance.PlayerIsDead();
        }

        if (collision.gameObject.tag == "fish")
        {
            GameManager.Instance.PlayerGotFaster();
            Destroy(collision.gameObject);
        }


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "rainCloud")
        {
            GameManager.Instance.PlayerGotSlower(false);
        }

        if (collision.gameObject.tag == "sunnyCloud")
        {
            GameManager.Instance.PlayerGotSlower(false, PlayerSpeed.SunSlower);
        }
    }
}

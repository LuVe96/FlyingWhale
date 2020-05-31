using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaleMovement : MonoBehaviour
{

    public float turnVelocty = 35;
    ////public Transform hunter;

    private bool isUpPressed = false;
    private bool isDownPressed = false;
    private bool isNoKeyPressed = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W) || isUpPressed)
        {
            if (transform.rotation.z <= 0.25)
            {
                transform.Rotate(new Vector3(0, 0, turnVelocty * Time.deltaTime));
                Debug.Log("Rot up");
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
                Debug.Log("Rot down");
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

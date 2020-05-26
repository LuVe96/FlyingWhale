using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaleMovement : MonoBehaviour
{

    public float velocty = 0.1f;
    //public Transform hunter;

    private bool isUpPressed = false;
    private bool isDownPressed = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W) || isUpPressed) 
        {
            transform.position += new Vector3(0, velocty * Time.deltaTime, 0); 
            Debug.Log("up");

            isUpPressed = true;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            isUpPressed = false;
        }



        if (Input.GetKeyDown(KeyCode.S) || isDownPressed)
        {
            transform.position += new Vector3(0, -velocty * Time.deltaTime, 0);
            isDownPressed = true;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            isDownPressed = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "harpune" || collision.gameObject.tag == "harpune(Clone)")
        {
            //hunter.transform.position += new Vector3(1.5f, 0, 0);

            GameManager.Instance.PlayerGotSlower();

        }

        if (collision.gameObject.tag == "netz" || collision.gameObject.tag == "harpune(Clone)")
        {
            Debug.Log("Game over");
            GameManager.Instance.PlayerIsDead();
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "rainCloud")
        {
            GameManager.Instance.PlayerGotSlower();
        }

        if (collision.gameObject.tag == "sunnyCloud")
        {
            GameManager.Instance.PlayerGotSlower(PlayerSpeed.SunSlower);
        }
    }


}

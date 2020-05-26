using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalMovement : MonoBehaviour
{

    public float velocty = 0.1f;
    public Transform hunter;

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collision");
        if (other.gameObject.tag == "harpune" || other.gameObject.tag == "harpune(Clone)")
        {
            //Debug.Log("collision with harpune");

            hunter.transform.position += new Vector3(1.5f, 0, 0);
        }

        if (other.gameObject.tag == "netz" || other.gameObject.tag == "harpune(Clone)")
        {
            Debug.Log("Game over");
        }

    }
}

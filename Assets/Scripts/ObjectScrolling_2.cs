using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScrolling_2 : MonoBehaviour
{
    public float speed = -1.5f;
    public float waleVelocity = 1f;
    //public Transform hunters;

    private Rigidbody2D rBody;

    private bool isUpPressed = false;
    private bool isDownPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        rBody = this.GetComponent<Rigidbody2D>();
        rBody.velocity = new Vector2(speed, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.W) || isUpPressed )
        {
            isUpPressed = true;

            if ( gameObject.name == "Background")
            {
                if (GetComponent<Transform>().position.y >= -5)
                {
                    if (GameManager.Instance.playerHorPos == PlayerHorPos.Middle)
                    {
                        transform.position += new Vector3(0, -waleVelocity * Time.deltaTime, 0);
                        //hunters.position -= new Vector3(0, -waleVelocity * Time.deltaTime, 0);
                    }
                }
                else
                {
                    GameManager.Instance.setPlayerHozPos(PlayerHorPos.Top);
                }
            }
            else
            {
                if (GameManager.Instance.playerHorPos == PlayerHorPos.Middle)
                {
                    transform.position += new Vector3(0, -waleVelocity * Time.deltaTime, 0);
                    //hunters.position -= new Vector3(0, -waleVelocity * Time.deltaTime, 0);
                }
            }

           
           
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            isUpPressed = false;
        }


        if (Input.GetKeyDown(KeyCode.S) || isDownPressed)
        {
            isDownPressed = true;

            if (gameObject.name == "Background")
            {
                if (GetComponent<Transform>().position.y <= 5)
                {
                    if (GameManager.Instance.playerHorPos == PlayerHorPos.Middle)
                    {
                        transform.position += new Vector3(0, waleVelocity * Time.deltaTime, 0);
                        //hunters.position -= new Vector3(0, waleVelocity * Time.deltaTime, 0);          
                    }

                }
                else
                {
                    GameManager.Instance.setPlayerHozPos(PlayerHorPos.Bottom);
                }
            }
            else
            {
                if (GameManager.Instance.playerHorPos == PlayerHorPos.Middle)
                {
                    transform.position += new Vector3(0, waleVelocity * Time.deltaTime, 0);
                    //hunters.position -= new Vector3(0, waleVelocity * Time.deltaTime, 0);          
                }
            }

            
                
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            isDownPressed = false;
        }

        //this.transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);

        //PlayerSpeed ps = PlayerSpeed.Slower;
        //if (GameManager.Instance.playerSpeed  == ps )
        //{
        //    transform.position += new Vector3(ps.GetSpeed() * Time.deltaTime, 0, 0);
        //}

        //PlayerSpeed psSun = PlayerSpeed.SunSlower;
        //if (GameManager.Instance.playerSpeed == psSun)
        //{
        //    transform.position += new Vector3(psSun.GetSpeed() * Time.deltaTime, 0, 0);
        //}

        //PlayerSpeed psFast = PlayerSpeed.Faster;
        //if (GameManager.Instance.playerSpeed == psFast)
        //{
        //    transform.position += new Vector3(psFast.GetSpeed() * Time.deltaTime, 0, 0);
        //}

       
    }


}

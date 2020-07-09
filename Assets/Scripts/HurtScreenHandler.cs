using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HurtScreenHandler : MonoBehaviour
{

    private bool started = false;
    private bool fadedIn = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            fadedIn = FadeIn();
        }
        if (fadedIn)
        {
            FadeOut();
        }
    }

    public void showHurtScreen()
    {
        fadedIn = false;
        started = true;
    }

    bool FadeIn()
    {       
         if (gameObject.GetComponent<Image>().color.a < 0.5f)
        {
            gameObject.GetComponent<Image>().color += new Color(0, 0, 0, 1.5f * Time.deltaTime);
            return false;
        }
        started = false;
        return true;
    }

    void FadeOut()
    {
        if (gameObject.GetComponent<Image>().color.a > 0f)
        {
            gameObject.GetComponent<Image>().color += new Color(0, 0, 0, -0.3f * Time.deltaTime);
            return;
        }
        fadedIn = false;
    }
}

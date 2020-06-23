using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPartBgRepeater : MonoBehaviour
{

    public GameObject secondBg;
    public bool isSet { get; private set; } = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( transform.position.x <= 0 && !secondBg.GetComponent<TwoPartBgRepeater>().isSet)
        {
            secondBg.transform.position = new Vector3 (53, 0, 0);
            secondBg.GetComponent<TwoPartBgRepeater>().setIsSet(true);
            setIsSet(false);

        }
    }

 
    public void setIsSet(bool _isSet)
    {

        isSet = _isSet;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratedTile : MonoBehaviour
{

    private bool createNextCalled = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= 0 && !createNextCalled)
        {
            GameManager.Instance.setCreateNextTile(true);
            createNextCalled = true;
        }
        if (transform.position.x <= -30)
        {
            Destroy(gameObject);
        }
    }
}

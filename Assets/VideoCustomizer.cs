using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoCustomizer : MonoBehaviour
{

    private float playTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        playTime = GameManager.Instance.timeForEachDificulty * 3.5f;
        GetComponent<UnityEngine.Video.VideoPlayer>().playbackSpeed = 1 / playTime * 15;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

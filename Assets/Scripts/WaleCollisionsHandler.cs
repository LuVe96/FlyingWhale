using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaleCollisionsHandler : MonoBehaviour
{

    [SerializeField]
    private PolygonCollider2D[] colliders;
    private int currentColliderIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetColliderForSprite(int spriteNum)
    {
        colliders[currentColliderIndex].enabled = false;
        currentColliderIndex = spriteNum;
        colliders[currentColliderIndex].enabled = true;
    }
}

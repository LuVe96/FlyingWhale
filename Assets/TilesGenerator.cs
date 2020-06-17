using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesGenerator : MonoBehaviour
{

    public Transform referenz;
    public GameObject easyTiles;

    private int numEasyTiles = 0;

    // Start is called before the first frame update
    void Start()
    {
        numEasyTiles = easyTiles.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {

        int num = Random.Range(0, numEasyTiles - 1);
        float randomY = Random.Range(-5, 5);
        GameObject obj = Instantiate(easyTiles.transform.GetChild(num).gameObject);
        obj.transform.position = new Vector3(30, randomY, 0);

    }
}

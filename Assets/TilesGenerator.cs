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
        createTile(numEasyTiles, easyTiles);
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.Instance.createNextTile)
        {
            createTile(numEasyTiles, easyTiles);
            GameManager.Instance.setCreateNextTile(false);
        }

    }

    void createTile(int numTiles, GameObject TilesSet)
    {
        int num = Random.Range(0, numTiles - 1);
        float randomY = Random.Range(-5, 5);
        GameObject obj = Instantiate(TilesSet.transform.GetChild(num).gameObject);
        obj.transform.position = new Vector3(30, randomY + referenz.position.y, 0);
    }
}

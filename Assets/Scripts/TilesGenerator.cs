using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesGenerator : MonoBehaviour
{

    public Transform referenz;
    public GameObject easyTiles;
    public GameObject normalTiles;
    public GameObject hardTiles;
    public GameObject endTiles;

    private int numEasyTiles = 0;
    private int numNormalTiles = 0;
    private int numHardTiles = 0;
    private int numEndTiles = 0;

    // Start is called before the first frame update
    void Start()
    {
        numEasyTiles = easyTiles.transform.childCount;
        numNormalTiles = normalTiles.transform.childCount;
        numHardTiles = hardTiles.transform.childCount;
        numEndTiles = endTiles.transform.childCount;
        createTile(numEasyTiles, easyTiles);
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.Instance.createNextTile)
        {
            GameManager.Instance.setCreateNextTile(false);
            if ( GameManager.Instance.levelDifficulty == LevelDifficulty.Easy)
            {
                createTile(numEasyTiles, easyTiles); 
            }
            else if (GameManager.Instance.levelDifficulty == LevelDifficulty.Normal)
            {
                createTile(numNormalTiles, normalTiles);
            }
            else if (GameManager.Instance.levelDifficulty == LevelDifficulty.Hard)
            {
                createTile(numHardTiles, hardTiles);
            }
            else if (GameManager.Instance.levelDifficulty == LevelDifficulty.End)
            {
                createTile(numEndTiles, endTiles);
            }

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

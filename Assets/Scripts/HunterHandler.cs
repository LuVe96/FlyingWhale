using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterHandler : MonoBehaviour
{

    public GameObject normalHunter;
    public GameObject specialHunter;

    public float velocity = 0.5f;
    private HunterSpawnPhase phase = HunterSpawnPhase.End;
    private LevelDifficulty currentDifficulty;

    // Start is called before the first frame update
    void Start()
    {
        phase = HunterSpawnPhase.End;
    }

    // Update is called once per frame
    void Update()
    {

        if(GameManager.Instance.levelDifficulty != currentDifficulty && GameManager.Instance.levelDifficulty != LevelDifficulty.End)
        {
            phase = HunterSpawnPhase.End;
            currentDifficulty = (GameManager.Instance.levelDifficulty);
            Debug.Log(currentDifficulty);
        }
        else if (GameManager.Instance.goalEntered)
        {
            phase = HunterSpawnPhase.End;
            currentDifficulty = (GameManager.Instance.levelDifficulty);
            Debug.Log(currentDifficulty);
        }


        switch (phase)
        {
            case HunterSpawnPhase.End:
                if (OnPhaseEnd())
                {              
                   phase = HunterSpawnPhase.Spawn;                
                }
                break;
            case HunterSpawnPhase.Spawn:
                OnPhaseSpawn();
                if (GameManager.Instance.levelDifficulty != LevelDifficulty.End)
                {
                    phase = HunterSpawnPhase.Start;
                }
                break;
            case HunterSpawnPhase.Start:
                if (OnPhaseStart())
                {
                    phase = HunterSpawnPhase.None;
                }
                break;          
        }
    }

    void OnPhaseSpawn()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.tag == "whaleHunter" || transform.GetChild(i).gameObject.tag == "whaleHunterSpecial")
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }

        switch (GameManager.Instance.levelDifficulty)
        {
            case LevelDifficulty.Easy: spawnhunters(new GameObject[1] { normalHunter }); break;
            case LevelDifficulty.Normal: spawnhunters(new GameObject[1] { specialHunter }); break;
            case LevelDifficulty.Hard: spawnhunters(new GameObject[2] { normalHunter, specialHunter }); break;
            default: break;

        }

    }

    void spawnhunters( GameObject [] hunters)
    {


        for (int i = 0; i < hunters.Length; i++)
        {
            GameObject newHunter = Instantiate(hunters[i], transform);

            if( hunters.Length == 2)
            {
                if( i == 0)
                {
                    newHunter.transform.position = new Vector3(transform.position.x, Random.Range(2, 10), 0);
                    newHunter.GetComponent<HunterMovement>().setHunterPos(HunterPos.Top);
                }
                else
                {
                    newHunter.transform.position = new Vector3(transform.position.x, Random.Range(-2, -10), 0);
                    newHunter.GetComponent<HunterMovement>().setHunterPos(HunterPos.Bottom);
                }
            }   
            else
            {
                newHunter.transform.position = new Vector3(transform.position.x, Random.Range(-10, 10), 0);
            }
            
        }

    }

    bool OnPhaseEnd()
    {
        if ( transform.position.x > -11)
        {
            transform.position += new Vector3(-velocity * Time.deltaTime, 0, 0);
            return false;
        }

        return true;
    }

    bool OnPhaseStart()
    {
        if (transform.position.x < -7)
        {
            transform.position += new Vector3(velocity * Time.deltaTime, 0, 0);
            return false;
        }
        return true;
    }
}

enum HunterSpawnPhase
{
    Spawn,
    Start,
    End,
    None
}

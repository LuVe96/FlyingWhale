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
        
    }

    // Update is called once per frame
    void Update()
    {

        if(GameManager.Instance.levelDifficulty != currentDifficulty)
        {
            phase = HunterSpawnPhase.End;
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
                phase = HunterSpawnPhase.Start;
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
        switch (GameManager.Instance.levelDifficulty)
        {
            case LevelDifficulty.Easy: spawnhunters(new GameObject[1] { normalHunter}); break;
            case LevelDifficulty.Normal: spawnhunters(new GameObject[1] { specialHunter }); break;
            case LevelDifficulty.Hard: spawnhunters(new GameObject[2] { normalHunter, specialHunter }); break;

        }

    }

    void spawnhunters( GameObject [] hunters)
    {
        foreach (var hunter in hunters)
        {
            GameObject newHunter = Instantiate(hunter, transform);
            newHunter.transform.position = new Vector3(transform.position.x, Random.Range(-10, 10), 0);

        }
    }

    bool OnPhaseEnd()
    {
        if( transform.position.x > -11)
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

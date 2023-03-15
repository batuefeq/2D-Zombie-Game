using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class ZombieGenerator : MonoBehaviour
{
    public GameObject[] zombiePrefabs;
    public Zombie zombie;
    IncrementalBehaviour incrementalBehaviour;



    void ZombieSpawner()
    {
        Instantiate(zombiePrefabs[Random.Range(0, 1)], transform);
    }


    void SpawnerTimer()
    {
        try
        {
            if (zombie.zombieDead)
            {
                SettingScore.score += 20;
                incrementalBehaviour.IncrementalTextSpawn();
                zombie.zombieDead = false;
                Invoke("ZombieSpawner", Random.Range(0.5f, 3));
                Destroy(zombie.gameObject);
            }
        }
        catch (Exception)
        {
            print("Waiting for zombies");
        }
             
    }


    void Start()
    {
        zombie = GetComponentInChildren<Zombie>();
        incrementalBehaviour = GetComponent<IncrementalBehaviour>();
    }

    
    void Update()
    {
        try
        {
            zombie = GetComponentInChildren<Zombie>();
        }
        catch (Exception)
        {
            Debug.Log("Loading a Zombie");
        }
        SpawnerTimer();
    }
}

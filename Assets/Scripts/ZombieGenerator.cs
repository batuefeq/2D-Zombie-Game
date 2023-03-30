using UnityEngine;
using System;
using Random = UnityEngine.Random;


public class ZombieGenerator : MonoBehaviour
{
    public GameObject[] zombiePrefabs;
    public Zombie zombie;

    public delegate void OnZombieDeath();
    public static event OnZombieDeath CallUIFunction;

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
                CallUIFunction();
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
    }

    
    void Update()
    {
        try
        {
            zombie = GetComponentInChildren<Zombie>(); // could use trygetcomponent
        }
        catch (Exception)
        {
            Debug.Log("Loading a Zombie");
        }
        SpawnerTimer();
    }
}

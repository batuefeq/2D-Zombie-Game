using UnityEngine;
using System;
using System.Collections;
using Random = UnityEngine.Random;


public class ZombieGenerator : MonoBehaviour
{
    public GameObject[] zombiePrefabs;
    public Zombie zombie;

    public delegate void OnZombieDeath();
    public static event OnZombieDeath CallUIFunction;
    public GameObject dieBody;
    public GameObject soundObject;
    private GameObject _soundObject;

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
                Invoke("ZombieSpawner", Random.Range(0.5f, 2f));
                DieRoutuine();
                Destroy(zombie.gameObject);
            }
        }
        catch (Exception)
        {
            print("Waiting for zombies");
        }
             
    }


    private void DieRoutuine()
    {
        GameObject body = Instantiate(dieBody, zombie.gameObject.transform);
        body.transform.parent = gameObject.transform;
        int temp = Random.Range(0, 2);
        if (temp == 1)
        {
            body.transform.SetPositionAndRotation(new Vector3(body.transform.position.x, -6.1f, body.transform.position.z), Quaternion.Euler(0, 0, 90));
            StartCoroutine(BodyFade(body));
        }
        else
        {
            body.transform.SetPositionAndRotation(new Vector3(body.transform.position.x, -5.89f, body.transform.position.z), Quaternion.Euler(0, 0, 270));
            StartCoroutine(BodyFade(body));
        }               
    }


    private IEnumerator BodyFade(GameObject tempBody)
    {
        SpriteRenderer renderer = tempBody.GetComponent<SpriteRenderer>();
        Color tempColor = renderer.material.color;
        var tempvalue = 1f;
        while (tempvalue > 0)
        {
            tempvalue -= 0.01f;
            tempColor.a = tempvalue;
            renderer.material.color = tempColor;
            yield return null;
        }

        yield return new WaitForSeconds(0.01f);
        Destroy(tempBody);
    }


    private void ZombieFollower()
    {
        if (zombie != null)
        {
            if (_soundObject == null)
            {
                _soundObject = Instantiate(soundObject, zombie.gameObject.transform);
                _soundObject.transform.parent = gameObject.transform;
            }

            _soundObject.transform.SetPositionAndRotation(zombie.gameObject.transform.position, zombie.transform.rotation);
        }
        else
        {
            Destroy(_soundObject, 1.5f);
        }
    }


    private void Awake()
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
        ZombieFollower();
    }
}

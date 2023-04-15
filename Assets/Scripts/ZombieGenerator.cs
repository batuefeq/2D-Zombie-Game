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
            body.transform.rotation = Quaternion.Euler(0, 0, 90);
            body.transform.position = new Vector3(body.transform.position.x, -6.1f, body.transform.position.z);
            StartCoroutine(BodyFade(body));
            print("inside 2");
        }
        else
        {
            body.transform.rotation = Quaternion.Euler(0, 0, 270);
            body.transform.position = new Vector3(body.transform.position.x, -5.89f, body.transform.position.z);
            StartCoroutine(BodyFade(body));
            print("inside 1");
        }               
    }


    private IEnumerator BodyFade(GameObject tempBody)
    {
        print("inside");
        var tempvalue = 255f;
        while (tempvalue > 0)
        {
            print("inside while");
            tempvalue -= 1f;
            Color tempColor = new Color(0, 0, 0, tempvalue);
            tempBody.GetComponent<SpriteRenderer>().color = tempColor;
            print(tempBody.GetComponent<SpriteRenderer>().color);
            tempBody.transform.SetPositionAndRotation(transform.position, transform.rotation);
            yield return null;
        }

        yield return new WaitForSeconds(0.1f);
        Destroy(tempBody);
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
    }
}

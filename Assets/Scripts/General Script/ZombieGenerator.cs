using UnityEngine;
using System;
using System.Collections;
using Random = UnityEngine.Random;


public class ZombieGenerator : MonoBehaviour
{
    public GameObject[] zombiePrefabs;
    public Zombie zombie;
    public Player player;
    public ParticleSystem particle;

    public delegate void OnZombieDeath();
    public static event OnZombieDeath CallUIFunction;
    public GameObject soundObject, bloodParticle, groundBloodParticle, dieBody;
    private GameObject _soundObject;

    void ZombieSpawner()
    {
        Instantiate(zombiePrefabs[Random.Range(0, 1)], transform);
    }


    void SpawnerTimer()
    {
        try
        {
            if (zombie.zombieDead) // called once
            {
                CallUIFunction();
                zombie.zombieDead = false;
                Invoke("ZombieSpawner", Random.Range(0.5f, 2f));
                DieRoutine();
                Destroy(zombie.gameObject);
            }
        }
        catch (Exception)
        {
            print("Waiting for zombies");
        }
             
    }


    private void BloodSplatter()
    {
        var particle = Instantiate(bloodParticle, zombie.gameObject.transform);
        particle.transform.parent = null;
        Destroy(particle, 1.1f);
    }


    private void BloodGroundSplatter()
    {
        var particle = Instantiate(bloodParticle, zombie.gameObject.transform);
        particle.transform.parent = null;
        Destroy(particle, 1.1f);
    }



    private void DieRoutine()
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
            tempvalue -= 2f * Time.deltaTime;
            tempColor.a = tempvalue;
            renderer.material.color = tempColor;
            yield return null;
        }

        yield return null;
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
            ParticlePositionSetter();
        }
        else
        {
            Destroy(_soundObject, 1.5f);
        }
    }


    private void ParticlePositionSetter()
    {
        var shape = particle.shape;
        shape.position = new Vector3(zombie.gameObject.transform.position.x + Mathf.Abs(player.transform.position.x), 0, player.gameObject.transform.position.z);
    }


    public void UltimatePointCollector(int value)
    {
        if (!Player.inUltimate)
        {
            var count = particle.emission.GetBurst(0);
            count.count = new ParticleSystem.MinMaxCurve(value);
            particle.emission.SetBurst(0, count);
            particle.Play();
            GameManager.ultimatePoints += value;
        }      
    }




    private void Awake()
    {
        zombie = GetComponentInChildren<Zombie>();
        Player.onJumpKill += BloodSplatter;
        Player.onStab += BloodGroundSplatter;
        Bullet.ImpactCheck += UltimatePointCollector;
    }


    private void OnDisable()
    {
        Player.onJumpKill -= BloodSplatter;
        Player.onStab -= BloodGroundSplatter;
        Bullet.ImpactCheck -= UltimatePointCollector;
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

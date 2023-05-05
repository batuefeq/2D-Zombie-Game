using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public GameObject bloodPrefab;
    public GameObject hsBloodPrefab;
    public ParticleSystem particle;
    public delegate void ZombieHit();
    public delegate void ZombieHitUltimateChecker(int value);
    public static event ZombieHit ZombieImpact, ZombieHeadImpact;
    public static event ZombieHitUltimateChecker ImpactCheck;
    public int bulletDmg = 5;

    private int bodyPoints = 3;
    private int headPoints = 7;

    private void Awake()
    {
        GetComponentInParent<Player>().baseDamage = bulletDmg;
        StartCoroutine(BulletKiller());
    }


    private IEnumerator BulletKiller()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Zombie>())
        {
            if(collision.collider.GetType() == typeof(BoxCollider2D)) // headshot
            {
                BulletHeadCaller();
                collision.gameObject.GetComponent<Zombie>().zombieHealth = GetComponentInParent<Player>().baseDamage * 2;
            }
            else //other shots.
            {
                BulletBodyCaller();
                collision.gameObject.GetComponent<Zombie>().zombieHealth = GetComponentInParent<Player>().baseDamage;                         
            }                     
            collision.gameObject.GetComponent<Zombie>().ZombiePusher();
            Destroy(gameObject);
        }
    }



    private void BulletHeadCaller()
    {
        ZombieHeadImpact?.Invoke();
        ImpactCheck?.Invoke(headPoints);
        var hsBlod = Instantiate(hsBloodPrefab, transform);
        hsBlod.transform.parent = null;
    }


    private void BulletBodyCaller()
    {
        ImpactCheck?.Invoke(bodyPoints);
        ZombieImpact?.Invoke();
        var blod = Instantiate(bloodPrefab, transform);
        blod.transform.parent = null;
    }
}
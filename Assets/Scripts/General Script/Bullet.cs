using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public GameObject bloodPrefab;
    public GameObject hsBloodPrefab;
    public delegate void ZombieHit();
    public static event ZombieHit ZombieImpact, ZombieHeadImpact;
    public int bulletDmg = 5;
    

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
        var hsBlod = Instantiate(hsBloodPrefab, transform);
        GameManager.ultimatePoints += 10;
        hsBlod.transform.parent = null;
    }


    private void BulletBodyCaller()
    {
        ZombieImpact?.Invoke();
        var blod = Instantiate(bloodPrefab, transform);
        GameManager.ultimatePoints += 5;
        blod.transform.parent = null;
    }
}
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
                ZombieHeadImpact?.Invoke();
                var hsBlod = Instantiate(hsBloodPrefab, transform);
                collision.gameObject.GetComponent<Zombie>().zombieHealth = GetComponentInParent<Player>().baseDamage * 2;
                hsBlod.transform.parent = null;             
            }
            else //other shots.
            {
                ZombieImpact?.Invoke();
                var blod = Instantiate(bloodPrefab, transform);
                collision.gameObject.GetComponent<Zombie>().zombieHealth = GetComponentInParent<Player>().baseDamage;
                blod.transform.parent = null;             
            }                     
            collision.gameObject.GetComponent<Zombie>().ZombiePusher();
            Destroy(gameObject);
        }
    }
}

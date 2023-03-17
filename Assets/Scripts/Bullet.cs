using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bloodPrefab;
    public GameObject hsBloodPrefab;
    public int bulletDmg = 5;

    private void Start()
    {
        GetComponentInParent<Player>().baseDamage = bulletDmg;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Zombie>())
        {
            if(collision.collider.GetType() == typeof(CircleCollider2D))
            {
                var hsBlod = Instantiate(hsBloodPrefab, transform);
                collision.gameObject.GetComponent<Zombie>().zombieHealth = GetComponentInParent<Player>().baseDamage * 2;
                hsBlod.transform.parent = null;
            }
            else
            {
                var blod = Instantiate(bloodPrefab, transform);
                collision.gameObject.GetComponent<Zombie>().zombieHealth = GetComponentInParent<Player>().baseDamage;
                blod.transform.parent = null;
                print(collision.GetType());
            }
            
            
            collision.gameObject.GetComponent<Zombie>().ZombiePusher();
            Destroy(gameObject);
        }
    }


}

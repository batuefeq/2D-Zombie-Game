using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bloodPrefab;
    public int bulletDmg = 5;

    private void Start()
    {
        GetComponentInParent<Player>().baseDamage = bulletDmg;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Zombie>())
        {
            var blod = Instantiate(bloodPrefab,transform);
            blod.transform.parent = null;
            collision.gameObject.GetComponent<Zombie>().zombieHealth = GetComponentInParent<Player>().baseDamage;
            collision.gameObject.GetComponent<Zombie>().ZombiePusher();
            Destroy(gameObject);
        }
    }


}

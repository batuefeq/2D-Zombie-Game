using UnityEngine;
using System.Collections;


public class Zombie : MonoBehaviour
{
    public ZombieSettings zombieSettings;
    bool isBulletHit;
    static float currentSpeed;
    public bool zombieDead = false;


    int _health;
    public int zombieHealth
    {
        get
        {
            return _health;
        }
        set
        {
            _health -= value;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {            
            Destroy(collision.gameObject);
        }      
    }



    private void ZombieMovement()
    {
        if (!isBulletHit)
        {
            transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * zombieSettings.bulletImpactSpeed * Time.deltaTime);
        }       
    }


    private void Die()
    {
        if (zombieHealth <= 0)
        {
            zombieDead = true;
        }
    }


    private void SpeedAdjuster()
    {       
        if(currentSpeed >= zombieSettings.maxSpeed)
        {
            currentSpeed = zombieSettings.maxSpeed;
        }
        else if (currentSpeed == 0)
        {
            currentSpeed = zombieSettings.minSpeed;
        }
        else if (currentSpeed < zombieSettings.maxSpeed)
        {
            currentSpeed += zombieSettings.incrementSpeed;
        }        
    }


    public void ZombiePusher()
    {
        isBulletHit = true;
        StartCoroutine(zombiePushTimer());
    }


    IEnumerator zombiePushTimer()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        isBulletHit = false;
    }


    void Start()
    {
        _health = zombieSettings.health;         
    }


    private void Update()
    {
        Die();
        ZombieMovement();
        SpeedAdjuster();
    }
}

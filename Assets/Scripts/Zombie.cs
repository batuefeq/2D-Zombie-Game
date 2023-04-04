using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Zombie : MonoBehaviour
{
    public ZombieSettings zombieSettings;
    bool isBulletHit;
    static float currentSpeed;
    public bool zombieDead = false;
    public static bool isPlayerContact = false;


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
            isPlayerContact = true;
        }      
    }


    private void ZombieMovement()
    {
        if (!isBulletHit)
        {
            transform.Translate(currentSpeed * Time.deltaTime * Vector2.left);
        }
        else
        {
            transform.Translate(zombieSettings.bulletImpactSpeed * Time.deltaTime * Vector2.right);
        }       
    }


    private void Die()
    {
        if (zombieHealth <= 0)
        {
            zombieDead = true;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }


    private void SpeedAdjuster()
    {
        if (!zombieDead)
        {
            if (currentSpeed >= zombieSettings.maxSpeed)
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


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentSpeed = zombieSettings.minSpeed;
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
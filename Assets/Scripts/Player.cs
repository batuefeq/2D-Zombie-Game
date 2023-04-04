using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    public PlayerSettings playerSettings;
    Shooting shooting;

    public delegate void OnShoot();
    public static event OnShoot onShoot, onStab, onSwish, onJump, onJumpKill;


    public BoxCollider2D stabCollider, stabBottomCollider;
   
    float timer = 0f;

    Transform muzzleTransform;
    public bool isGrounded;
    public bool stabbing;
    

    int _damage;
    public int baseDamage
    {
        set
        {
            _damage = value + playerSettings.baseDamage;
        }
        get
        {
            return _damage;
        }
    }


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        muzzleTransform = gameObject.transform.GetChild(1);
        stabCollider = GetComponentInChildren<BoxCollider2D>();
        shooting = GetComponent<Shooting>();
        stabBottomCollider = gameObject.transform.GetChild(3).GetComponent<BoxCollider2D>();;
    }


    void Update()
    {
        if(!EndGameUIBehaviour.gamePaused)
        {
            Jump();
            Shot();
            Stabbing();
        }    
    }


    private void Shot()
    {
        timer += Time.deltaTime;
        var nextTimeToFire = 1 / playerSettings.fireRate;
        if (timer >= nextTimeToFire)
        {
            if (Input.GetMouseButtonDown(0))
            {               
                if (!shooting.isReloading)
                {
                    onShoot?.Invoke();
                    var bul = Instantiate(playerSettings.bulletPrefab, muzzleTransform);
                    Instantiate(playerSettings.muzzlePrefab, muzzleTransform);
                    bul.GetComponent<Rigidbody2D>().AddForce(Vector2.right * playerSettings.bulletSpeed, ForceMode2D.Force);
                    timer = 0f;
                }               
            }
        }                     
    }

   
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                onJump();
                rb.AddForce(Vector2.up * playerSettings.jumpForce);
                isGrounded = false;
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            if (isGrounded == false)
            {
                isGrounded = true;
            }
        }       
    } // ground check


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Zombie>() && isGrounded)
        {
            onStab();
            var tempHealth = collision.GetComponent<Zombie>().zombieHealth; // fikir, stabbing ile kýrýlabilir obstaclelar ve zýplanmasý gereken obstaclelar.
            collision.GetComponent<Zombie>().zombieHealth = tempHealth;
        }
        if (collision.GetComponent<Zombie>() && !isGrounded) // zýplama
        {
            StopCoroutine("StabTimer");
            onStab();
            onJumpKill();
            var tempHealth = collision.GetComponent<Zombie>().zombieHealth;
            collision.GetComponent<Zombie>().zombieHealth = tempHealth;
            stabbing = false;         
        }
    }


    private void Stabbing()
    {      
        if (Input.GetMouseButtonDown(1) && !stabbing)
        {
            stabbing = true;
            onSwish();           
            StartCoroutine("StabTimer");
            StartCoroutine(ColliderTimer());
        }       
    }
    

    IEnumerator ColliderTimer()
    {
        if (isGrounded)
        {
            stabCollider.enabled = true;
            yield return new WaitForSecondsRealtime(playerSettings.stabTime);
            stabCollider.enabled = false;
        }
        else if (!isGrounded)
        {
            stabBottomCollider.enabled = true;
            yield return new WaitForSecondsRealtime(playerSettings.airStabTime);
            stabBottomCollider.enabled = false;
        }       
    }

   
    IEnumerator StabTimer()
    {   
        yield return new WaitForSecondsRealtime(playerSettings.stabRate);
        stabbing = false;
    }
}
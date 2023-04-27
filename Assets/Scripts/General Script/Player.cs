using System.Collections;
using UnityEngine;


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
    public static bool inUltimate = false;


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
        stabBottomCollider = gameObject.transform.GetChild(3).GetComponent<BoxCollider2D>(); ;
    }


    void Update()
    {
        if (!EndGameUIBehaviour.gamePaused)
        {
            Shot();
            Stabbing();
            Jump();
            UltimateChecker();
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
                    CinemachineShakeEffect.Instance.ShakeCamera(0.9f, .1f);
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
            CinemachineShakeEffect.Instance.ShakeCamera(1.5f, 0.25f);
        }
        if (collision.GetComponent<Zombie>() && !isGrounded) // zýplama
        {
            StopCoroutine("StabTimer");
            onStab();
            onJumpKill();
            var tempHealth = collision.GetComponent<Zombie>().zombieHealth;
            collision.GetComponent<Zombie>().zombieHealth = tempHealth;
            stabbing = false;
            CinemachineShakeEffect.Instance.ShakeCamera(1f, 0.25f);
        }
    }


    private void Stabbing()
    {
        if (Input.GetMouseButtonDown(1) && !stabbing)
        {
            stabbing = true;
            onSwish();
            CinemachineShakeEffect.Instance.ShakeCamera(0.5f, .1f);
            StartCoroutine("StabTimer");
            if (isGrounded)
            {
                StartCoroutine(GroundKnifeColliderTimer());
            }
            else if (!isGrounded)
            {
                StartCoroutine(AirColliderTimer());
            }

        }
    }


    private void UltimateChecker()
    {
        if (GameManager.ultimatePoints == playerSettings.maxUltimatePoint)
        {
            UseUltimate();
        }
        if (inUltimate)
        {
            baseDamage = 200;
        }
        else
        {
            baseDamage = 0;
        }
    }


    private void UseUltimate()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine("UltimateMode");         
        }
    }


    private IEnumerator UltimateMode()
    {
        inUltimate = true;
        yield return new WaitForSeconds(10f);
        inUltimate = false; 
    }


    private IEnumerator GroundKnifeColliderTimer()
    {
        stabCollider.enabled = true;
        yield return new WaitForSeconds(playerSettings.stabTime);
        stabCollider.enabled = false;
    }


    private IEnumerator AirColliderTimer()
    {
        stabBottomCollider.enabled = true;
        yield return new WaitForSeconds(playerSettings.airStabTime);
        stabBottomCollider.enabled = false;
    }


    IEnumerator StabTimer()
    {
        yield return new WaitForSeconds(playerSettings.stabRate);
        stabbing = false;
    }
}
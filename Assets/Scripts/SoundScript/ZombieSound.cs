using UnityEngine;
using UnityEngine.Audio;

public class ZombieSound : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip hsClip;
    [SerializeField]
    private AudioClip[] bodyClip, zombieClip;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        Bullet.ZombieImpact += BodyClip;
        Bullet.ZombieHeadImpact += HsClip;
    }


    private void OnDisable()
    {
        Bullet.ZombieImpact -= BodyClip;
        Bullet.ZombieHeadImpact -= HsClip;
    }


    private void HsClip()
    {
        audioSource.volume = 0.6f;
        NewMethod();
    }


    private void NewMethod()
    {
        int random = Random.Range(0, 2);
        audioSource.PlayOneShot(hsClip);
        if (random == 1)
        {
            audioSource.PlayOneShot(zombieClip[Random.Range(0, 2)]);
        }
        
    }


    private void BodyClip()
    {
        int random = Random.Range(0, 2);
        if (random == 1)
        {
            audioSource.PlayOneShot(zombieClip[Random.Range(0, 2)]);
        }
        audioSource.volume = 0.6f;
        audioSource.PlayOneShot(bodyClip[Random.Range(0, 2)]);
    }
}

using UnityEngine;
using UnityEngine.Audio;

public class ZombieSound : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip hsClip;
    [SerializeField]
    private AudioClip[] bodyClip, zombieClip;
    [SerializeField]
    private AudioClip finishClip;
    private int temp = 0;


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
        audioSource.volume = 0.4f;
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


    private void EndGameSound()
    {
        if (Zombie.isPlayerContact == true && temp == 0)
        {
            audioSource.volume = 0.5f;
            audioSource.PlayOneShot(finishClip);
            temp++;
        }
        else if (Zombie.isPlayerContact == false)
        {
            temp = 0;
        }
    }

    private void Update()
    {
        EndGameSound();
    }


    private void BodyClip()
    {
        int random = Random.Range(0, 2);
        if (random == 1)
        {
            audioSource.PlayOneShot(zombieClip[Random.Range(0, 2)]);
        }
        audioSource.volume = 0.4f;
        audioSource.PlayOneShot(bodyClip[Random.Range(0, 2)]);
    }
}

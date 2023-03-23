using UnityEngine;


public class PistolSound : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip reloadClip;
    [SerializeField]
    private AudioClip[] clips;
    [SerializeField]
    private AudioClip[] stabClip;
    [SerializeField]
    private AudioClip[] swishClip;
    

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Player.onShoot += ShootSound;
        Player.onStab += StabbingSound;
        Player.onSwish += SwishSound;
        Shooting.onReload += ReloadSound;
    }


    private void SwishSound()
    {
        audioSource.PlayOneShot(swishClip[Random.Range(0, 1)]);
    }


    void ShootSound()
    {
        audioSource.volume = 0.2f;
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }
    

    void ReloadSound()
    {
        audioSource.PlayOneShot(reloadClip);
    }


    void StabbingSound()
    {
        audioSource.PlayOneShot(stabClip[Random.Range(0,1)]);
    }


    private AudioClip GetRandomClip()
    {
        return clips[UnityEngine.Random.Range(0, clips.Length)];
    }
}

using UnityEngine;


public class PistolSound : MonoBehaviour
{  
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip reloadClip;
    [SerializeField]
    private AudioClip[] clips;
    

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Player.onShoot += ShootSound;
        Shooting.onReload += ReloadSound;
    }

    void ShootSound()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }
    

    void ReloadSound()
    {
        audioSource.PlayOneShot(reloadClip);
    }


    private AudioClip GetRandomClip()
    {
        return clips[UnityEngine.Random.Range(0, clips.Length)];
    }
    
}

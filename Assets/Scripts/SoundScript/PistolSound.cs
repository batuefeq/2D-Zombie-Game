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
    [SerializeField]
    private AudioClip jumpClip;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        Player.onShoot += ShootSound;
        Player.onStab += StabbingSound;
        Player.onSwish += SwishSound;
        Player.onJump += JumpSound;
        Shooting.onReload += ReloadSound;
    }
    

    private void OnDisable()
    {
        Player.onShoot -= ShootSound;
        Player.onStab -= StabbingSound;
        Player.onSwish -= SwishSound;
        Player.onJump -= JumpSound;
        Shooting.onReload -= ReloadSound;
    }


    private void SwishSound()
    {
        audioSource.volume = 0.7f;
        audioSource.PlayOneShot(swishClip[Random.Range(0, 2)]);
    }

    
    void ShootSound()
    {
        audioSource.volume = 0.2f;
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }


    void ReloadSound()
    {
        audioSource.volume = 0.5f;
        audioSource.PlayOneShot(reloadClip);
    }


    void JumpSound()
    {
        audioSource.volume = 0.5f;
        audioSource.PlayOneShot(jumpClip);
    }


    void StabbingSound()
    {
        audioSource.volume = 0.8f;
        audioSource.PlayOneShot(stabClip[Random.Range(0, 2)]);
    }


    private AudioClip GetRandomClip()
    {
        return clips[UnityEngine.Random.Range(0, clips.Length)];
    }


   

    private void Update()
    {
        
        if (EndGameUIBehaviour.gamePaused)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.UnPause();
        }       
    }

}

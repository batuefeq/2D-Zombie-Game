using UnityEngine;


public class ButtonClickSound : MonoBehaviour
{
    private AudioSource auSource;
    [SerializeField]
    private AudioClip clip;


    private void Awake()
    {
        auSource = GetComponent<AudioSource>();
    }


    public void PlaySound()
    {
        auSource.PlayOneShot(clip);
    }
}

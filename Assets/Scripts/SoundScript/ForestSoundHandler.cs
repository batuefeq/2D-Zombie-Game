using UnityEngine;


public class ForestSoundHandler : MonoBehaviour
{
    private AudioSource auSource;
    [SerializeField]
    private AudioClip[] clips;

    private void Awake()
    {
        auSource = GetComponent<AudioSource>();
    }


    private void Main()
    {
        auSource.PlayOneShot(clips[Random.Range(0, 1)]);
    }


    private void MusicHelper()
    {
        if (auSource.isPlaying == true) return;

        Main();
    }


    void Update()
    {
        MusicHelper();
    }
}

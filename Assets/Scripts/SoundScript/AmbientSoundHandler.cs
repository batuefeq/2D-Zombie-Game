using UnityEngine;
using UnityEngine.SceneManagement;


public class AmbientSoundHandler : MonoBehaviour
{
    AudioSource auSource;
    [SerializeField]
    AudioClip[] clips;
    private static AmbientSoundHandler ambient;

    

    private void Awake()
    {
        auSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(this);
        if (ambient == null) 
        {
            ambient = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void MusicShuffler() => auSource.PlayOneShot(clips[Random.Range(0, 1)]);

    private void MusicEndHandler()
    {
        if (auSource.isPlaying) return;

        MusicShuffler();
    }


    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            
        }
        else
        {
            Destroy(gameObject);
        }
        MusicEndHandler();
    }
}
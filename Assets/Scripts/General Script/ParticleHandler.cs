using UnityEngine;

public class ParticleHandler : MonoBehaviour
{
    private AudioSource audioSource;
    private int counter = 0;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(other);
        if (other.CompareTag("Player"))
        {
            counter++;
        }
    }

    private void Update()
    {
        Player();
    }

    private void Player()
    {
        if (counter == 5)
        {
            audioSource.Play();
            counter = 0;
        }
    }
}

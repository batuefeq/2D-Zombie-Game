using UnityEngine;

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
        AudioSource.PlayClipAtPoint(hsClip, gameObject.transform.position, 1f);
        if (random == 1)
        {
            AudioSource.PlayClipAtPoint((zombieClip[Random.Range(0, 2)]), gameObject.transform.position);
        }
        
    }


    private void BodyClip()
    {
        int random = Random.Range(0, 2);
        if (random == 1)
        {
            AudioSource.PlayClipAtPoint((zombieClip[Random.Range(0, 2)]), gameObject.transform.position);
        }
        audioSource.volume = 0.6f;
        AudioSource.PlayClipAtPoint((bodyClip[Random.Range(0, 2)]), gameObject.transform.position);
    }
}

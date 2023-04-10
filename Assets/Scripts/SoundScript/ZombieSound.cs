using UnityEngine;

public class ZombieSound : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip hsClip;
    [SerializeField]
    private AudioClip[] bodyClip;


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
        AudioSource.PlayClipAtPoint(hsClip, gameObject.transform.position, 1f);
    }

    private void BodyClip()
    {
        audioSource.volume = 0.6f;
        AudioSource.PlayClipAtPoint((bodyClip[Random.Range(0, 2)]), gameObject.transform.position);
    }
}

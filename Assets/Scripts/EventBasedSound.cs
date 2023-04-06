using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBasedSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] walkClip;

    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponentInParent<AudioSource>();
    }

    private void Step()
    {
        audioSource.volume = 0.7f;
        audioSource.PlayOneShot(walkClip[Random.Range(0, 6)]);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}

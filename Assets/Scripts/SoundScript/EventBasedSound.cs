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
        audioSource = GetComponent<AudioSource>();
    }

    private void Step()
    {
        audioSource.PlayOneShot(walkClip[Random.Range(0, 6)]);
    }
}

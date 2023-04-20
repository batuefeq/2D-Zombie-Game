using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class MusicVolumeHolder : MonoBehaviour
{
    private Slider slider;
    public AudioMixer mixer;

    void Start()
    {
        slider = GetComponent<Slider>();
        mixer.GetFloat("MusicParam", out float value);
        slider.value = value;
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class SoundEffectHolder : MonoBehaviour
{
    private Slider slider;
    public AudioMixer mixer;

    void Start()
    {
        slider = GetComponent<Slider>();
        mixer.GetFloat("SoundEffectParam", out float value);
        slider.value = value;
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class AmbientMusicHolder : MonoBehaviour
{
    private Slider slider;
    public AudioMixer mixer;

    private void Start()
    {
        slider = GetComponent<Slider>();
        mixer.GetFloat("AmbientParam", out float value);
        slider.value = value;
    }
}

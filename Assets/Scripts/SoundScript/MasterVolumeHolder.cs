using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class MasterVolumeHolder : MonoBehaviour
{
    private Slider slider;
    public AudioMixer mixer;

    void Awake()
    {
        slider = GetComponent<Slider>();
        mixer.GetFloat("MasterParam", out float value);
        slider.value = value;
    }
}

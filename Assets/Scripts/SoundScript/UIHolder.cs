using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class UIHolder : MonoBehaviour
{
    private Slider slider;
    public AudioMixer mixer;

    void Awake()
    {
        slider = GetComponent<Slider>();
        mixer.GetFloat("UIParam", out float value);
        slider.value = value;
    }
}

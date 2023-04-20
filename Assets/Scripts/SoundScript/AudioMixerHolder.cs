using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class AudioMixerHolder : MonoBehaviour
{
    public AudioMixer mixer;

    void Start() // Unity bug prevents using awake.
    {
        mixer.SetFloat("AmbientParam", PlayerPrefs.GetFloat("AmbientVolume"));
        mixer.SetFloat("MasterParam", PlayerPrefs.GetFloat("MasterVolume"));
        mixer.SetFloat("SoundEffectParam", PlayerPrefs.GetFloat("SoundEffectVolume"));
        mixer.SetFloat("UIParam", PlayerPrefs.GetFloat("UIVolume"));
        mixer.SetFloat("MusicParam", PlayerPrefs.GetFloat("MusicVolume"));

    }
}

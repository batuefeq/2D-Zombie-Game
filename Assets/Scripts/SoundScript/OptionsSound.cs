using UnityEngine;
using UnityEngine.Audio;

public class OptionsSound : MonoBehaviour
{
    public AudioMixer audioMixer;


    public void SetVolumeMaster(float volume)
    {
        audioMixer.SetFloat("MasterParam", volume);
    }
    

    public void SetVolumeAmbient(float volume)
    {
        audioMixer.SetFloat("AmbientParam", volume);
    }
    
    
    public void SetVolumeSoundEffect(float volume)
    {
        audioMixer.SetFloat("SoundEffectParam", volume);
    }
    

    public void SetVolumeMusic(float volume)
    {
        audioMixer.SetFloat("MusicParam", volume);
    }
    

    public void SetVolumeUI(float volume)
    {
        audioMixer.SetFloat("UIParam", volume);
    }
}

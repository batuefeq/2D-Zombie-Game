using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class OptionsSound : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Text text;


    public void SaveSound()
    {        
        audioMixer.GetFloat("MasterParam", out float master);
        audioMixer.GetFloat("AmbientParam", out float ambient);
        audioMixer.GetFloat("SoundEffectParam", out float effect);
        audioMixer.GetFloat("MusicParam", out float music);
        audioMixer.GetFloat("UIParam", out float ui);

        PlayerPrefs.SetFloat("MasterVolume", master);
        PlayerPrefs.SetFloat("AmbientVolume", ambient);
        PlayerPrefs.SetFloat("SoundEffectVolume", effect);
        PlayerPrefs.SetFloat("MusicVolume", music);
        PlayerPrefs.SetFloat("UIVolume", ui);
        PlayerPrefs.Save();

        text.gameObject.SetActive(true);
    }


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
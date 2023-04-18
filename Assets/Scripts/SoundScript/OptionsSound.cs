using UnityEngine;
using System.Collections;
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

        SaveTextShower();
    }


    private void SaveTextShower()
    {
        text.gameObject.SetActive(true);
        if (text.color.a < 5)
        {
            text.CrossFadeAlpha(255, 0.0001f, true);
        }
        text.CrossFadeAlpha(0, 1.5f, true);
        StartCoroutine(AlphaSetter());
    }


    private IEnumerator AlphaSetter()
    {
        print("inside");
        yield return new WaitForSeconds(1f);
        text.gameObject.SetActive(false);
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
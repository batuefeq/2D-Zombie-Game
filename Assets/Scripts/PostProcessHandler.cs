using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessHandler : MonoBehaviour
{
    public VolumeProfile profile;
    private Vignette vignette;
    private ChromaticAberration aberration;
    private float vignetteIntensityNum = 0f;
    private float aberrationIntensityNum = 0f;
    private float timer = 0f;


    private void Start()
    {
        timer = 0f;
    }


    private void EffectMaster()
    {
        profile.TryGet(out vignette);
        profile.TryGet(out aberration);
        aberration.intensity.value = aberrationIntensityNum;
        vignette.intensity.value = vignetteIntensityNum;                        
    }


    private void IntensitySetter()
    {    
        if (Player.inUltimate)
        {
            timer += Time.deltaTime;
            if (timer >= 1f)
            {
                timer = 1f;
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
        if (timer < 0)
        {
            timer = 0;
        }
        print(timer);
        vignetteIntensityNum = Mathf.Lerp(0, 0.55f, timer);
        aberrationIntensityNum = Mathf.Lerp(0, 0.25f, timer);
    }


    void Update()
    {
        EffectMaster();
        IntensitySetter();
    }
}
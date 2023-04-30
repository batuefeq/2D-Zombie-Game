using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessHandler : MonoBehaviour
{
    public VolumeProfile profile;
    private Vignette vignette;
    private ClampedFloatParameter param;

    void Awake()
    {
        param = vignette.intensity;
        // profile = GetComponent<VolumeProfile>();    
    }


    private void EffectMaster()
    {
        if (Player.inUltimate)
        {
            if (profile.TryGet<Vignette>(out vignette))
            {
                StartCoroutine("EffectStarter");
            }
        }
    }


    private void NumberSetter()
    {       
         param.Interp(0f, 2f, 2);        
    }


    private IEnumerator EffectStarter()
    {
        while (Player.inUltimate)
        {
            profile.TryGet(out vignette);
            vignette.intensity = param;
            yield return null;
        }


        vignette.intensity.value = 0f;
        print("inside");
        yield return new WaitForSeconds(0.1f);
        print("outside");
        
    }

    
    void Update()
    {
        EffectMaster();
        NumberSetter();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SliderBulletHandler : MonoBehaviour
{
    private Slider slider;
    public PlayerSettings playerSettings;
    private Shaker shaker;
    private float timer = 0;

    public Color low;
    public Color high;

    void Awake()
    {
        slider = GetComponentInChildren<Slider>();
        slider.maxValue = 1 / playerSettings.fireRate;
        slider.value = slider.maxValue;
        shaker = GetComponent<Shaker>();
        Player.onShoot += Handle;
    }

    private void OnDisable()
    {
        Player.onShoot -= Handle;

    }

    
    private void Handle()
    {
        StartCoroutine("Enumerator");
    }


    IEnumerator Enumerator()
    {
        while (timer < 1 / playerSettings.fireRate)
        {                       
            timer += Time.deltaTime;
            slider.value = timer;
            slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
            yield return null;

        }
        timer = 0f;
        yield return new WaitForSeconds(0.00001f);
    }
    
}

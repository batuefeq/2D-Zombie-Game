using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHandle : MonoBehaviour
{
    private Slider slider;
    private Shaker shaker;
    public PlayerSettings playerSettings;
    private float timer = 0;
    private int incrementer = 0;
    private bool waitStab = true;

    public Color low;
    public Color high;


    void Awake()
    {
        slider = GetComponentInChildren<Slider>();
        slider.maxValue = playerSettings.stabRate;
        slider.value = slider.maxValue;
        shaker = GetComponent<Shaker>();
        Player.onSwish += Handling;
        Player.onJumpKill += JumpKillWatcher;
    }

    private void OnDisable()
    {
        Player.onSwish -= Handling;
        Player.onJumpKill -= JumpKillWatcher;
    }



    private void Handling()
    {        
        StartCoroutine("Enumerator");                       
    }

    private void JumpKillWatcher()
    {
        waitStab = false;
        slider.value = slider.maxValue;
        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
    }

    IEnumerator Enumerator()
    {
        while (timer < playerSettings.stabRate)
        {
            if (!waitStab)
            {
                waitStab = true;
                break;
            }
            if (Input.GetMouseButtonDown(1))
            {
                incrementer++;
                if (incrementer > 1)
                {
                    StartCoroutine(shaker.Shake(0.3f, 7f));
                }
            }

            timer += Time.deltaTime;
            slider.value = timer;
            slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
            yield return null;

        }
        timer = 0f;
        yield return new WaitForSeconds(0.00001f);
        incrementer = 0;
    }
}

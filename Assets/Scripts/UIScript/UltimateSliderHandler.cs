using UnityEngine;
using UnityEngine.UI;


public class UltimateSliderHandler : MonoBehaviour
{
    private Slider slider;
    public PlayerSettings pSettings;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = pSettings.maxUltimatePoint;
    }


    private void Update()
    {
        slider.value = GameManager.ultimatePoints;
    }
}
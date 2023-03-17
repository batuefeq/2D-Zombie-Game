using UnityEngine;
using UnityEngine.UI;

public class HealtBarSetter : MonoBehaviour
{
    public Slider slider;
    public Color low, high;
    public Vector3 offset;



    public void HealthSetter(int health)
    {
        slider.value = health;
    }


    // Update is called once per frame
    void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.position + offset);
    }
}

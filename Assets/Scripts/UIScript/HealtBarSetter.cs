using UnityEngine;
using UnityEngine.UI;

public class HealtBarSetter : MonoBehaviour
{
    public Slider slider;
    public Color low, high;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void HealthSetter(int health)
    {
        slider.value = health;
        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
    }


    // Update is called once per frame
    void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position);
    }
}

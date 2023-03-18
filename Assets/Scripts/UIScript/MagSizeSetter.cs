using UnityEngine;
using UnityEngine.UI;

public class MagSizeSetter : MonoBehaviour
{
    private Text text;

    
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = Shooting.magSize + " / 12";
    }
}

using UnityEngine;
using UnityEngine.UI;


public class MagSizeSetter : MonoBehaviour
{
    private Text text;
    public PlayerSettings playerSettings;
    
    void Start()
    {
        text = GetComponent<Text>();
    }


    void Update()
    {
        text.text = Shooting.magSize + " / " + playerSettings.magMaxSize;
    }
}

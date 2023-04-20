using UnityEngine;
using UnityEngine.UI;

public class ToggleHandler : MonoBehaviour
{
    private Toggle toggle;

    private void Awake()
    {
        toggle = GetComponent<Toggle>();
    }


    public void ToggleWathcer()
    {
        if (toggle.isOn)
        {
            GameModeManager.madMode = true;
        }
        else
        {
            GameModeManager.madMode = false;
        }
    }
}

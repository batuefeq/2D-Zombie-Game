using UnityEngine;
using UnityEngine.UI;

public class ToggleHandler : MonoBehaviour
{
    private Toggle toggle;

    private void Awake()
    {
        toggle = GetComponent<Toggle>();
        if (GameModeManager.madMode)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }
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

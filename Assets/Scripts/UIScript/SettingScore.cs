using UnityEngine;
using TMPro;

public class SettingScore : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    public static int score;

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void SettingText()
    {       
         scoreText.text = score.ToString();      
    }


    void Update()
    {
        SettingText();
    }
}

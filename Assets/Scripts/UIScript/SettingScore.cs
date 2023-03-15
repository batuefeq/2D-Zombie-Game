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

    private void OnEnable()
    {
        ZombieGenerator.CallUIFunction += SettingText;
    }

    private void OnDisable()
    {                
        ZombieGenerator.CallUIFunction -= SettingText;
    }

    private void SettingText()
    {
         score += 20;
         scoreText.text = score.ToString();      
    }


    void Update()
    {
        
    }
}

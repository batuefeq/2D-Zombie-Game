using UnityEngine;
using UnityEngine.UI;


public class SettingScore : MonoBehaviour
{
    private Text scoreText;
    public static int score;

    private void Start()
    {
        scoreText = GetComponent<Text>();
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
}

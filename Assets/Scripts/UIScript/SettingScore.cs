using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingScore : MonoBehaviour
{
    private Text scoreText;
    public static int score;

    private void Start()
    {
        scoreText = GetComponent<Text>();
        score = 0;
    }


    private void OnEnable()
    {
        ZombieGenerator.CallUIFunction += SettingText;
    }

    private void OnDisable()
    {                
        ZombieGenerator.CallUIFunction -= SettingText;
    }

    private void Update()
    {
        //AdminMode();
    }


   //private void AdminMode()
   //{
   //    if (Input.GetKeyDown(KeyCode.J))
   //    {
   //        score += 1000;
   //        scoreText.text = score.ToString();
   //    }
   //}



    private void SettingText()
    {
         score += 20;
         scoreText.text = score.ToString();
    }
}

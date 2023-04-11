using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EndGameUIBehaviour : MonoBehaviour
{
    private GameObject endGameUI;
    private CanvasGroup cg;
    public static bool gamePaused;
    private int highScore;
    private Text text;
   



    private void Awake()
    {
        endGameUI = gameObject.transform.GetChild(3).gameObject;
        endGameUI.SetActive(false);
        cg = endGameUI.GetComponent<CanvasGroup>();
        text = endGameUI.transform.GetChild(0).GetChild(1).GetComponent<Text>();
        text.text = PlayerPrefs.GetInt("HighScore").ToString();
        cg.alpha = 0;  
    }


    IEnumerator Prolonger()
    {      
        yield return new WaitForSecondsRealtime(0.36f);
        AlphaSetter();
    }


    void AlphaSetter()
    {       
        if(cg.alpha < 1)
        {
            cg.alpha += 0.008f;
        }
    }


    void EndGameUICaller()
    {
        if (Zombie.isPlayerContact)
        {
            endGameUI.SetActive(true);
            gamePaused = true;
            HighScoreSetter();
            StartCoroutine(Prolonger());
        }
    }


    private void HighScoreSetter()
    {
        if (SettingScore.score > highScore)
        {
            highScore = SettingScore.score;
            PlayerPrefs.SetInt("HighScore", highScore);
            text.text = SettingScore.score.ToString();
            PlayerPrefs.Save();
        } 
        else if (SettingScore.score <= highScore)
        {
            text.text = PlayerPrefs.GetInt("HighScore").ToString();
        }
    }


    private void GamePauseWatcher()
    {
        Time.timeScale = (gamePaused == true) ? 0.0000001f : 1; 
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Zombie.isPlayerContact = false;
        gamePaused = false;
        SettingScore.score = 0;
    }


    public void ExitGame()
    {
        Application.Quit();
    }


    void Update()
    {
        GamePauseWatcher();
        EndGameUICaller();
    }
}

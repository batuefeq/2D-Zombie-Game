using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;


public class EndGameUIBehaviour : MonoBehaviour
{
    private GameObject endGameUI;
    private CanvasGroup cg;
    public static bool gamePaused;
    private int highScore;
    private Text text;
    public GameObject newScoreText;



    private void Awake()
    {
        endGameUI = gameObject.transform.GetChild(3).gameObject;
        endGameUI.SetActive(false);
        cg = endGameUI.GetComponent<CanvasGroup>();
        text = endGameUI.transform.GetChild(0).GetChild(1).GetComponent<Text>();
        cg.alpha = 0;
        highScore = PlayerPrefs.GetInt("HighScore");
    }


    private void AlphaSetter()
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
            AlphaSetter();
        }
    }


    private void HighScoreSetter()
    {
        
        if (SettingScore.score > highScore)
        {
            print("new high score");
            newScoreText.SetActive(true);
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


    private void MouseHider()
    {
        if (SceneManager.GetActiveScene().name == "MainScene" && gamePaused == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (SceneManager.GetActiveScene().name == "StartScene")
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        
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


    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("StartScene");
        gamePaused = false;
        Zombie.isPlayerContact = false;
    }


    void Update()
    {
        GamePauseWatcher();
        EndGameUICaller();
        MouseHider();
    }
}

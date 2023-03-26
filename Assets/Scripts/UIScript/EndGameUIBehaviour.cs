using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class EndGameUIBehaviour : MonoBehaviour
{
    Text text;
    GameObject endGameUI;
    CanvasGroup cg;


    private void Awake()
    {
        endGameUI = gameObject.transform.GetChild(3).gameObject;
        endGameUI.SetActive(false);
        cg = endGameUI.GetComponent<CanvasGroup>();
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
            cg.alpha += 0.001f;
        }
    }


    void EndGameUICaller()
    {
        if (Zombie.isPlayerContact)
        {
            Time.timeScale = 0;
            endGameUI.SetActive(true);
            StartCoroutine(Prolonger());
        }
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Zombie.isPlayerContact = false;
        Time.timeScale = 1;
    }


    public void ExitGame()
    {
        Application.Quit();
    }


    void Update()
    {
        EndGameUICaller();
    }
}

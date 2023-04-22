using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject optionsMenu;
    [SerializeField]
    private GameObject creditsMenu;


    private void GamePauser()
    {
        if (Zombie.isPlayerContact) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EndGameUIBehaviour.gamePaused = !EndGameUIBehaviour.gamePaused;
            PauseHandler();
        }
    }


    private void PauseHandler()
    {
        if (EndGameUIBehaviour.gamePaused == true)
        {
            pauseMenu.SetActive(true);
        }
        else
        {
            pauseMenu.SetActive(false);
        }
    }


    public void OptionsOpener()
    {
        optionsMenu.SetActive(true);
    }

    
    public void OptionsCloser()
    {
        optionsMenu.SetActive(false);
    }


    public void GameStarter()
    {
        SceneManager.LoadScene("MainScene");
    }


    public void CreditsOpener()
    {
        creditsMenu.SetActive(true);
    }
   

    public void CreditsCloser()
    {
        creditsMenu.SetActive(false);
    }


    public void ExitGame()
    {
        Application.Quit();
    }


    void Update()
    {     
        GamePauser();
    }
}
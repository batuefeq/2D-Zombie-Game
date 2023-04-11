using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject optionsMenu;


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

   

    void Update()
    {     
        GamePauser();
    }
}

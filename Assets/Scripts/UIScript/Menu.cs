using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;


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


   

    void Update()
    {
        

        GamePauser();
    }
}

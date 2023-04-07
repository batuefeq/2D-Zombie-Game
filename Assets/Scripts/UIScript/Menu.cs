using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
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
    }   
    
 
    void Update()
    {
        GamePauser();
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public ZombieSettings zSettings;
    public PlayerSettings playerSettings;
    private bool done = false;
    public static int ultimatePoints = 0;
    


    private void Start()
    {
        Player.inUltimate = false;
        ultimatePoints = 0;

        if (zSettings != null)
        {
            if (!done)
            {
                zSettings.HardMode();
                done = true;
            }
            else
            {
                return;
            }
        }
        if (SceneManager.GetActiveScene().name == "StartScene")
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }


    private void UltimateSetter()
    {
        if (ultimatePoints == playerSettings.maxUltimatePoint || ultimatePoints > playerSettings.maxUltimatePoint)
        {
            ultimatePoints = playerSettings.maxUltimatePoint;
        }
        if (Player.inUltimate)
        {
            ultimatePoints = 0;
        }
    }

    private void Update()
    {
        UltimateSetter();
    }
}
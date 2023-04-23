using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public ZombieSettings zSettings;
    private bool done = false;
    public static int ultimatePoints = 0;

    private void Start()
    {
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
}
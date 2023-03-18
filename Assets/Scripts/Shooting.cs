using System.Collections;
using UnityEngine;


public class Shooting : MonoBehaviour
{
    public static int magSize;
    public PlayerSettings playerSettings;
    [System.NonSerialized]
    public bool isReloading;
   
    public delegate void OnReload();
    public static event OnReload onReload;



    void Start()
    {
        magSize = playerSettings.bulletCount;
        Player.onShoot += BulletCount;
    }


    void Update()
    {
        if(magSize == 0 && !isReloading)
        {
            StartCoroutine("Reload");
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine("Reload");
        }
    }


    public void BulletCount()
    {
        
        if (magSize > 0)
        {
            magSize--;
            print(magSize);
        }
    }


    IEnumerator Reload()
    {
        onReload();
        isReloading = true;
        print("reload start");
        yield return new WaitForSecondsRealtime(1.9f);
        isReloading = false;
        magSize = 12;
        print("reload finish");
    }
}
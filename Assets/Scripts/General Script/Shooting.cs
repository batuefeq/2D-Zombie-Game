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


    void Awake()
    {
        magSize = playerSettings.magMaxSize;
        Player.onShoot += BulletCount;
    }


    private void OnDisable()
    {
        Player.onShoot -= BulletCount;
    }


    void Update()
    {
        StartReloading();
    }


    private void StartReloading()
    {
        if (magSize == 0 && !isReloading)
        {
            StartCoroutine("Reload");
        }
        else if (Input.GetKeyDown(KeyCode.R) && !isReloading)
        {
            StartCoroutine("Reload");
        }
    }


    public void BulletCount()
    {
        if (magSize > 0)
        {
            magSize--;
        }
    }


    IEnumerator Reload()
    {
        onReload();
        isReloading = true;
        print("reload start");
        yield return new WaitForSeconds(1.9f);
        isReloading = false;
        magSize = playerSettings.magMaxSize;
        print("reload finish");
    }
}
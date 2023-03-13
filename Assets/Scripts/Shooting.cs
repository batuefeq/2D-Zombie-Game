using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    int magSize;
    public PlayerSettings playerSettings;
    [System.NonSerialized]
    public bool isReloading;
   

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
        isReloading = true;
        print("reload start");
        yield return new WaitForSecondsRealtime(1f);
        isReloading = false;
        magSize = 12;
        print("reload finish");
    }
}
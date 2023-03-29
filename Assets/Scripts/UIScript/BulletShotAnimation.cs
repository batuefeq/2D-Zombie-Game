using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BulletShotAnimation : MonoBehaviour
{
    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        Player.onShoot += RotatePhase;
    }

    private void OnDisable()
    {
        Player.onShoot -= RotatePhase;
    }

    void RotatePhase()
    {
        float timer = 0f;
        float waitTime = 99f;
        while (timer < waitTime)
        {
            timer += Time.deltaTime;
            transform.Rotate(Time.deltaTime * 10f * Vector3.forward);
            image.CrossFadeAlpha(0, 3f, true);
        }              
    }
}

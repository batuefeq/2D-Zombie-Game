using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BulletShotAnimation : MonoBehaviour
{
    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    void RotatePhase()
    {
        
    }


    void Update()
    {
        const float duration = 2f; //Seconds it should take to finish rotating
        float counter = 0;

        image.CrossFadeAlpha(0f, 2f, true);
        while (counter < duration)
        {
            counter += Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 90f), counter / duration);
        }
    }
}

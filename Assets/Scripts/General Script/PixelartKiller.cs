using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PixelartKiller : MonoBehaviour
{

    void Start()
    {
        float animTime = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;

        Destroy(gameObject, animTime);
    }
}

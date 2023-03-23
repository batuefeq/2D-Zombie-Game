using UnityEngine;


public class TextMover : MonoBehaviour
{
    void Update()
    {
        transform.Translate(20 * Time.deltaTime * Vector2.up);
    }
}

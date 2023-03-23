using UnityEngine;


public class TextMover : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector2.up * 20 * Time.deltaTime);
    }
}

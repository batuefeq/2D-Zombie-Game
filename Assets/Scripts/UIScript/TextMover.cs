using UnityEngine;


public class TextMover : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * 20 * Time.deltaTime);
    }
}

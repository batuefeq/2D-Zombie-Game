using System.Collections;
using UnityEngine;

public class Shaker : MonoBehaviour
{

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector2 orPos = transform.localPosition;

        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            if (Zombie.isPlayerContact)
            {
                break;
            }
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector2(x, y);

            elapsed += Time.deltaTime;

            yield return null;

        }
        transform.localPosition = orPos;
    }
}

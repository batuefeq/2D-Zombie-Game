using UnityEngine;


public class TopTextHandle : MonoBehaviour
{
    float tempX = 1f;
    float tempY = 1f;
    float time = 0;

    bool hasChanged = false;


    private void Awake()
    {
        transform.parent.gameObject.SetActive(false);
    }


    private void ScaleSetter()
    {             
        transform.localScale = new Vector3(tempX, tempY, 1);
    }


    private void TempNumSetter()
    {
      //while (hasChanged)
      //{
      //    print("x < 1.5");
      //    time += Time.deltaTime * 1f;
      //    tempX = Mathf.Lerp(0.5f, 1.5f, time);
      //    tempY = Mathf.Lerp(0.5f, 1.5f, time);
      //    if (tempX > 1.5f)
      //    {
      //        hasChanged = false;
      //        break;
      //    }
      //}
      //while(!hasChanged)
      //{
      //    tempX = Mathf.Lerp(0.5f, 1.5f, time);
      //    tempY = Mathf.Lerp(0.5f, 1.5f, time);
      //    time -= Time.deltaTime * 1f;
      //    if (tempX < 0.5f)
      //    {
      //        hasChanged = true;
      //        break;
      //    }
      //}
        ScaleSetter();
    }


    void Update()
    {
        TempNumSetter();
    }
}

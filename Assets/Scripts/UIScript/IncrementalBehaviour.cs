using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IncrementalBehaviour : MonoBehaviour
{
    public TextMeshProUGUI incrementText;



    public void IncrementalTextSpawn()
    {
        var text = Instantiate(incrementText,transform, false);
    }
   

    void Update()
    {
        IncrementalTextSpawn();
    }
}

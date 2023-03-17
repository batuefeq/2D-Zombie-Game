using UnityEngine;
using UnityEngine.UI;


public class IncrementalBehaviour : MonoBehaviour
{
    public Text incrementText;
    


    private void OnEnable()
    {
        ZombieGenerator.CallUIFunction += IncrementalTextSpawn;
    }


    private void OnDisable()
    {
        ZombieGenerator.CallUIFunction -= IncrementalTextSpawn;
    }


    private void IncrementalTextSpawn()
    { 
        var text = Instantiate(incrementText,transform, false);             
        AlphaDesigner(text);
    }
   

    private void AlphaDesigner(Text obj)
    {
        obj.CrossFadeAlpha(0, 1.2f, false);              
        Destroy(obj.gameObject, 2);     
    }
}
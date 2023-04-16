using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapScroller : MonoBehaviour
{
    float firstLayerSpeed, secondLayerSpeed;
    [SerializeField]
    private GameObject firstLayer, secondLayer;

    void Awake()
    {
        firstLayerSpeed = 2f;
        secondLayerSpeed = 1f;
    }

   
    private void SecondLayerMover()
    {
        secondLayer.transform.Translate(secondLayerSpeed * Time.deltaTime * Vector2.left);
    }


    private void FirstLayerMover()
    {
        firstLayer.transform.Translate(firstLayerSpeed * Time.deltaTime * Vector2.left);
    }
   


    private void MapPositionReset()
    {
        FirstLayerMover();
        SecondLayerMover();

        if (firstLayer.transform.position.x <= -32)
        {
            firstLayer.transform.position = new Vector2(0, firstLayer.transform.position.y);
        }       
        if (secondLayer.transform.position.x <= -32)
        {
            secondLayer.transform.position = new Vector2(0, secondLayer.transform.position.y);
        }
    }


    void Update()
    {
        
        MapPositionReset();
    }
}
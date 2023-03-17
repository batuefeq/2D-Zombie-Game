using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapScroller : MonoBehaviour
{
    float speed;
    float incremental;

    void Start()
    {
        speed = 0.01f;
        incremental = 0.0005f;
    }

    
    private void SpeedChanger()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        speed += incremental;
    }


    private void MapPositionReset()
    {
        if(transform.position.x <= -8)
        {
            transform.position = Vector2.zero;
        }
        
    }


    void Update()
    {
        SpeedChanger();
        MapPositionReset();
    }
}

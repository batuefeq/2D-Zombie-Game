using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 previousPosition = transform.position;
        Vector3 direction = transform.position - previousPosition;
        float angle = Vector3.Angle(transform.forward, direction);
        Vector3 axis = Vector3.Cross(transform.forward, direction);
        Quaternion rotation = Quaternion.AngleAxis(angle, axis);
        transform.rotation = rotation;
    }
}

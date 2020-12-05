using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swirly : MonoBehaviour
{
    private float _speed = 2f;


    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, _speed * Time.deltaTime, 0));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    float angle = 0;
    float speed = (2 * Mathf.PI) / 20f;
    float radius = 2.5f;

    void Update()
    {
        angle += speed * Time.deltaTime;
        Vector3 pos = new Vector3 (Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius);
        transform.localPosition = pos;
    }
}

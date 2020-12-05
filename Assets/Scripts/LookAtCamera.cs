using UnityEngine;
using System.Collections;

public class LookAtCamera : MonoBehaviour
{
    private Camera camera;

    private void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(camera.transform);
    }
}

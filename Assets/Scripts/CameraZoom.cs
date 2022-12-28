using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{

    [SerializeField] private float ScrollSpeed = 10.0f;

    private Camera cam;

    void Start()
    {
        cam=Camera.main;
    }

    //allows for zooming in and out
    void Update()
    {
        
        if (cam.orthographic)
        {
            cam.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed;
        }
        else
        {
            cam.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed;
        }
    }
}

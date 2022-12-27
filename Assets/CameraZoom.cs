using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{

    [SerializeField] private float ScrollSpeed = 10.0f;

    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam=Camera.main;
    }

    // Update is called once per frame
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

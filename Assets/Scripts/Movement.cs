using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float playerSpeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;
    Vector2 mouse;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    
        mouse=cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);
    

        //vector from player rb to mouse cursor
        Vector2 direction=mouse-rb.position;

        //angle between direction vector and x axis
        //converting radius to degrees
        //removing 90 degrees offset
        float angle = Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg-90f;
        
        //setting player sprite z rotation to calculated value
        rb.rotation = angle;
    }
}

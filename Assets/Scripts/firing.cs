using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firing : MonoBehaviour
{
    public Transform BulletPoint;
    public GameObject bulletPref;

    public float BulletSpeed = 10f;

   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }

        

    }
    //Create bullet instance and give it speed in the direction the player is facing
    void Fire()
    {
        GameObject bullet = Instantiate(bulletPref,BulletPoint.position,BulletPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(BulletPoint.up * BulletSpeed, ForceMode2D.Impulse);
        SFXManager.SFXInstance.Audio.PlayOneShot(SFXManager.SFXInstance.Shot);
    }




}

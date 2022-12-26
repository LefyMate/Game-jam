using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("Block"))
        {
            Ray2D impact = new Ray2D(transform.position, transform.right);
            //RaycastHit2D collision = Physics2D.Raycast(impact.origin, impact.direction, col.relativeVelocity, CollisionMask);

            if (col.collider != null)
            {
                Vector2 bounce = Vector2.Reflect(impact.direction, col.contacts[0].normal);
                float angle = 90 - Mathf.Atan2(bounce.y, bounce.x) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(0, 0, angle);
            }
        }

        
    }
}

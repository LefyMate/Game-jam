using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;

    public int LifeTime = 5;

    public int nextScene;

    Vector3 velocity;

    private void Start()
    {
        nextScene=SceneManager.GetActiveScene().buildIndex+1;
    }

    //Creates Bullet
    private void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
        Destroy(gameObject,LifeTime);
    }

    //Updates bullets velocity each frame
    void Update()
    {
        velocity=rb.velocity;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Player gets hit by bullet
        if(collision.collider.CompareTag("Player"))
        {
            DestroyBullet();
            LevelManager.instance.GameOver();
            collision.collider.gameObject.SetActive(false);
        }
        //Crystal gets hit by a bullet
        if (collision.collider.CompareTag("Finish"))
        {
            DestroyBullet();
            LevelManager.instance.GameWin();
            //Sets level as complete and unlocks new level in level selection
            if (nextScene > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextScene);
            }
        }

        //Bullet ricochet from walls
        var speed = velocity.magnitude;
        var direction = Vector3.Reflect(velocity.normalized, collision.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(speed, 0f);
    }


    //Destroying bullet
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}

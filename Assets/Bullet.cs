using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    /*
    public float speed = 10f;

    [SerializeField] private LayerMask CollisionMask;

    [SerializeField] private int layer = 8;
    //private int layerAsLayerMask;

    private void Start()
    {
        CollisionMask |= (1 << layer);
    }
    */
    //public Transform Player;

    private Rigidbody2D rb;

    public int LifeTime = 5;

    public int nextScene;

    Vector3 velocity;

    private void Start()
    {
        nextScene=SceneManager.GetActiveScene().buildIndex+1;
    }


    private void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
        Destroy(gameObject,LifeTime);
    }


    void Update()
    {

        velocity=rb.velocity;

        /*
        transform.position +=transform.up*speed*Time.deltaTime;

        Ray2D impact = new Ray2D(transform.position,transform.up);
        RaycastHit2D collision = Physics2D.Raycast(impact.origin, impact.direction,Time.deltaTime*speed+0.2f,CollisionMask);
        if (collision.collider!=null)
        {
            Debug.DrawLine(impact.origin,collision.point,Color.blue);
            Vector2 bounce = Vector2.Reflect(impact.direction,collision.normal);
            float angle = 90-Mathf.Atan2(bounce.x, bounce.y) * Mathf.Rad2Deg;
            Debug.DrawRay(collision.point,bounce,Color.red);
            transform.eulerAngles = new Vector3(0, 0, angle);
        }
        */

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.collider.CompareTag("Player"))
        {
            Debug.Log("Player hit!");
            DestroyBullet();
            LevelManager.instance.GameOver();
            collision.collider.gameObject.SetActive(false);
        }
        if (collision.collider.CompareTag("Finish"))
        {
            Debug.Log("Level Complete!");
            DestroyBullet();
            LevelManager.instance.GameWin();
            Time.timeScale = 0f;
            //Player.gameObject.SetActive(false);
            if (nextScene > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextScene);
            }
        }


        var speed = velocity.magnitude;
        var direction = Vector3.Reflect(velocity.normalized, collision.contacts[0].normal);

        rb.velocity = direction * Mathf.Max(speed, 0f);
    }



    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}

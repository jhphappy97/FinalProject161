using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minion : MonoBehaviour
{
    public Rigidbody2D player;
    public Rigidbody2D enemy;
    //public GameObject fireBalls;
    private bool gotHit = false;
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float timeBetweenFireLimit = 3f;
    private float timerForFire, timerForHit;
    private bool right = false;
    private bool canFire = true;
    private Animator anim;
    private bool head = false;
    private bool choose = true;
    private float jumpTime = 0f;
    public bool isfly_enemy;
    [SerializeField] private float jumpForce = 20f;

    public float timeBetweenHitLimit = 0.05f;
    public float knockback_speed = 5f;
    public GameObject potion;
    public GameObject time_plus;
    public GameObject clockposition;
    public AudioSource particle_sound;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        particle_sound = GameObject.Find("snowsound").GetComponent<AudioSource>();
        time_plus = GameObject.Find("add_time");
        clockposition=GameObject.Find("clock");
    }

    // Update is called once per frame
    void Update()
    {
        move();
        
    }
    
    void move()
    {
        enemy.velocity = new Vector2(speed, enemy.velocity.y);
        if(isfly_enemy){
          if(transform.position.x> 20){
           enemy.velocity = new Vector2(speed*=-1, enemy.velocity.y);
          }
          if(transform.position.x< -15){
           enemy.velocity = new Vector2(speed*=-1, enemy.velocity.y);
          }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
            speed = 0;
        if (collision.collider.CompareTag("bullet"))
        {
            player.GetComponent<Player>().incTimer();
            Destroy(this.gameObject);
            particle_sound.Play();
            GameObject b= Instantiate(potion, transform.position, transform.rotation);
            GameObject a = Instantiate(time_plus, transform.position, transform.rotation);
            Destroy(b,2f);
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
            speed = 2f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ground"))
        {
            speed *= -1;
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
    }
    

}

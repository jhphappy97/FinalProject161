using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster2 : MonoBehaviour
{
    public Rigidbody2D player;
    public Rigidbody2D enemy;
    //public GameObject fireBalls;
    private bool gotHit = false;
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float timeBetweenHitLimit = 1f, timeBetweenFireLimit = 3f;
    private float timerForFire, timerForHit;
    private bool right = false;
    private bool canFire = true;
    
    public float back=5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!canFire)
        {
            timerForFire += Time.deltaTime;
            if (timerForFire >= timeBetweenFireLimit)
                canFire = true;
        }
        if(gotHit)
        {
            timerForHit += Time.deltaTime;
            if (timerForHit >= timeBetweenHitLimit)
                gotHit = false;
        }
        if (!gotHit)
        {
            float horizontal_translation = enemy.velocity.x;//Input.GetAxis("Horizontal") * speed;
            if (player.position.x < enemy.position.x - 1)//player is to the left of enemy
            {
                if(right)
                {
                    right = false;
                    enemy.gameObject.GetComponent<SpriteRenderer>().transform.Rotate(new Vector3(0, 180, 0));
                }
                horizontal_translation = -1 * speed;
            }
            else if (player.position.x > enemy.position.x + 1)
            {
                if (!right)
                {
                    right = true;
                    enemy.gameObject.GetComponent<SpriteRenderer>().transform.Rotate(new Vector3(0, 180, 0));
                }
                horizontal_translation = 1 * speed;
            }
            if (enemy.position.x >= 6.5f && horizontal_translation > 0)
                horizontal_translation = 0;
            if (enemy.position.x <= -6.5f && horizontal_translation < 0)
                horizontal_translation = 0;
            if (System.Math.Abs(enemy.position.x - player.position.x) < 4f)
            {
                if (canFire)
                    fire();
                horizontal_translation = 0;
            }
            enemy.velocity = new Vector2(horizontal_translation, 0);
        }
    }

    void fire()
    {
        ////instantiate the fireball;
        //print("fire");
        //float x = enemy.position.x;
        //float y = enemy.position.y;
        //float rot = 0;
        //if (right)
        //{
        //    print("fire right");
        //    x += 2f;
        //}
        //else
        //{
        //    print("fire left");
        //    x -= 2f;
        //    rot = 180f;
        //}
        //GameObject bulletClone = (GameObject)Instantiate(fireBalls, new Vector3(x, y + 1, 0),Quaternion.Euler(0,rot,0));
        //bulletClone.transform.Translate(new Vector3(-1, -1,0));
        //bulletClone.GetComponent<FireballScript>().setRight(right);
        //canFire = false;
        //timerForFire = 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            gotHit = true;
        }
//        if (collision.collider.CompareTag("bullet"))
//        {
//            enemy.AddForce(new Vector2(12f,-2.729f),ForceMode2D.Force);
//            //enemy.velocity = new Vector2(-enemy.velocity.x-10, enemy.velocity.y);
//        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("bullet")){
        this.transform.Translate(Vector2.right*2);}
    }
}

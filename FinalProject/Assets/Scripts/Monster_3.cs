using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_3 : MonoBehaviour
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
    [SerializeField] private float jumpForce = 20f;
    public EnemyHealthBar healthBar;
    private int health = 30;
    public float timeBetweenHitLimit = 0.05f;
    public float knockback_speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (choose)
        //    chooseJumpTime();
        //if (!choose && (jumpTime -= Time.deltaTime) < 0)
            //jump();
        //if (!canFire)
        //{
        //    timerForFire += Time.deltaTime;
        //    if (timerForFire >= timeBetweenFireLimit)
        //        canFire = true;
        //}
        if (gotHit)
            hit();
        if (!gotHit)
            move();
    }

    private void jump()
    {
        print("Before: " + enemy.velocity.y);
        enemy.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        print("After: " + enemy.velocity.y);
        choose = true;
        Debug.Log("Jump");
    }

    private void chooseJumpTime()
    {
        jumpTime = UnityEngine.Random.Range(1f, 5f);
        choose = false;
        Debug.Log("JumpTime: " + jumpTime);
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

    void move()
    {
        float horizontal_translation = enemy.velocity.x;//Input.GetAxis("Horizontal") * speed;
        if (player.position.x < enemy.position.x - 1)//player is to the left of enemy
        {
            if (right)
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
        //if (enemy.position.x >= 6.5f && horizontal_translation > 0)
        //    horizontal_translation = 0;
        //if (enemy.position.x <= -6.5f && horizontal_translation < 0)
        //    horizontal_translation = 0;
        if (System.Math.Abs(enemy.position.x - player.position.x) < 4f)
        {
            if (canFire)
                fire();
        }
        enemy.velocity = new Vector2(horizontal_translation, enemy.velocity.y);
    }

    void hit()
    {
        float multiplier = 1;
        if (head)
            multiplier = 3;

        timerForHit += Time.deltaTime;
        Debug.Log("gotHit");
        transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(this.transform.position.x + 2, this.transform.position.y), knockback_speed * multiplier * Time.deltaTime);
        if (timerForHit >= timeBetweenHitLimit)
            gotHit = false;
    }

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.otherCollider is CircleCollider2D)
    //        head = true;
    //    if (collision.collider.CompareTag("bullet"))
    //    {
    //        gotHit = true;
    //        timerForHit = 0f;
    //        anim.SetTrigger("enemy_getattack");
    //    }

    //}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bullet"))
        {
            healthBar.decHealth(--health);
            if (health == 0) ;//end game here
            if (other.transform.position.y > -2f)
                head = true;
            else head = false;
            gotHit = true;
            timerForHit = 0f;
            anim.SetTrigger("enemy_getattack");
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
    }
}

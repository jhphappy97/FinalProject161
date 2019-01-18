using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerV2 : MonoBehaviour
{
    private Rigidbody2D player;
    private bool can_jump = false , gotHit = false;
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float airtime = 5.0f;
    [SerializeField] private int health = 3;
    [SerializeField] private int score = 0;
    [SerializeField] private int invincibleDelay = 3;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (can_jump)
            print("True");
        else
            print("False");
        float horizontal_translation = player.velocity.x;//Input.GetAxis("Horizontal") * speed;
        if (System.Math.Abs(Input.GetAxis("Horizontal")) > 0)
            horizontal_translation = Input.GetAxis("Horizontal") * speed;
        float vertical_translation = player.velocity.y;//Input.GetAxis("Jump");
        if (Input.GetAxis("Vertical") > 0 && can_jump)
        {
            print("jump!!!");
            can_jump = false;
            player.AddForce(Vector2.up * airtime, ForceMode2D.Impulse);
        }
        player.velocity = new Vector2(horizontal_translation, player.velocity.y);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Coin"))
        {
            print("Coin");
            Destroy(collider.gameObject);
            ++score;
        }
        if (!gotHit)
        {
            if (collider.CompareTag("Enemy"))
            {
                gotHit = true;
                print("Enemy");
                Destroy(collider.gameObject);
                --health;
                Invoke("Reset", invincibleDelay);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            print("Ground");
            can_jump = true;
        }
    }
    void Reset()
    {
        gotHit = false;
    }
}

//to avoid gettign stuck on wall make a new physics material and make no friction
    //instatiate is what you use to spawn things
    /*if(other.collider.CompareTag("tag"))
     * {
     *      Instantiate(coinPrefab, where to spawn, Quaternion.identity);
     * }
     * tinyurl.com/161Day4LN
     * */
                            
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerV2 : MonoBehaviour
{
    private Rigidbody2D player;
    private bool can_jump = false;
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float airtime = 5.0f;
    [SerializeField] private int health = 3;
    [SerializeField] private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float EPSILON = 0.000000000001f;
        float horizontal_translation = player.velocity.x;//Input.GetAxis("Horizontal") * speed;
        if (System.Math.Abs(Input.GetAxis("Horizontal")) > EPSILON)
            horizontal_translation = Input.GetAxis("Horizontal") * speed;
        print(player.velocity.x);
        float vertical_translation = player.velocity.y;//Input.GetAxis("Jump");
        if (Input.GetKeyDown("up") && can_jump)
        {
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
        if (collider.CompareTag("Enemy"))
        {
            print("Enemy");
            Destroy(collider.gameObject);
            --health;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            print("Ground");
            if (collision.GetContact(0).point.y < player.transform.position.y)
            {
                can_jump = true;
            }
        }
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
                            
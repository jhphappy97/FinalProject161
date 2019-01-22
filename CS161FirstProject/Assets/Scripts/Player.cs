using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D player;
    private bool can_jump = false;
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float airtime = 5.0f;
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
        if (System.Math.Abs(Input.GetAxis("Jump")) > EPSILON && can_jump)
        {
            can_jump = false;
            player.AddForce(Vector2.up * airtime, ForceMode2D.Impulse);
        }
        player.velocity = new Vector2(horizontal_translation, player.velocity.y);

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Coin"))
        {
            Destroy(collider.gameObject);
        }      
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            if (collision.GetContact(0).point.y < player.transform.position.y)
            {
                can_jump = true;
            } 
        }
    }

}

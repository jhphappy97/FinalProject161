using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D player;
    //[SerializeField]private Rigidbody2D bullet;
    private bool gotHit = false;
    //private Text score_text;
    //private Text health_text;
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float bulletSpeed = 2.0f;
    [SerializeField] private int health = 3;
    [SerializeField] private int score = 0;
    [SerializeField] private int invincibleDelay = 3;
    //public GameObject scoreGameObject;
    //public GameObject healthGameObject;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        //score_text = scoreGameObject.GetComponent<Text>();
        //health_text = healthGameObject.GetComponent<Text>();
        //health_text.text = "Lives: III";
    }

    // Update is called once per frame
    void Update()
    { 
        Move();
    }

    void Move()
    {
        float movementModifier = Input.GetAxis("Horizontal");
        Vector2 currentVelocity = player.velocity;
        if (player.position.x >= 8.25 && movementModifier > 0)
            movementModifier = 0;
        if (player.position.x <= -8.25 && movementModifier < 0)
            movementModifier = 0;
        player.velocity = new Vector2(movementModifier * speed, currentVelocity.y);
    }
}

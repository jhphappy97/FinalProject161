using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{

    private Rigidbody2D player;
    //[SerializeField]private Rigidbody2D bullet;
    [SerializeField]private Text score_text;
    //[]private Text health_text;
    [SerializeField] private float speed = 5f;
    [SerializeField] private int health = 3;
    [SerializeField] private int score = 0;
    //[SerializeField] private int invincibleDelay = 3;
    [SerializeField] private RawImage life1;
    [SerializeField] private RawImage life2;
    [SerializeField] private RawImage life3;
    [SerializeField] private AudioSource audio;
    //public GameObject scoreGameObject;
    //public GameObject healthGameObject;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        updateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal_translation = player.velocity.x;//Input.GetAxis("Horizontal") * speed;
        if (System.Math.Abs(Input.GetAxis("Horizontal")) > 0)
            horizontal_translation = Input.GetAxis("Horizontal") * speed;
        if (player.position.x >= 8.25 && horizontal_translation > 0)
            horizontal_translation = 0;
        if (player.position.x <= -8.25 && horizontal_translation < 0)
            horizontal_translation = 0;
        player.velocity = new Vector2(horizontal_translation, player.velocity.y);
    }


    public void updateScore(int i){ score_text.text = "Score: " + (score += i).ToString();}

    public void decHealth()
    {
        --health;
        if (health == 2)
            life1.enabled = false;
        if (health == 1)
            life2.enabled = false;
        if (health == 0)
            life3.enabled = false;
        if(health==-1)
            SceneManager.LoadScene("GameOver");
        

    }

    public void playFireAudio(){ audio.Play(); }

    

    //void Move()
    //{
    //    float movementModifier = Input.GetAxis("Horizontal");
    //    Vector2 currentVelocity = player.velocity;
    //    if (player.position.x >= 8.25 && movementModifier > 0)
    //        movementModifier = 0;
    //    if (player.position.x <= -8.25 && movementModifier < 0)
    //        movementModifier = 0;
    //    player.velocity = new Vector2(movementModifier * speed, currentVelocity.y);
    //}


}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Transform fp;
    private bool facingright = true;
    private SpriteRenderer m_spriteRenderer;
    private Rigidbody2D m_rigidbody;
    private Collider2D m_collider;
    private bool isGrounded = false;
    private Animator anim;
    private Transform dialog;
    [SerializeField] protected float speed = 5;
    [SerializeField] protected float jumpforce = 7.5f;
    public bool shootstatus = false;
    public Image life;
    public GameObject bullet;
    [SerializeField] protected float bulletspeed = 0.1f;
    [SerializeField] protected float playerforce = 500f;
    [SerializeField] public float angle_var = 1;
    private int healthbar;
    private Vector2 HealthBarSize;
    private bool notHit= true;
    private float hitTimer = 3f;
    private gather_snow snowUI;
    public AudioSource fire;
    public AudioSource hurt;
    public Text timerText;
    private int timer;
    private float second = 1f;
    
    public GameObject []healparticles;

    // Start is called before the first frame update
    private void Awake()
    {
        healthbar = 4;
        timer = 99;
        setTime();
        HealthBarSize = life.rectTransform.sizeDelta;
        m_spriteRenderer = this.GetComponent<SpriteRenderer>();
        anim = this.GetComponent<Animator>();
        snowUI = this.GetComponent<gather_snow>();
    }

    private void setTime()
    {
        timerText.text = timer.ToString();
    }

    void Start()
    {
        dialog = this.gameObject.transform.GetChild(1);
        m_rigidbody = this.GetComponent<Rigidbody2D>();
        m_collider = this.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        checkTime();
        gotHit();
        Move();
        Jump();
        getbullet();
        shoot();
        checkGameOver();
    }

    private void checkTime()
    {
        if((second -= Time.deltaTime) <= 0f)
        {
            second = 1f;
            --timer;
            setTime();
        }
    }

    private void checkGameOver()
    {
        if (this.transform.position.y < -20.0f || timer <= 0f)
            gameover();
    }

    private void gotHit()
    {
        if (!notHit)
        {
            Debug.Log("unblink");
            unBlink();
        }
        if (!notHit && (hitTimer -= Time.deltaTime) < 0)
        {
            notHit = true;
            hitTimer = 3f;
        }
        else if (hitTimer < 2.99999999f)
        {
            Debug.Log("blink");
            blink();
        }
    }

    private void unBlink()
    {
        m_spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
    }

    private void blink()
    {
        m_spriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);
    }

    //    void disable_anim(){
    //        anim.SetBool("shoot",false);
    //    }
    void shoot()
    {
        if (snowUI.current_snow < 0 && Input.GetKey(KeyCode.Space)) dialog.gameObject.SetActive(true);//this is to tell user they need more snow
        if (snowUI.current_snow > 0)// && snowUI.hitsnowile == false)
        {
            dialog.gameObject.SetActive(false);//turn off hint about snow
            if (Input.GetKey(KeyCode.Space)) angle_var = angle_var + Time.deltaTime;
            if (Input.GetKeyUp(KeyCode.Space))
            {
                fire.Play();
                Vector3 pos = fp.GetComponent<Transform>().position;
                pos.x += 0.5f;
                GameObject b = Instantiate(bullet, pos, Quaternion.identity);
                b.GetComponent<bulletbehavior>().fired(facingright, angle_var, playerforce);
                snowUI.Total_snow_can_store[snowUI.current_snow - 1].SetActive(false);
                snowUI.decSnow();
                anim.SetTrigger("attack");
                angle_var = 1;
            }
        }
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        { 
            //isGrounded =  false;
            Vector2 feetPosition = new Vector2(this.transform.position.x, m_collider.bounds.min.y);
            RaycastHit2D hitInfo = Physics2D.Raycast(feetPosition, Vector2.down, 0.1f);
            if (hitInfo)
            {
                Debug.Log("hit something");
                anim.SetBool("jump", true);
                m_rigidbody.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            } 
        }
    }
    void gameover()
    { 
        SceneManager.LoadScene("Gameoverscene");
    }
    void Move()
    {
        float movemnetModifier = Input.GetAxis("Horizontal");
        if(movemnetModifier == 0)
        {
            anim.SetBool("walk",false);
        }
        if(movemnetModifier > 0)
        {
           // m_spriteRenderer.flipX = false;
            anim.SetBool("walk",true);
        }
        else if(movemnetModifier < 0)
        {
            //m_spriteRenderer.flipX = true;
            anim.SetBool("walk",true);
        }
        Vector2 currentVelocity = m_rigidbody.velocity;
        m_rigidbody.velocity = new Vector2(movemnetModifier * speed, currentVelocity.y);
        if (movemnetModifier > 0 && !facingright || movemnetModifier < 0 && facingright)
        {
            Flip();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("potion"))
        {
            life.rectTransform.sizeDelta = new Vector2(HealthBarSize.x * (0.25f * ++healthbar), HealthBarSize.y);
            Vector3 pos = life.rectTransform.position;
            pos.x += (pos.x * 0.25f / 1.5f);
            life.rectTransform.position = pos;
            //todo heal sound
            GameObject p = Instantiate(healparticles[0], this.transform.position, Quaternion.identity);
            GameObject p2 = Instantiate(healparticles[1], this.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(p,1f);
            Destroy(p2,1f);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("ground"))
        {
            Vector2 feetPosition = new Vector2(this.transform.position.x, m_collider.bounds.min.y-0.1f);
            RaycastHit2D hitInfo = Physics2D.Raycast(feetPosition, Vector2.down, 0.1f);
            if(hitInfo && hitInfo.collider.CompareTag("ground"))
            {
                isGrounded = true;
                anim.SetBool("jump",false);
            }
        }
        //if(collision.collider.CompareTag("Snowpile"))
       // {
          //  Debug.Log(hitsnowile);
          //  hitsnowile = true;
      //  }
        if(collision.collider.CompareTag("monster") && notHit)
        {
            Debug.Log("Lose Life!!!!");
            hurt.Play();
            life.rectTransform.sizeDelta = new Vector2(HealthBarSize.x * (0.25f * --healthbar), HealthBarSize.y);
            Vector3 pos = life.rectTransform.position;
            pos.x -= (pos.x * 0.25f/1.5f);
            life.rectTransform.position = pos;
            if (healthbar == 0)
                wonGame();
            notHit = false;

        }
        //if (collision.collider.CompareTag("monster"))
        //{
        //    m_rigidbody.mass = 0;
        //}
    }

    private void wonGame()
    {
        SceneManager.LoadScene("WinScene");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("ground"))
        {
            isGrounded = false;
        }
        //if (collision.collider.CompareTag("monster"))
        //{
        //    m_rigidbody.mass = 1;
        //}
        //if (collision.collider.CompareTag("Snowpile"))
        //{
          //  Debug.Log(hitsnowile);
         //   hitsnowile = false;
       // }
    }
    private void getbullet()
    {
        
        if (Input.GetKeyDown(KeyCode.F) && snowUI.hitsnowile == true)
        {
            
            anim.SetTrigger("grab");
            shootstatus = true; //to see if gathered snow once;
        }
        if (Input.GetKeyUp(KeyCode.F)){
            shootstatus = false;
        }
    }
    private void Flip()
    {
        facingright = !facingright;
        transform.Rotate(0f, 180f, 0f);
    }
    public void incTimer()
    {
        timer += 5;
        setTime();
    }



}

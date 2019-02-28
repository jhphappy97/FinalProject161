using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private bool hitsnowile = false;
    private bool shootstatus = false;
    public GameObject bullet;
    [SerializeField] protected float bulletspeed = 0.1f;
    [SerializeField] protected float playerforce = 500f;
    [SerializeField] protected float angle_var = 1;
    
    public gather_snow snowUI;
    // Start is called before the first frame update
    private void Awake()
    {
        m_spriteRenderer = this.GetComponent<SpriteRenderer>();
        anim = this.GetComponent<Animator>();
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
        Move();
        if (Input.GetKeyDown(KeyCode.Space)&&  isGrounded)
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.F) && hitsnowile == true)
        {
            getbullet();
           
        }
         if(snowUI.current_snow<0 && Input.GetKey(KeyCode.K)){
           dialog.gameObject.SetActive(true);
           }
        if(snowUI.current_snow>=0){
            dialog.gameObject.SetActive(false);
            if (Input.GetKey(KeyCode.K))
            {
                angle_var = angle_var + Time.deltaTime;
                Debug.Log(angle_var);


            }
            if (Input.GetKeyUp(KeyCode.K))
            {
                shoot();
                
                snowUI.Total_snow_can_store[snowUI.current_snow].SetActive(false);
                snowUI.current_snow-=1;
                snowUI.current_snow = Mathf.Max(snowUI.current_snow,-1);
                
                anim.SetBool("shoot",true);
                angle_var = 1;
                Invoke("disable_anim",0.2f);
            }
            
        }
    }
    void disable_anim(){
        anim.SetBool("shoot",false);
    }
    void shoot()
    {
        Debug.Log("shoot");
        GameObject b = Instantiate(bullet, fp.GetComponent<Transform>().position, Quaternion.identity);
        Rigidbody2D bulletbody = b.GetComponent<Rigidbody2D>();
        Vector3 dir = new Vector3(1,1*angle_var);
        bulletbody.AddForce(dir * playerforce);

        }
    void Jump()
    {
        isGrounded =  false;
        anim.SetBool("jump",true);
        m_rigidbody.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
    }

    void Move()
    {
        float movemnetModifier = Input.GetAxis("Horizontal");
        if(movemnetModifier == 0){
            anim.SetBool("walk",false);
        }
        if(movemnetModifier > 0)
        {
           // m_spriteRenderer.flipX = false;
            anim.SetBool("walk",true);
        }
        else if(movemnetModifier < 0)
        {
            //\\m_spriteRenderer.flipX = true;
            anim.SetBool("walk",true);
        }
        Vector2 currentVelocity = m_rigidbody.velocity;
        m_rigidbody.velocity = new Vector2(movemnetModifier * speed, currentVelocity.y);
        if (movemnetModifier > 0 && !facingright || movemnetModifier < 0 && facingright)
        {
            Flip();
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
        if(collision.collider.CompareTag("Snowpile"))
        {
            hitsnowile = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("ground"))
        {
            isGrounded = false;
        }
    }
    private void getbullet()
    {
        shootstatus = true;
    }
    private void Flip()
    {
        facingright = !facingright;
        transform.Rotate(0f, 180f, 0f);
    }

}

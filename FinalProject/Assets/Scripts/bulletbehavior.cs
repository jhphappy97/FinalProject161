using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletbehavior : MonoBehaviour
{
    
    public GameObject particlePrefab;
    public GameObject[] trailPrefab;
    private int index = 0;
    public AudioSource particle_sound;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Trail",0.1f,0.1f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    //private void OnTriggerExit(Collider collision)
    //{

    //  if (collision.CompareTag("monster"))
    //{
    //  print(collision.tag);
    //Debug.Log("destroy");
    //Destroy(this.gameObject);
    //}
    //}
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("ground"))
    //    {
    //        Debug.Log("destroyG");
    //        Destroy(this.gameObject);
    //    }
    //    if (other.CompareTag("monster"))
    //    {
    //        print(other.tag);
    //        Debug.Log("destroy");
    //        Destroy(this.gameObject);
    //    }
    //}

    public void fired(bool right, float angle_var, float playerforce)
    {
        Rigidbody2D bulletbody = this.GetComponent<Rigidbody2D>();
        Vector3 dir = new Vector3(1, 1 * angle_var);
        if (!right)
        {
            Debug.Log("LEFT");
            dir.x *= -1;
            this.GetComponent<SpriteRenderer>().transform.Rotate(0, 180, 0);
        }

        bulletbody.AddForce(dir * playerforce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        print("collision");
        if (collision.collider.CompareTag("ground"))
        {
            Debug.Log("destroyG");
            Destroy(this.gameObject);
        }
        if (collision.collider.CompareTag("monster"))
        {
            GameObject a = Instantiate(particlePrefab,transform.position,Quaternion.identity);
            Debug.Log("destroy");
            particle_sound.Play();
            Destroy(this.gameObject);
            Destroy(a,2f);
        }

    }
    
    public void Trail(){
        if(GetComponent<Rigidbody2D>().velocity.sqrMagnitude>25){
        
    
        Instantiate(trailPrefab[index],transform.position,Quaternion.identity);
        index=(index+1)%trailPrefab.Length;
        }
        
    }
}
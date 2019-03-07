using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletbehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float y = GameObject.FindGameObjectWithTag("Player").transform.rotation.y;
        Debug.Log("Players Y rotation: " + GameObject.FindGameObjectWithTag("Player").transform.rotation.y);
        if (y == -1)
        {
            Debug.Log("Switch");
            y = 180;
            Rigidbody2D temp = this.GetComponent<Rigidbody2D>();
            Vector3 vel = temp.velocity;
            vel.y *= -1;

            temp.velocity = vel;
        }
        this.transform.Rotate(new Vector3(this.transform.rotation.x, y, this.transform.rotation.z));
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ground"))
        {
            Debug.Log("destroyG");
            Destroy(this.gameObject);
        }
        if (other.CompareTag("monster"))
        {
            print(other.tag);
            Debug.Log("destroy");
            Destroy(this.gameObject);
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    print("collision");
    //    if (collision.collider.CompareTag("ground"))
    //    {
    //        Debug.Log("destroyG");
    //        Destroy(this.gameObject);
    //    }
    //    if (collision.collider.CompareTag("monster"))
    //    {

    //        Debug.Log("destroy");
    //        Destroy(this.gameObject);
    //    }

    //}
}
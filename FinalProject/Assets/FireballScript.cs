using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    public bool right, alive;
    void Start()
    {
        print("before");
        anim = this.gameObject.GetComponent<Animator>();
        print("after");
        Destroy(this.gameObject, 5f);
        alive = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //print("FixedUpdate");
        if (alive)
        {
            if (!right)
            {
                print("looking left");
                this.transform.Translate(new Vector3(0.1f, -0.1f, 0));
            }
            else
            {
                print("looking right");
                this.transform.Translate(new Vector3(0.1f, -0.1f, 0));
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        print("collided");
        if (collider.CompareTag("ground"))
        {
            alive = false;
            anim.SetBool("Hit", true);
            print("Hit Ground");
        }
        if (collider.CompareTag("Player"))
        {
            alive = false;
            anim.SetBool("Hit", true);
            print("Hit Player");
        }
    }
    public void setRight(bool r)
    {
        right = r; 
    }

}
//130 degrees for fireballs
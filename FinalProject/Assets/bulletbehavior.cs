using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletbehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("monster"))
        {
            print(collision.collider.tag);
            Debug.Log("destroy");
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ground"))
        {
            Debug.Log("destroyG");
            Destroy(this.gameObject);
        }
    }
}

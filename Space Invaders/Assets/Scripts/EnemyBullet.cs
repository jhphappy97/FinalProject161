using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float speed = 5f;
    private Player playerScriptAccess;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 3f);
        playerScriptAccess = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //print("move Bullet");
        //Debug.Log(this.transform.position.y);
        //Debug.Log(speed * Time.deltaTime);
        this.transform.Translate(Vector3.left * speed * Time.deltaTime);
        //Debug.Log(this.transform.position.y);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            playerScriptAccess.decHealth();
        }
    }
}
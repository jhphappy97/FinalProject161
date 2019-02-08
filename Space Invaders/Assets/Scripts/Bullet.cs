using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D bullet;
    private Player playerScriptAccess;
    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Rigidbody2D>();
        Destroy(bullet.gameObject, 1f);
        playerScriptAccess = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            print("Enemy");
            Destroy(collider.gameObject);
            Destroy(bullet.gameObject);
            playerScriptAccess.updateScore(1);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        print("move Bullet");
        this.transform.Translate(new Vector3(this.transform.position.x, this.transform.position.y + speed * Time.deltaTime));
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            print("Player");
            Destroy(this.gameObject);
        }
    }
}
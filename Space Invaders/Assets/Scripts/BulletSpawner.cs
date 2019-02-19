using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public Rigidbody2D bullet;
    [SerializeField] private float speed = 10f;
    private bool ableToFire = false;
    public GameObject player;
    private Rigidbody2D bulletClone;

    // Start is called before the first frame update
    void Start()
    {
        bulletClone = null;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (bulletClone == null)//bullet is destroyed
            ableToFire = true;
        if (Input.GetKeyDown("space") && ableToFire)
            fireBullet();
    }

    void fireBullet()
    {
        if (ableToFire)
        {
            ableToFire = false;
            // print("FiredBullet");
            player.GetComponent<Player>().playFireAudio();
            bulletClone = Instantiate(bullet, new Vector3(player.GetComponent<Rigidbody2D>().transform.position.x, player.GetComponent<Rigidbody2D>().transform.position.y + 0.8f, 0), Quaternion.Euler(0, 0, 90f));
            bulletClone.velocity = new Vector2(0, speed);
            //Destroy(bulletClone, 1f);
        }
    }
}


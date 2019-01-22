using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public Rigidbody2D bullet;
    [SerializeField]private float speed = 10f;
    [SerializeField]private int bulletLimit = 3;
    [SerializeField]private int timeBetweenShotLimit = 3;
    private bool ableToFire = true;
    private int bulletCount = 0;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (bulletCount >= 3 && ableToFire)
            StartCoroutine(Reset());
        else if (Input.GetKeyDown("space") && bulletCount < bulletLimit)
        {
            print(bulletCount);
            print("Fire");
            fireBullet();
        }
    }

    void fireBullet()
    {
        if (ableToFire)
        {
            print("FiredBullet");
            ++bulletCount;
            Rigidbody2D bulletClone = (Rigidbody2D)Instantiate(bullet, new Vector3(player.GetComponent<Rigidbody2D>().transform.position.x + 0.8f, player.GetComponent<Rigidbody2D>().transform.position.y, 0), Quaternion.identity);
            bulletClone.velocity = new Vector2(speed, 0);
            Destroy(bulletClone, 10f);
        }
    }
    IEnumerator Reset()
    {
        ableToFire = false;
        yield return new WaitForSeconds(timeBetweenShotLimit);
        print("Reset");
        bulletCount = 0;
        ableToFire = true;
    }
}

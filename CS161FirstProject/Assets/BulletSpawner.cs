using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public Rigidbody2D bullet;
    [SerializeField]private float speed = 10f;
    [SerializeField]private int bulletLimit = 3;
    [SerializeField]private int timeBetweenShotLimit = 3;
    private int bulletCount = 0;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (bulletCount == 3)
            StartCoroutine(Reset());
        if (Input.GetKeyDown("space") && bulletCount < bulletLimit)
        {
            print("Fire");
            fireBullet();
        }
    }

    void fireBullet()
    {
            print("FiredBullet");
            ++bulletCount;
            Rigidbody2D bulletClone = (Rigidbody2D)Instantiate(bullet, player.GetComponent<Rigidbody2D>().transform.position, Quaternion.identity);
            bulletClone.velocity = new Vector2(speed, 0);
            Destroy(bulletClone, 10f);
    }
    IEnumerator Reset()
    {
        yield return new WaitForSeconds(timeBetweenShotLimit);
        bulletCount = 0;
    }
}

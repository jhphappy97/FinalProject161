using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enenmy : MonoBehaviour
{
    public bool enemy_wallcollide = false;
    public GameObject enemyBullet;
    public float speed = 2;
    public bool left = true;
    GameObject bulletClone;
    // Start is called before the first frame update
    void Start()
    {
        enemyBullet.GetComponent<GameObject>();
        bulletClone = null;
    }

    void Update()
    {
        if (left)
            this.transform.Translate(Vector3.left * speed * Time.deltaTime);
        else
            this.transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            enemy_wallcollide = true;
            //enemy_wallcollide = !enemy_wallcollide;
            //this.transform.Translate(0.0f, -1.0f, 0.0f);

        }
    }

    public void moveDown()
    {
        this.transform.Translate(0.0f, -1.0f, 0.0f);
    }

    public void fireBullet()
    {
        bulletClone = Instantiate(enemyBullet, new Vector3(this.transform.position.x, this.transform.position.y - 0.8f), Quaternion.Euler(0, 0, 90f));
    }

    private void OnTriggerEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

}

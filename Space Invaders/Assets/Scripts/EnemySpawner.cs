using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public int width,height;
    public GameObject enemy1;
    public float speed = 2;
    private Rigidbody2D m_rigidbody;
    private bool enemy_wallcollide = false;

    // Start is called before the first frame update
    void Start()
    {
        spawnObjects();
    }

    // Update is called once per frame

    void spawnObjects()
{
    for(int x=0;x<width;x++)
    {
        for(int y=0;y<height;y++)
        {
                Vector3 Spawnposition = new Vector3(x, y, 0);
                GameObject newEnemy = Instantiate(enemy1, this.transform);
                newEnemy.transform.localPosition = Spawnposition+ new Vector3(1,1,0);
            }
        }
}

    void go_right()
    {
        this.transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    void go_left()
    {
        this.transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
    void Update()
    {
        if(enemy_wallcollide)
        {
            go_right();
        }
        else
        {
            go_left();
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if(other.collider.CompareTag("Wall"))
        {
            enemy_wallcollide = !enemy_wallcollide;
        }
    }
}

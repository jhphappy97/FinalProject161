using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enenmy : MonoBehaviour
{
    private bool enemy_wallcollide = false;
    public float speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        
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
        if (enemy_wallcollide)
        {
            go_right();
        }
        else
        {
            go_left();
        }
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("entering wall");
        if (other.CompareTag("Wall"))
        {
            Debug.Log("2");
            enemy_wallcollide = !enemy_wallcollide;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag("Player"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

        }
    }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    private const float V = 0.3f;
    public int width,height;
    public GameObject enemy1;
    public float speed = 2;
    private enenmy enenmy_access;
    private Rigidbody2D m_rigidbody;
    public GameObject Enemy_script;
    // Start is called before the first frame update
     void Awake()
    {
        spawnObjects();
        enenmy_access = Enemy_script.GetComponent<enenmy>();

    }
    void Start()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame

    void spawnObjects()
    {
        for (int x = 0; x < width; x++)
        {


            for (int y = 0; y < height; y++)
            {
                Vector3 Spawnposition = new Vector3(x + V * x, y, 0);
                GameObject newEnemy = Instantiate(enemy1, this.transform);
                newEnemy.transform.localPosition = Spawnposition;
            }

        }
    }
    
    void go_right()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i=0;i<obj.Length;i++)
        {
            obj[i].transform.Translate(Vector3.right * speed * Time.deltaTime);

        }
    }
    void go_left()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < obj.Length; i++)
        {
            obj[i].transform.Translate(Vector3.left * speed * Time.deltaTime);

        }
    }
   
    void Update()
    {
        if (enenmy_access.enemy_wallcollide)
        {
            go_right();
        }
        else
        {
            go_left();
        }
    }





}

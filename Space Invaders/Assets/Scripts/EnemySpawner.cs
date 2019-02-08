using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    private const float V = 0.3f;
    public int width,height;
    public GameObject enemy1;
    public float speed = 2;
    private enenmy enenmy_access;
    private Rigidbody2D m_rigidbody;
    public GameObject Enemy_script;
    public GameObject[,] enemies;
    [SerializeField] private float maxTime = 30f;
    [SerializeField] private float minTime = 20f;
    private float currentTime;
    private float fireTime;

    // Start is called before the first frame update
    void Start()
    {
        enemies = new GameObject[width, height];
        spawnObjects();
        setFireTime();
        currentTime = minTime;
    }

    // Update is called once per frame

    void spawnObjects()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 Spawnposition = new Vector3(x + V * x, y, 0);
                enemies[x,y]= Instantiate(enemy1, this.transform);
                enemies[x,y].transform.localPosition = Spawnposition;
            }

        }
    }
   
    void FixedUpdate()
    {
        if (!enemiesLeft())
            levelFinished();//not implemented yet
        currentTime += Time.deltaTime;
        if (currentTime >= fireTime)
        {
            shoot();
            setFireTime();
        }
        bool found = false;
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (enemies[x, y] != null)
                {
                    enenmy enemy = enemies[x, y].GetComponent<enenmy>();
                    if (enemy.enemy_wallcollide)//has hit wall
                    {
                        found = true;
                        //are they mmoving left or right???
                        if (enemy.left)//then hit left wall
                            hitLeftWall();
                        else//then hit right wall
                            hitRightWall();
                        break;
                    }
                }
                if (found)
                    break;
            }
        }
    }

    private void levelFinished()
    {
        throw new NotImplementedException();
    }

    void hitRightWall()
    {
        enenmy enemy = null;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (enemies[i, j] != null)
                {
                    enemy = enemies[i, j].GetComponent<enenmy>();
                    enemy.left = !enemy.left;
                    enemy.enemy_wallcollide = false;
                    enemy.moveDown();
                }
            }
        }
    }

    void hitLeftWall()
    {
        enenmy enemy = null;
        for (int i = width - 1; i > -1; --i)
        {
            for (int j = height - 1; j > -1; --j)
            {
                if (enemies[i, j] != null)
                {
                    enemy = enemies[i, j].GetComponent<enenmy>();
                    enemy.left = !enemy.left;
                    enemy.enemy_wallcollide = false;
                    enemy.moveDown();
                }
            }
        }
    }

    void shoot()
    {
        int col = Random.Range(0, width);
        int row = -1;
        while (true)//gauranteed to have at least one alive
        { 
            for(int y = 0; y < height; ++y)
            { 
                if(enemies[col, y] != null)
                {
                    row = y;
                    break;
                }
            }
            if (row == -1)//if no enemy found in that row
                col = Random.Range(0, width);//then pick new col
            else
                break;
        }
        enemies[col, row].GetComponent<enenmy>().fireBullet();
    }

    void setFireTime()
    {
        fireTime = Random.Range(minTime, maxTime);
    }

    bool enemiesLeft()
    {
        for (int x = 0; x < width; ++x)
        { 
            for(int y = 0; y < height; ++y)
            {
                if (enemies[x, y] != null)
                    return true;
            }
        }
        return false;
    }
}

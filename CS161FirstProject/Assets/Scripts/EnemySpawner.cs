using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Rigidbody2D enemy;
    private Rigidbody2D enemyClone;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float maxTime = 30f;
    [SerializeField] private float minTime = 20f;
    private float currentTime;
    private float spawnTime;
    // Start is called before the first frame update
    void Start()
    {
        setSpawnTime();
        currentTime = minTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= spawnTime)
        {
            spawnEnemy();
            setSpawnTime();
        }
    }

    void spawnEnemy()
    {
        currentTime = minTime;
        Vector3 position = new Vector3(10, Random.Range(-3.5f, 2.0f), 0);
        enemyClone = (Rigidbody2D)Instantiate(enemy, position, Quaternion.identity);
        enemyClone.velocity = new Vector2(-speed,0);
        Destroy(enemyClone.gameObject, 10f);
    }

    void setSpawnTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }
}

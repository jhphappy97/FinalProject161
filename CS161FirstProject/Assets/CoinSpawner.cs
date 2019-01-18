using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public  GameObject coin;
    [SerializeField] private float maxTime = 30f;
    [SerializeField] private float minTime = 20f;
    [SerializeField] private float destroyDelay = 5.0f;
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
            spawnCoin();
            setSpawnTime();
        }
    }

    void spawnCoin()
    {
        currentTime = minTime;
        Vector3 position = new Vector3(Random.Range(-8.4f, 8.4f), Random.Range(-3.5f, 2.0f), 0);
        GameObject coinClone = (GameObject)Instantiate(coin, position, Quaternion.identity);
        GameObject.Destroy(coinClone, destroyDelay);
    }

    void setSpawnTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }
}

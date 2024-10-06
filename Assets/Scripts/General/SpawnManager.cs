using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab; 
    [SerializeField] private float spawnInterval = 2.0f;
    [SerializeField] private float minLifetime = 3.0f;
    [SerializeField] private float maxLifetime = 7.0f;
    [SerializeField] private float spawnXRange = 2.0f;
    [SerializeField] private float spawnYRange = 2.0f;

    private void Start()
    {
        InvokeRepeating("SpawnObstacle", spawnInterval, spawnInterval);
    }
    void SpawnObstacle()
    {

        Vector2 randomPosition = new Vector2(Random.Range(-spawnXRange, spawnXRange), Random.Range(-spawnYRange, spawnYRange));
        GameObject newObstacle = Instantiate(obstaclePrefab, randomPosition, Quaternion.identity);
        float lifetime = Random.Range(minLifetime, maxLifetime);
        Destroy(newObstacle, lifetime);
    }


}

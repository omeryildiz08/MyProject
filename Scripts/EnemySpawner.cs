using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public float spawnRadius = 5f;
    public float spawnInterval = 3f;
    

    private void Start()
    {
       
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
        InvokeRepeating("DecreaseSpawnInterval", 40f, 40f);
    }

    void SpawnEnemy()
    {
        Vector2 spawnPoint = Random.insideUnitCircle * spawnRadius;
        spawnPoint += (Vector2)transform.position;
        Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
    }


    void DecreaseSpawnInterval()
    {
        spawnInterval -= 0.5f;
    }

}

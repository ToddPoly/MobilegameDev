using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject[] enemyTypes;

    [SerializeField] private float spawnTime;
    [SerializeField] private float NextSpawnTime;

    public float wavePoints = 50;

    private void FixedUpdate()
    {
        if (Time.time > NextSpawnTime && wavePoints > 0)
        {
            SelectEnemy();

            NextSpawnTime = Time.time + spawnTime;
        }        
    }

    private void SelectEnemy()
    {
        Enemy enemy;
        bool canSpawn = false;
        do
        {
            enemy = enemyTypes[Random.Range(0, enemyTypes.Length)].GetComponent<Enemy>();

            if (wavePoints - enemy.pointValue >= 0)
            {
                canSpawn = true;
            }

        } while (!canSpawn);

        wavePoints = wavePoints - enemy.pointValue;
        SpawnEnemy(enemy);
    }

    private void SpawnEnemy(Enemy enemy)
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform;
        Instantiate(enemy, spawnPoint);
    }
}

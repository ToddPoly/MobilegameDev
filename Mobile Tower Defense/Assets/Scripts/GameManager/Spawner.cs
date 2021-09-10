using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject[] enemyTypes;

    [SerializeField] private float spawnTime;
    [SerializeField] private float NextSpawnTime;

    public int wavePoints;

    private void Start()
    {
       wavePoints = 0;
    }

    private void OnValidate()//checks if wavpoint value is a multiple of 5 so it doesnt break the spawning while loop
    {
        if (wavePoints % 5 != 0)
        {
            wavePoints = wavePoints - (wavePoints % 5);
        }
    }

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
        int loopSafety = 0;
        do
        {
            loopSafety++;
            enemy = enemyTypes[Random.Range(0, enemyTypes.Length)].GetComponent<Enemy>();

            if (wavePoints - enemy.pointValue >= 0)
            {
                break;
            }

            if (loopSafety > 100)
            {
                Debug.Log("Spawner wavepoint value is out of range");
                break;
            }
            
        } while (true);

        wavePoints = wavePoints - enemy.pointValue;
        SpawnEnemy(enemy);
    }

    private void SpawnEnemy(Enemy enemy)
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform;
        Instantiate(enemy, spawnPoint);
    }
}

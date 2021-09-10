using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private Spawner spawner;
    [SerializeField] private int waveCount;
    [SerializeField] private int curWaveCount;
    [SerializeField] private int waveMultiplier;
    [SerializeField] private float timeBetweenWaves;

    public float enemiesKilled { get; private set; }//stat shown on UI
    public float waveProgress { get; private set; }//A bar that has the total wave points and when an enemy dies it removes that enemies point value from the bar 
    public float maxWaveProgress { get; private set; }

    void Start()
    {
        curWaveCount = 0;
        StartCoroutine(WaitNewWave());
    }

    private void CreateWave()//get the curWaveCount, set the wavePoints value and set maxWaveProgress
    {
        spawner.wavePoints = (curWaveCount * waveMultiplier) * curWaveCount;//may need to adjust later
        maxWaveProgress = spawner.wavePoints;
        waveProgress = maxWaveProgress;
    }

    private void SetProgress(float pointValue)
    {
        waveProgress -= pointValue;
        if (waveProgress <= 0)
        {
            StartCoroutine(WaitNewWave());
        }
    }

    private void SetWave()//prob dont need
    {
        waveProgress = maxWaveProgress;
    }


    private void OnEnable()
    {
        Enemy.EnemyDeath += SetProgress;
    }

    private void OnDisable()
    {
        Enemy.EnemyDeath -= SetProgress;
    }

    IEnumerator WaitNewWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        if (curWaveCount != waveCount)
        {
            curWaveCount++;
            CreateWave();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public delegate void OnHealthChange(int health);
    public static event OnHealthChange OnHealthChanged;

    public GameObject gameoverScreen;
    public GameObject ui;

    public int health;

    private int score;

    private void Start()
    {
        OnHealthChanged?.Invoke(health);
    }

    public void TakeDamage()
    {
        health --;
        OnHealthChanged?.Invoke(health);

        if (health <= 0)
        {
            Debug.Log("Player died. You Lose");
            ui.SetActive(false);
            gameoverScreen.SetActive(true);
            gameoverScreen.GetComponent<Menu>().SetScore(score);
            Time.timeScale = 0;
        }
    }

    public void SetScore(int x)
    {
        score = x;
    }

    private void OnEnable()
    {
        EndZoneDetection.OnEnemyEntered += TakeDamage;
        WaveManager.OnWaveChanged += SetScore;
    }

    private void OnDisable()
    {
        EndZoneDetection.OnEnemyEntered -= TakeDamage;
        WaveManager.OnWaveChanged -= SetScore;
    }
}

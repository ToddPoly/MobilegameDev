using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public delegate void OnHealthChange(int health);
    public static event OnHealthChange OnHealthChanged;

    public int health;

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
        }
    }

    private void OnEnable()
    {
        EndZoneDetection.OnEnemyEntered += TakeDamage;
    }

    private void OnDisable()
    {
        EndZoneDetection.OnEnemyEntered -= TakeDamage;
    }
}

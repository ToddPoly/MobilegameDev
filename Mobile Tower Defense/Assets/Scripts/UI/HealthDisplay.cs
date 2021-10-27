using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    public TextMeshProUGUI healthDisplay;

    public void DisplayHealth(int health)
    {
        healthDisplay.text = "Health: " + health.ToString();
    }

    private void OnEnable()
    {
        healthDisplay = GetComponentInChildren<TextMeshProUGUI>();

        HealthManager.OnHealthChanged += DisplayHealth;
    }

    private void OnDisable()
    {
        HealthManager.OnHealthChanged -= DisplayHealth;
    }
}

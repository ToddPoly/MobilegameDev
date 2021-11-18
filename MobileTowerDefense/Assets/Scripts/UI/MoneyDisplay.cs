using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyDisplay : MonoBehaviour
{
    public TextMeshProUGUI moneyDisplay;

    private void Start()
    {
        
    }

    public void DisplayMoney(int money)
    {
        moneyDisplay.text = "Money: " + money.ToString();
    }

    private void OnEnable()
    {
        moneyDisplay = GetComponentInChildren<TextMeshProUGUI>();

        MoneyManager.OnMoneyChanged += DisplayMoney;
    }

    private void OnDisable()
    {
        MoneyManager.OnMoneyChanged -= DisplayMoney;
    }
}

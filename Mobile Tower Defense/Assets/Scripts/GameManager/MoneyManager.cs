using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public delegate void OnMoneyChange(int money);
    public static event OnMoneyChange OnMoneyChanged;

    [SerializeField] private int playerMoney;

    public void AddPlayerMoney(int addAmount)
    {
        playerMoney += addAmount;
        OnMoneyChanged?.Invoke(playerMoney);
    }

    public bool TrySpendMoney(int cost)
    {
        if (playerMoney >= cost)
        {
            playerMoney -= cost;
            OnMoneyChanged?.Invoke(playerMoney); //make ui event later
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnEnable()
    {
        MiningTower.OnMoneyAdded += AddPlayerMoney;
    }

    private void OnDisable()
    {
        MiningTower.OnMoneyAdded -= AddPlayerMoney;
    }
}

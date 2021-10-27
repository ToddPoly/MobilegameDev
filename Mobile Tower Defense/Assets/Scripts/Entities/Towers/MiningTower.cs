using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningTower : Tower
{
    public delegate void OnAddMoney(int money);
    public static event OnAddMoney OnMoneyAdded;

    [SerializeField] private int moneyPerTick;
    [SerializeField] private int tickRate;

    [SerializeField] private float timer = 0;

    private void Update()
    {
        if (isActive)
        {
            timer += Time.deltaTime;

            if (timer >= tickRate)
            {
                timer = 0f;
                OnMoneyAdded?.Invoke(moneyPerTick);
            }
        }
    }

}

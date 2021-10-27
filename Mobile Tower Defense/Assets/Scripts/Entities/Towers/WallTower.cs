using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTower : Tower
{
    [SerializeField] private float regenAmount = 1;
    [SerializeField] private float waitPeriod = 3;

    private void FixedUpdate()
    {
        if (health != maxHealth)
        {
            StartCoroutine(WaitForRegen(health));
        }
    }

    IEnumerator WaitForRegen(float curHealth)
    {
        yield return new WaitForSeconds(waitPeriod);
        if (curHealth == health)
        {
            Heal(regenAmount);
        }
    }
}

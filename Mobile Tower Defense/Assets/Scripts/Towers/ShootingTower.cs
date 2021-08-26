using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootingTower : Tower
{
    public float damage;
    public float range;
    public float attackSpeed;

    //Maybe add kills stat later

    protected override void Start()
    {
        base.Start();
    }

    public abstract void Shoot();//May just make one method here depending on how different towers shoot
}

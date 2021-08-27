using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] private float damage;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float attackSpeed;

    protected override void Start()
    {

        base.Start();
    }

    void Update()
    {
        
    }
}

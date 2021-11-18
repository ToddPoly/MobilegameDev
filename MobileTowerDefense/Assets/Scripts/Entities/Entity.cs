using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour //Base script used for taking damage and having health
{
    public float maxHealth;
    [SerializeField] protected float health;
    protected bool dead;
    protected bool hit = false;

    public bool isActive = false;

    protected virtual void Start()
    {
        health = maxHealth;
    }

    public virtual void TakeDamage(float damage)
    {
        hit = true;//Need to get this working for take hit animation on enemies
        health -= damage;

        //setup OnTowerDamaged event later
        //Debug.Log(damage);

        if (health <= 0 && !dead)
        {
            Die();
        }
    }

    public virtual float Heal(float healAmount)
    {
        health += healAmount;
        return health = Mathf.Clamp(health, 0f, maxHealth);//Clamp sets the min and max values for a given number/float
    }

    protected virtual void Die()
    {
        dead = true;
        //setup  OnTowerKilled event later
        Destroy(gameObject);
    }
}

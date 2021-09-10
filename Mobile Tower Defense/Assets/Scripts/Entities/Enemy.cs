using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    #region Events
    public delegate void OnEnemyDeath(float pointValue);
    public static event OnEnemyDeath EnemyDeath;

    #endregion

    public int pointValue;//only mulitpes of 5
    [SerializeField] private float damage;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float attackSpeed;
    private float nextAttackTime;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask towerLayer;


    #region Builtin Methods
    private void OnValidate()//checks if pointValue is a multiple of 5 so it doesnt break the spawning while loop
    {
        if (pointValue % 5 != 0)
        {
            pointValue = pointValue - (pointValue % 5);
        }
    }

    void Update()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, attackRange, towerLayer))
        {
            var hit = hitInfo.collider.GetComponent<Entity>();
            if (hit)
            {
                Debug.Log("Close to tower");
                if (Time.time > nextAttackTime)
                {
                    nextAttackTime = Time.time + attackSpeed;
                    StartCoroutine(Attack(hit));
                }
            }
        }
        else //Add if else for making it to the player base/end of grid map and the player losing
        {
            Move();
        }  
    }


    #endregion

    #region Custom Methods

    public void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
    }

    protected override void Die()
    {
        EnemyDeath?.Invoke(pointValue);//when an enemy dies it sends its point value to the wave manager to use
        base.Die();
    }

    #endregion

    #region Coroutines
    IEnumerator Attack(Entity entity)
    {
        //Play attacking animation on loop

        float percent = 0;
        float attackTime = 3;
        bool hasAppliedDamage = false;

        while (percent <= 1)
        {
            if (percent >= 0.5f && !hasAppliedDamage)
            {
                hasAppliedDamage = true;
                entity.TakeDamage(damage);
            }

            percent += Time.deltaTime * attackTime;

            yield return null;
        }
    }

    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public float pointValue;
    [SerializeField] private float damage;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float attackSpeed;
    private float nextAttackTime;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask towerLayer;


    protected override void Start()//doesnt need to be here currently
    {
        base.Start();
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

    public void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
    }

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
}

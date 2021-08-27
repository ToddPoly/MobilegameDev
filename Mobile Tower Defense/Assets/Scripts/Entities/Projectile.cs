using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public LayerMask enemyLayer;
    float speed;
    float damage;

    float lifeTime = 5;
    float projectileWidth = 0.1f;

    #region Builtin Methods

    private void Start()
    {
        Destroy(gameObject, lifeTime);

        Collider[] intialCollisions = Physics.OverlapSphere(transform.position, 0.1f, enemyLayer);//use | for or when checking collision masks
        if (intialCollisions.Length > 0)
        {
            OnHitObject(intialCollisions[0]);
        }
    }

    void Update()
    {
        float moveDistance = speed * Time.deltaTime;
        CheckCollisions(moveDistance);
        transform.Translate(Vector3.forward * moveDistance);
    }

    #endregion

    #region Custom Methods
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void SetDamage(float newDamage)
    {
        damage = newDamage;
    }

    public void CheckCollisions(float moveDistance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, moveDistance + projectileWidth, enemyLayer, QueryTriggerInteraction.Collide))
        {
            //print(hit.collider.gameObject.name);
            OnHitObject(hit);
        }
    }

    public void OnHitObject(RaycastHit hit)
    {
        Enemy enemy = hit.collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        //print(hit.collider.gameObject.name);
        GameObject.Destroy(gameObject);
    }

    public void OnHitObject(Collider col)
    {
        Enemy enemy = col.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        //print(col.gameObject.name);
        GameObject.Destroy(gameObject);
    }

    #endregion
}

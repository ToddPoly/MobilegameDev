using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTower : Entity
{
    [SerializeField] private float damage;
    [SerializeField] private float range;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private LayerMask enemyLayer ;
    private float nextShotTime;

    [SerializeField] private Transform projectileSpawn;//Where bullet comes out ie barrel

    public Projectile projectile;

    //Maybe add kills stat later

    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        if (DetectEnemy() && isActive)
        {
            Shoot();
        }
    }

    public bool DetectEnemy()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, range, enemyLayer))//Raycast down lane and detect if an enemy is present, if there is start the shoot method
        {
            return true;
        }
        else
        {
            return false;
        }        
    }

    public void Shoot()//Just for shooting basic projectiles like a bullet of basic rocket
    {
        if (Time.time > nextShotTime)
        {
            //For normal bullet projectile
            Quaternion newRotation = projectileSpawn.rotation;


            newRotation = Quaternion.Euler(projectileSpawn.eulerAngles.x, projectileSpawn.eulerAngles.y, projectileSpawn.eulerAngles.z);
            Projectile newProjectile = Instantiate(projectile, projectileSpawn.position, newRotation) as Projectile;
            newProjectile.SetSpeed(projectileSpeed);//Spawns bullet and sets its velcocity
            newProjectile.SetDamage(damage);


            nextShotTime = Time.time + attackSpeed / 1000;//Calculating for milliseconds 
        }
    }
}

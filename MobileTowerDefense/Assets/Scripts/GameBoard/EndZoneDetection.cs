using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZoneDetection : MonoBehaviour
{
    public delegate void OnEnemyEnter();
    public static event OnEnemyEnter OnEnemyEntered;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("col hit");
        if (collision.gameObject.tag == "Enemy")
        {
            OnEnemyEntered?.Invoke();
            collision.gameObject.GetComponent<Enemy>().TakeDamage(1000);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("col hit");
        if (other.gameObject.tag == "Enemy")
        {
            OnEnemyEntered?.Invoke();
            other.gameObject.GetComponent<Enemy>().TakeDamage(1000);
        }
    }
}
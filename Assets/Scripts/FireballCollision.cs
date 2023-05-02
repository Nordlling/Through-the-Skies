using System;
using UnityEngine;

public class FireballCollision : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private int damage = 40;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") )
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(damage);
        }
        Instantiate(explosionPrefab, transform.position, explosionPrefab.transform.rotation);
        Destroy(gameObject);
    }
}

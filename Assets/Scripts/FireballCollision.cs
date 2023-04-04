using System;
using UnityEngine;

public class FireballCollision : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private int damage = 40;
    
    public static event Action<int> OnTakeDamage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") )
        {
            OnTakeDamage?.Invoke(damage);
            Instantiate(explosionPrefab, transform.position, explosionPrefab.transform.rotation);
            Destroy(gameObject);
        }
    }
}

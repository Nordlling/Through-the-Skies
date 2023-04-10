// using System;
// using UnityEngine;
//
// public abstract class AbstractDamageCollision : MonoBehaviour
// {
//     [SerializeField] private GameObject explosionPrefab;
//     [SerializeField] private int damage = 40;
//     
//     public static event Action<int> OnTakeDamage;
//
//     protected void OnTriggerEnter(Collider other)
//     {
//         if (other.gameObject.CompareTag("Enemy") )
//         {
//             OnTakeDamage?.Invoke(damage);
//             Instantiate(explosionPrefab, transform.position, explosionPrefab.transform.rotation);
//             Destroy(gameObject);
//         }
//     }
// }

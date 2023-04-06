using System;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] private int damage = 40;
    
    public static event Action<GameObject, int> OnTakeDamage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") )
        {
            OnTakeDamage?.Invoke(other.gameObject, damage);
        }
    }
}

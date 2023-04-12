using System;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] private int damage = 40;
    private bool _alreadyDamaged;
    
    public static event Action<GameObject, int> OnTakeDamage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !_alreadyDamaged)
        {
            _alreadyDamaged = true;
            OnTakeDamage?.Invoke(other.gameObject, damage);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _alreadyDamaged = false;
        }
    }
}

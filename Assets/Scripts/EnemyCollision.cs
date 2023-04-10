using System;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] private int damage = 40;
    private bool _alreadyDamaged;
    
    public static event Action<GameObject, int> OnTakeDamage;

    private void OnTriggerEnter(Collider other)
    {
        if (!_alreadyDamaged && other.gameObject.CompareTag("Player"))
        {
            OnTakeDamage?.Invoke(other.gameObject, damage);
            _alreadyDamaged = true;
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

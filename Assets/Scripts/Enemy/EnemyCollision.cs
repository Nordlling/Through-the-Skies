using UnityEngine;
using Zenject;

public class EnemyCollision : MonoBehaviour
{
    [Inject] private PlayerHealth _playerHealth;
    [SerializeField] private int damage = 40;
    private bool _alreadyDamaged;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !_alreadyDamaged)
        {
            _alreadyDamaged = true;
            _playerHealth.TakeDamage(damage);
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

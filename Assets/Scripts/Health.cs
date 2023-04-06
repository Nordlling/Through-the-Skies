using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    [SerializeField] private Animator animator;
    private Collider[] _colliders;
    private Rigidbody _rigidbody;
    private MonoBehaviour[] _components;
    

    private void Start()
    {
        _components = GetComponents<MonoBehaviour>();
        _colliders = GetComponentsInChildren<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        FireballCollision.OnTakeDamage += TakeDamage;
        EnemyCollision.OnTakeDamage += TakeDamage;
    }
    private void OnDisable()
    {
        FireballCollision.OnTakeDamage -= TakeDamage;
        EnemyCollision.OnTakeDamage -= TakeDamage;
    }

    private void TakeDamage(GameObject damagedObject, int damage)
    {
        if (damage < 0)
        {
            throw new Exception("Negative damage");
        }

        if (damagedObject != gameObject)
        {
            return;
        }

        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetTrigger("die");
        foreach (var collider in _colliders)
        {
            collider.enabled = false;
        }
        if (_rigidbody != null)
        {
            _rigidbody.isKinematic = true;
        }
        foreach (var component in _components)
        {
            component.enabled = false;
        }
    }
}
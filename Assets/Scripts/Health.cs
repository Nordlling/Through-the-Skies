using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    private Animator _animatorController;
    private EnemyMovement _enemyMovement;
    private Collider _collider;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _enemyMovement = GetComponent<EnemyMovement>();
        _animatorController = _enemyMovement.GetAnimatorController();
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        FireballCollision.OnTakeDamage += TakeDamage;
    }
    private void OnDisable()
    {
        FireballCollision.OnTakeDamage -= TakeDamage;
    }

    private void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            throw new Exception("Negative damage");
        }
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _animatorController.SetTrigger("Die");
        _enemyMovement.enabled = false;
        _collider.enabled = false;
        _rigidbody.isKinematic = true;
    }
}
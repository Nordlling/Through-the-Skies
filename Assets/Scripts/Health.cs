using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    
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
        Debug.Log("DIE");
    }
}
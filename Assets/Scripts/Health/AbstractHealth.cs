using System;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class AbstractHealth : MonoBehaviour
{
    [SerializeField] protected int health = 100;
    [SerializeField] protected Animator animator;
    
    protected Rigidbody Rigidbody;
    protected Collider[] Colliders;
    protected MonoBehaviour[] Components;

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Colliders = GetComponentsInChildren<Collider>();
        Components = GetComponents<MonoBehaviour>();
    }

    protected void TakeDamage(GameObject damagedObject, int damage)
    {
        if (damagedObject != gameObject)
        {
            return;
        }

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

    protected virtual void Die()
    {
        animator.SetTrigger("die");
        foreach (var collider in Colliders)
        {
            collider.enabled = false;
        }
        if (Rigidbody != null)
        {
            Rigidbody.isKinematic = true;
        }
        foreach (var component in Components)
        {
            component.enabled = false;
        }
    }
}
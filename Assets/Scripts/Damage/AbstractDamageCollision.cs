using System;
using UnityEngine;

public abstract class AbstractDamageCollision : MonoBehaviour
{
    [SerializeField] protected int damage = 40;

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<AbstractHealth>(out var damageable))
        {
            damageable.TakeDamage(damage);
        }
    }
}

using System;
using UnityEngine;

public class FireballCollision : AbstractDamageCollision
{
    [SerializeField] private GameObject explosionPrefab;
    // [SerializeField] private int damage = 40;

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        Instantiate(explosionPrefab, transform.position, explosionPrefab.transform.rotation);
        Destroy(gameObject);
    }
}

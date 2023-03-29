using System;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private float lifeTime = 2f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
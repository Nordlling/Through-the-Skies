using UnityEngine;
using UnityEngine.Serialization;

public class FireballCollision : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") )
        {
            Instantiate(explosionPrefab, transform.position, explosionPrefab.transform.rotation);
            Destroy(gameObject);
        }
    }
}

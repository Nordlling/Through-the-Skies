using UnityEngine;
using UnityEngine.Serialization;

public class Fireball : MonoBehaviour, ISkill
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform point;
    [SerializeField] private float speed = 600f;

    public void Attack()
    {
        var fireBall = Instantiate(prefab, point.position, Quaternion.identity);
        fireBall.GetComponent<Rigidbody>().AddForce(point.forward * speed);
    }
}

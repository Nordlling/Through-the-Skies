using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 0.15f;
    
    private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position;
    }

    private void LateUpdate()
    {
        Vector3 actualPosition = target.position + _offset;
        transform.position = Vector3.Lerp(transform.position, actualPosition, smoothSpeed);
    }
}

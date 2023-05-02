using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class PlayerFallChecker : MonoBehaviour
{

    [Inject] private CameraFreezer _cameraFreezer;
    
    [SerializeField] private float secondsToDie = 1f;
    [SerializeField] private float distanceToDie = Mathf.Infinity;
    private float _leftSecondsToDie;

    private void Start()
    {
        _leftSecondsToDie = secondsToDie;
    }

    public void CheckPlayerToFall(Vector3 origin, Vector3 direction)
    {
        if (direction.y < 0)
        {
            Ray ray = new Ray(origin, direction);
            _leftSecondsToDie -= Time.deltaTime;
            if (Physics.Raycast(ray, distanceToDie))
            {
                _leftSecondsToDie = secondsToDie;
            }
        }
        if (_leftSecondsToDie < 0f)
        {
            Debug.Log("NO PLATFORM");
            _cameraFreezer.Freeze();
            _leftSecondsToDie = secondsToDie;
        }

        Debug.DrawRay(transform.position, direction * 30, Color.green);
    }
}
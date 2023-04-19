using UnityEngine;

public class CameraFreezer : MonoBehaviour
{
    [SerializeField] private float secondsToLive = 1f;
    [SerializeField] private Renderer target;

    private bool _freeze;
    private float _leftSecondsToLive;
    private CameraFollow _cameraFollow;
    private Camera _camera;


    private void Start()
    {
        _leftSecondsToLive = secondsToLive;
        _cameraFollow = GetComponent<CameraFollow>();
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (!_freeze)
        {
            return;
        }
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_camera);
        if (!GeometryUtility.TestPlanesAABB(planes, target.bounds))
        {
            Debug.Log("Player is GONE");
            GameOverNotifier.GameOver();
            enabled = false;
        }

        _leftSecondsToLive -= Time.deltaTime;
        if (_leftSecondsToLive < 0f)
        {
            UnFreeze();
        }
    }

    public void Freeze()
    {
        _freeze = true;
        _cameraFollow.enabled = false;
    }
    
    public void UnFreeze()
    {
        _freeze = false;
        _cameraFollow.enabled = true;
    }
}

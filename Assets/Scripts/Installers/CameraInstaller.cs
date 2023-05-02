using UnityEngine;
using Zenject;

public class CameraInstaller : MonoInstaller
{
    [SerializeField] private CameraFollow cameraFollow;
    
    public override void InstallBindings()
    {
        Container.Bind<CameraFollow>().FromInstance(cameraFollow).AsSingle();
        Container.QueueForInject(cameraFollow);
        
        CameraFreezer cameraFreezer = cameraFollow.GetComponent<CameraFreezer>();
        Container.Bind<CameraFreezer>().FromInstance(cameraFreezer).AsSingle();
        Container.QueueForInject(cameraFreezer);
    }
}
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{

    [SerializeField] private PlayerMovement playerMovement;
    // [SerializeField] private Transform playerSpawnPoint;
    
    public override void InstallBindings()
    {
        // For prefab
        // var playerInstance = Container.InstantiatePrefabForComponent<PlayerUnit>(
        //     playerUnit, playerSpawnPoint.position, Quaternion.identity, null);
        // Container.Bind<PlayerUnit>().FromInstance(playerInstance).AsSingle();
        
        Container.Bind<PlayerMovement>().FromInstance(playerMovement).AsSingle();
        Container.QueueForInject(playerMovement);
    }
}


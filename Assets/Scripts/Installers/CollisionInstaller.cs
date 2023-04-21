using UnityEngine;
using Zenject;

public class CollisionInstaller : MonoInstaller
{
    //todo
    [SerializeField] private EnemyHealth enemyCollision;
    [SerializeField] private FireballCollision fireballCollision;
    
    [SerializeField] private Transform enemySpawnPoint;
    
    public override void InstallBindings()
    {
        var enemyInstance = Container.InstantiatePrefabForComponent<EnemyHealth>(enemyCollision, enemySpawnPoint.position, Quaternion.identity, null);
        Container.Bind<EnemyHealth>().FromInstance(enemyInstance).AsSingle();
    }
}


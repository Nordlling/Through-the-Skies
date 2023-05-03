using UnityEngine;
using Zenject;

public class CollisionInstaller : MonoInstaller
{
    [SerializeField] private EnemyCollision enemyCollision;
    [SerializeField] private FireballCollision fireballCollision;
    
    [SerializeField] private Transform fireballSpawnPoint;
    
    public override void InstallBindings()
    {
        // Container
        //     .Bind<IEnemyFactory>()
        //     .To<EnemyFactory>()
        //     .AsSingle();
    }
}


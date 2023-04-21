using UnityEngine;
using Zenject;

public class CoinInstaller : MonoInstaller
{
    [SerializeField] private CoinCollector coinCollector;
    
    public override void InstallBindings()
    {
        Container.Bind<CoinCollector>().FromInstance(coinCollector).AsSingle().NonLazy();
    }
}
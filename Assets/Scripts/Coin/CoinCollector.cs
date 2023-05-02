using System;
using UnityEngine;

[DisallowMultipleComponent]
public class CoinCollector : MonoBehaviour
{
    public event Action<CoinCollector> OnUpdate;
    
    public int CoinCount { get; private set; }

    public void AddCoin(int count)
    {
        CoinCount += count;
        OnUpdate?.Invoke(this);
    }
}
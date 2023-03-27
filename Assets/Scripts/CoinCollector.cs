using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public int CoinCount { get; private set; } 
    public static CoinCollector Instance { get; private set; }
    public event System.Action<CoinCollector> OnUpdate;
    
    void Awake()
    {
        Instance = this;
    }

    private void OnDestroy()
    {
        Instance = null;
    }
    
    public void AddCoin(int count)
    {
        CoinCount += count;
        if (OnUpdate != null)
        {
            OnUpdate(this);
        }
    }
}
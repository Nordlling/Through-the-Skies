using UnityEngine;

[DisallowMultipleComponent]
public class CoinCollector : MonoBehaviour
{
    public int CoinCount { get; private set; } 
    public static CoinCollector Instance { get; private set; }
    public event System.Action<CoinCollector> OnUpdate;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Trying to instantiate a second instance of singleton class CoinCollector");
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void OnDestroy()
    {
        Instance = null;
    }
    
    public void AddCoin(int count)
    {
        CoinCount += count;
        OnUpdate?.Invoke(this);
    }
}
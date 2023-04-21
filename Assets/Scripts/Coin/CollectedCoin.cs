using UnityEngine;
using Zenject;

public class CollectedCoin : MonoBehaviour
{
    [Inject] private CoinCollector _coinCollector;
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _coinCollector.AddCoin(1);
            Destroy(gameObject);
        }
    }
}

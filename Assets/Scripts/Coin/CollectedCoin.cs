using UnityEngine;

public class CollectedCoin : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CoinCollector.Instance.AddCoin(1);
            Destroy(gameObject);
        }
    }
}

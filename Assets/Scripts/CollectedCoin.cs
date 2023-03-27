using UnityEngine;

public class CollectedCoin : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            CoinCollector.Instance.AddCoin(1);
            Destroy(gameObject);
        }
    }
}

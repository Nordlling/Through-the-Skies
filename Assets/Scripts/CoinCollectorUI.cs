using TMPro;
using UnityEngine;

public class CoinCollectorUI : MonoBehaviour
{
    public TextMeshProUGUI coinCount;

    private void Start()
    {
        CoinCollector.Instance.OnUpdate += UpdateUI; 
    }

    private void UpdateUI(CoinCollector coinCollector)
    {
        coinCount.text = coinCollector.CoinCount.ToString();
    }

    private void OnDestroy()
    {
        if (CoinCollector.Instance != null)
        {
            CoinCollector.Instance.OnUpdate -= UpdateUI;
        }
    }
}

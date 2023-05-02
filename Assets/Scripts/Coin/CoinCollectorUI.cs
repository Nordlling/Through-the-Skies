using TMPro;
using UnityEngine;
using Zenject;

public class CoinCollectorUI : MonoBehaviour
{
    [Inject] private CoinCollector _coinCollector;
    
    [SerializeField] private TextMeshProUGUI coinCount;

    private void Start()
    {
        _coinCollector.OnUpdate += UpdateUI; 
    }

    private void UpdateUI(CoinCollector coinCollector)
    {
        coinCount.text = coinCollector.CoinCount.ToString();
    }

    private void OnDestroy()
    {
        if (_coinCollector != null)
        {
            _coinCollector.OnUpdate -= UpdateUI;
        }
    }
}

using TMPro;
using UnityEngine;

public class UIGameUpdater : MonoBehaviour
{
    [SerializeField] private CoinCounter _coinCounter;

    [SerializeField] private TextMeshProUGUI _coinsText;

    [SerializeField] private GameObject _winScreen;
    
    private void Start()
    {
        _coinCounter.OnCoinsCountChanged += ChangeCoinsText;
        _coinCounter.OnAllCoinsCollected += Win;
        
        //ChangeCoinsText(_coinCounter.TotalCoins);
    }

    private void ChangeCoinsText(int remainingCoins)
    {
        _coinsText.text = " Coins left: " + remainingCoins;
    }

    private void Win()
    {
        Time.timeScale = 0;
        
        _winScreen.SetActive(true);
    }

    private void OnDestroy()
    {
        _coinCounter.OnCoinsCountChanged -= ChangeCoinsText;
        _coinCounter.OnAllCoinsCollected -= Win;
    }
}

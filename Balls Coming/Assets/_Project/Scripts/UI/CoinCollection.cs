using UnityEngine;
using TMPro;

namespace BallsComing.UI
{
	public class CoinCollection : MonoBehaviour
	{
		private TextMeshProUGUI coinText;

        public struct CoinData
        {
            public int coin;
            public int maxCoin;
        }
        public static CoinData coinData;

        private void Awake()
        {
            coinText = GetComponent<TextMeshProUGUI>();

            coinData.coin = 0;
            coinData.maxCoin = PlayerPrefs.GetInt(nameof(coinData.maxCoin), 0);
        }

        private void Start()
        {
            coinText.text = $"x {coinData.coin}";
        }

        private void Update()
        {
            if (GameStatsGetter() != 1) GameStatsCheck();
        }

        private void GameStatsCheck()
        {
            if (GameStatsGetter() != 0) SetMaxCoin();
        }

        public void AddCoins()
        {
            coinData.coin += 10;
            coinText.text = $"x {coinData.coin}";
        }

        private void SetMaxCoin()
        {
            if (coinData.coin > coinData.maxCoin) PlayerPrefs.SetInt(nameof(coinData.maxCoin), (int)coinData.coin);

            coinData.maxCoin = PlayerPrefs.GetInt(nameof(coinData.maxCoin), 0);
            
            Destroy(gameObject);
        }

        private int GameStatsGetter() { return (int)Core.GameManager.gameStats; }
    }
}
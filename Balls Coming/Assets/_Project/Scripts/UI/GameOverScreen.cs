using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace BallsComing.UI
{
	public class GameOverScreen : MonoBehaviour
	{
        private struct ResultsSet
        {
            public TextMeshProUGUI coinsText;
            public TextMeshProUGUI maxCoinsText;

            public TextMeshProUGUI timeText;
            public TextMeshProUGUI maxTimeText;
        }
        private ResultsSet resultSet;

        private void Awake()
        {
            resultSet.coinsText = GameObject.Find("Final Coins Text").GetComponent<TextMeshProUGUI>();
            resultSet.maxCoinsText = GameObject.Find("Final Maximum Coins Text").GetComponent<TextMeshProUGUI>();

            resultSet.timeText = GameObject.Find("Final Time Text").GetComponent<TextMeshProUGUI>();
            resultSet.maxTimeText = GameObject.Find("Final Maximum Time Text").GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            if (GameStatsGetter() == 2) ShowResults();
        }

        private void ShowResults()
        {
            resultSet.coinsText.text = $"Coins: {CoinCollection.coinData.coin:0}";
            resultSet.maxCoinsText.text = $"Maximum Coins: {CoinCollection.coinData.maxCoin}";

            resultSet.timeText.text = $"Time: {TimerManager.timerData.time:0}";
            resultSet.maxTimeText.text = $"Maximum Time: {TimerManager.timerData.maxTime}";
        }

        public void LeaderboardsButton()
        {
            // Go to leaderboards panel
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void ExitButton()
        {
            Application.Quit();
        }

        private int GameStatsGetter() { return (int)Core.GameManager.gameStats; }
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;

namespace BallsComing.UI
{
	public class GameOverMenuManager : MonoBehaviour
	{
        [SerializeField] private UnityEvent playInGameMusic;
        [SerializeField] private UnityEvent stopInGameMusic;

        private LeaderboardsManager leaderboardsManager;
        
        private struct ResultsSet
        {
            public TextMeshProUGUI highestCoins;
            public TextMeshProUGUI collectedCoins;
        }
        private ResultsSet resultSet;

        private GameObject inGamePanel;
        private GameObject gameOverPanel;

        private GameObject leaderboardPanel;
        private GameObject leaderboardMenu;

        private AudioSource gameOverAudio;

        private bool leaderboardFetched = false;

        private void Awake()
        {
            leaderboardsManager = GameObject.Find("Database Manager").GetComponent<LeaderboardsManager>();

            resultSet.highestCoins = GameObject.Find("Highest Coins Text").GetComponent<TextMeshProUGUI>();
            resultSet.collectedCoins = GameObject.Find("Collected Coins Text").GetComponent<TextMeshProUGUI>();

            inGamePanel = GameObject.Find("In-Game Panel");
            gameOverPanel = GameObject.Find("Game Over Panel");

            leaderboardPanel = GameObject.Find("Leaderboard Panel");
            leaderboardMenu = GameObject.Find("Leaderboard Menu");

            gameOverAudio = gameOverPanel.GetComponent<AudioSource>();
        }

        private void Start()
        {
            leaderboardPanel.SetActive(true);
            leaderboardMenu.SetActive(false);
        }

        [System.Obsolete]
        private void Update()
        {
            if (!leaderboardFetched && GameStatsGetter() == 2) GameResults();
        }

        [System.Obsolete]
        private void GameResults()
        {
            stopInGameMusic.Invoke();

            int collectedCoins = CoinCollection.coinData.collectedCoins;
            int highestCoins = CoinCollection.coinData.highestCoins;

            StartCoroutine(leaderboardsManager.SubmitCoinRoutine(collectedCoins));

            if (collectedCoins > highestCoins)
                resultSet.highestCoins.text = $"Highest Coins: {collectedCoins}";

            else
                resultSet.highestCoins.text = $"Highest Coins: {highestCoins}";

            resultSet.collectedCoins.text = $"Coins: {collectedCoins:0}";

            leaderboardFetched = true;
        }

        public void LeaderboardsButton()
        {
            if (gameOverAudio.enabled == true)
                gameOverAudio.enabled = false;

            gameOverPanel.SetActive(false);
            leaderboardMenu.SetActive(true);
        }

        public void LeaderboardsBackButton()
        {
            leaderboardMenu.SetActive(false);
            gameOverPanel.SetActive(true);
        }

        [System.Obsolete]
        public void RestartGame()
        {
            playInGameMusic.Invoke();

            leaderboardFetched = false;

            StartCoroutine(leaderboardsManager.FetchCurrentPlayerHighCoinsRoutine());
            StartCoroutine(leaderboardsManager.FetchTopHighCoinsRoutine());

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void ExitButton()
        {
            Application.Quit();
        }

        private int GameStatsGetter() { return (int)Core.GameManager.gameState; }
    }
}
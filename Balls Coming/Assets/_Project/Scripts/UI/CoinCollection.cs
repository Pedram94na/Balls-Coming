using UnityEngine;
using UnityEngine.Events;
using TMPro;

using System.Collections;

namespace BallsComing.UI
{
    public class CoinCollection : MonoBehaviour
    {
        private bool HasReachedMilestone => coinData.collectedCoins > milestone;

        private LeaderboardsManager leaderboardsManager;
        private TextMeshProUGUI coinText;

        public struct CoinData
        {
            public int collectedCoins;
            public int highestCoins;
        }
        public static CoinData coinData;

        [SerializeField] private UnityEvent milestoneReachedEv;
        [SerializeField] private UnityEvent blueBallsMilestoneReachedEv;

        private float milestone = 50f;
        private bool blueBallsMilestoneCheck = false;

        private bool coinsSubmited = false;

        private void Awake()
        {
            leaderboardsManager = GameObject.Find("Database Manager").GetComponent<LeaderboardsManager>();

            coinText = GetComponent<TextMeshProUGUI>();

            //PlayerPrefs.SetInt("coinData.highestCoins", 0); // Testing
            coinData.collectedCoins = 0;
            coinData.highestCoins = PlayerPrefs.GetInt("coinData.highestCoins", 0);
        }

        private void Start()
        {
            coinText.text = $"x {coinData.collectedCoins}";
        }

        [System.Obsolete]
        private void Update()
        {
            //Debug.Log($"<color=green>Highes coins: {coinData.highestCoins} GameStats: {GameStatsGetter()}</color>");
            //Debug.Log($"<color=yellow>Collected coins: {coinData.collectedCoins}</color>");

            if (!coinsSubmited && GameStatsGetter() == 2) StartCoroutine(SubmitToLeaderboard());
        }

        [System.Obsolete]
        private IEnumerator SubmitToLeaderboard()
        {
            //Debug.Log(coinData.highestCoins);
            //Debug.Log($"<color=red> coins: {coinData.collectedCoins}</color>");

            if (coinData.collectedCoins > coinData.highestCoins)
            {
                PlayerPrefs.SetInt("coinData.highestCoins", coinData.collectedCoins);
                //Debug.Log($"<color=red>Highes coins: {coinData.highestCoins}</color>");

                yield return leaderboardsManager.SubmitCoinRoutine(coinData.collectedCoins);
            }

            coinsSubmited = true;
        }

        public void AddCoins()
        {
            coinData.collectedCoins += 10;
            coinText.text = $"x {coinData.collectedCoins}";

            if (HasReachedMilestone) NewMilestone();
        }

        private void NewMilestone()
        {
            milestone *= 2;

            milestoneReachedEv.Invoke();

            if (!blueBallsMilestoneCheck && milestone > 100f)
            {
                blueBallsMilestoneReachedEv.Invoke();

                blueBallsMilestoneCheck = true;
            }
        }

        private int GameStatsGetter() { return (int)Core.GameManager.gameState; }
    }
}

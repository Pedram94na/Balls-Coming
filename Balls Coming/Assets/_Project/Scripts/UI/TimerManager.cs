using UnityEngine;
using UnityEngine.Events;
using TMPro;

namespace BallsComing.UI
{
	public class TimerManager : MonoBehaviour
    {
        [SerializeField] private UnityEvent gameOverEv;

        private TextMeshProUGUI timerText;

        public struct TimerData
        {
            public float time;
            public int maxTime;
        }
        public static TimerData timerData;

        private void Awake()
        {
            timerText = GetComponent<TextMeshProUGUI>();

            timerData.time = 0;

            timerData.maxTime = PlayerPrefs.GetInt(nameof(timerData.maxTime), 0);
        }

        private void Start()
        {
            timerText.text = null;
        }

        private void Update()
        {
            if (GameStatsGetter() != 1) GameStatsCheck();
        }

        private void GameStatsCheck()
        {
            if (GameStatsGetter() == 0) Timer();
        }

        private void Timer()
        {
            timerData.time += Time.deltaTime;
            timerText.text = $"{timerData.time:0}";
        }

        private int GameStatsGetter() { return (int)Core.GameManager.gameState; }
    }
}
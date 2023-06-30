using UnityEngine;
using TMPro;
using UnityEngine.Events;

namespace BallsComing.UI
{
	public class TimerManager : MonoBehaviour
    {
        private bool HasReachedMilestone => timerData.time > milestone;

        [SerializeField] private UnityEvent gameOverEv;
        [SerializeField] private UnityEvent milestoneReachedEv;

        private GameObject gameOverPanel;

        private TextMeshProUGUI timerText;
        private float milestone = 10f;

        public struct TimerData
        {
            public float time;
            public int maxTime;
        }
        public static TimerData timerData;

        private void Awake()
        {
            gameOverPanel = GameObject.Find("Game Over Panel");

            timerText = GetComponent<TextMeshProUGUI>();

            timerData.time = 0;

            timerData.maxTime = PlayerPrefs.GetInt(nameof(timerData.maxTime), 0);
        }

        private void Start()
        {
            gameOverPanel.SetActive(false);

            timerText.text = null;
        }

        private void Update()
        {
            if (GameStatsGetter() != 1) GameStatsCheck();
        }

        private void GameStatsCheck()
        {
            if (GameStatsGetter() == 0) Timer();

            else SetMaxTime();
        }

        private void Timer()
        {
            timerData.time += Time.deltaTime;
            timerText.text = $"{timerData.time:0}";

            if (HasReachedMilestone) NewMilestone();
        }

        private void NewMilestone()
        {
            milestone *= 2;

            milestoneReachedEv.Invoke();
        }

        private void SetMaxTime()
        {
            if (timerData.time > timerData.maxTime) PlayerPrefs.SetInt(nameof(timerData.maxTime), (int)timerData.time);

            timerData.maxTime = PlayerPrefs.GetInt(nameof(timerData.maxTime), 0);

            gameOverPanel.SetActive(true);

            gameOverEv.Invoke();

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Destroy(gameObject);
        }

        private int GameStatsGetter() { return (int)Core.GameManager.gameStats; }
    }
}
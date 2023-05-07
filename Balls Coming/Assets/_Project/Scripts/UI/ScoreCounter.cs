using UnityEngine;
using TMPro;
using UnityEngine.Events;

namespace BallsComing.UI
{
	public class ScoreCounter : MonoBehaviour
    {
        private bool HasReachedMilestone => scoreSet.score > milestoneScore;

        [SerializeField] private UnityEvent gameOverScoreEv;
        [SerializeField] private UnityEvent milestoneReachedEv;

        private GameObject gameOverPanel;

        private TextMeshProUGUI scoreText;
        private float milestoneScore = 10f;

        public struct ScoreSet
        {
            public float score;
            public int highScore;
        }
        public static ScoreSet scoreSet;

        private void Awake()
        {
            gameOverPanel = GameObject.Find("Game Over Panel");

            scoreText = GetComponent<TextMeshProUGUI>();

            scoreSet.highScore = PlayerPrefs.GetInt(nameof(scoreSet.highScore), 0);
        }

        private void Start()
        {
            gameOverPanel.SetActive(false);

            scoreText.text = null;
        }

        private void Update()
        {
            if (GameStatsGetter() != 1) GameStatsCheck();
        }

        private int GameStatsCheck()
        {
            if (GameStatsGetter() == 0)
            {
                ScoreCounting();
                return GameStatsGetter();
            }

            CompareScores();
            return GameStatsGetter();
        }

        private int ScoreCounting()
        {
            scoreSet.score += Time.deltaTime;
            scoreText.text = $"Score: {scoreSet.score:0}";

            if (HasReachedMilestone) NewMilestone();

            return (int)scoreSet.score;
        }

        private float NewMilestone()
        {
            milestoneScore *= 2;

            milestoneReachedEv.Invoke();

            return milestoneScore;
        }

        private void CompareScores()
        {
            if (scoreSet.score > scoreSet.highScore) PlayerPrefs.SetInt(nameof(scoreSet.highScore), (int)scoreSet.score);

            scoreSet.highScore = PlayerPrefs.GetInt(nameof(scoreSet.highScore), 0);

            gameOverPanel.SetActive(true);

            gameOverScoreEv.Invoke();

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            scoreSet.score = 0;
            Destroy(gameObject);
        }

        private int GameStatsGetter() { return (int)Core.GameManager.gameStats; }
    }
}
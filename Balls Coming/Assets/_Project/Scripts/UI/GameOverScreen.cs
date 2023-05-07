using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace BallsComing.UI
{
	public class GameOverScreen : MonoBehaviour
	{
        private struct ScoreSet
        {
            public TextMeshProUGUI scoreText;
            public TextMeshProUGUI highScoreText;
        }
        private ScoreSet scoreSet;

        private void Awake()
        {
            scoreSet.scoreText = GameObject.Find("Final Score Text").GetComponent<TextMeshProUGUI>();
            scoreSet.highScoreText = GameObject.Find("Final High Score Text").GetComponent<TextMeshProUGUI>();
        }

        public void SetScoreSet()
        {
            scoreSet.scoreText.text = $"Score: {ScoreCounter.scoreSet.score:0}";
            scoreSet.highScoreText.text = $"High Score: {ScoreCounter.scoreSet.highScore}";
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
    }
}
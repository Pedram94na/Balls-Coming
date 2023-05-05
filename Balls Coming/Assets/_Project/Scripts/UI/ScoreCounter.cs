using UnityEngine;
using TMPro;

namespace BallsComing
{
	public class ScoreCounter : MonoBehaviour
	{
		private TextMeshProUGUI scoreText;
        private float score = 0;

        private void Awake()
        {
            scoreText = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            scoreText.text = null;

            InvokeRepeating(nameof(ScoreCounting), 4f, 1f);
        }

        private void ScoreCounting()
        {
            score += 1;

            scoreText.text = $"Score: {Mathf.FloorToInt(score).ToString()}";
        }
    }
}
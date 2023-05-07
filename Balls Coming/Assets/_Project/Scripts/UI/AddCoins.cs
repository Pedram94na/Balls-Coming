using UnityEngine;
using TMPro;

namespace BallsComing.UI
{
	public class AddCoins : MonoBehaviour
	{
		private TextMeshProUGUI coinNumText;
        private int coinCount = 0;

        private void Awake()
        {
            coinNumText = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            coinNumText.text = $"x {coinCount}";
        }

        public void CoinAdded()
        {
            coinNumText.text = $"x {++coinCount}";
        }
    }
}
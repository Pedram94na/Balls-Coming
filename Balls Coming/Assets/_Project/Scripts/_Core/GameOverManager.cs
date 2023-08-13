using UnityEngine;
using UnityEngine.Events;

namespace BallsComing.Core
{
	public class GameOverManager : MonoBehaviour
	{
        [SerializeField] private UnityEvent setPlayingState;
        [SerializeField] private UnityEvent setPauseState;

        private GameObject gameOverPanel;

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            gameOverPanel = GameObject.Find("Game Over Panel");
        }

        private void Start()
        {
            gameOverPanel.SetActive(false);
        }

        public void GameOverRoutine()
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

            gameOverPanel.SetActive(true);
        }
    }
}
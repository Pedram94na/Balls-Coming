using UnityEngine;
using UnityEngine.Events;

namespace BallsComing.Core
{
	public class PauseGame : MonoBehaviour
	{
        [SerializeField] private UnityEvent PauseGameEve;
        [SerializeField] private UnityEvent UnpauseGameEve;

        private GameObject pauseMenu;

        private void Awake()
        {
            pauseMenu = GameObject.Find("Pause Menu");
        }

        private void Start()
        {
            pauseMenu.SetActive(false);
        }

        private void Update()
        {
            if (GetPauseInput() && GetGameState() != 2)
                TogglePause();
        }

        private void TogglePause()
        {
            if (GetGameState() == 0)
            {
                pauseMenu.SetActive(true);

                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;

                PauseGameEve.Invoke();
            }

            else if (GetGameState() == 1)
            {
                pauseMenu.SetActive(false);

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                UnpauseGameEve.Invoke();
            }

            Time.timeScale = GetGameState() == 0 ? 1f : 0f;
        }

        #region Getters
        private int GetGameState() { return (int)GameManager.gameState; }

        private bool GetPauseInput() { return InputManager.instance.PauseInput(); }
        #endregion
    }
}
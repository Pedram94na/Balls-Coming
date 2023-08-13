using UnityEngine;

using UnityEngine.SceneManagement;

namespace BallsComing.Core
{
	public class MainMenuManager : MonoBehaviour
	{
        private GameObject mainMenuPanel;

        private GameObject howToPlayMenu;
        private GameObject leaderboardsMenu;
        private GameObject creditsMenu;

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

            mainMenuPanel = GameObject.Find("Main Menu Panel");

            howToPlayMenu = GameObject.Find("How To Play Menu");
            leaderboardsMenu = GameObject.Find("Leaderboard Menu");
            creditsMenu = GameObject.Find("Credits Menu");
        }

        private void Start()
        {
            howToPlayMenu.SetActive(false);
            leaderboardsMenu.SetActive(false);
            creditsMenu.SetActive(false);
        }

        public void StartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void HowToPlayButton()
        {
            howToPlayMenu.SetActive(true);
            mainMenuPanel.SetActive(false);
        }

        public void HowToPlayBackButton()
        {
            howToPlayMenu.SetActive(false);
            mainMenuPanel.SetActive(true);
        }

        public void LeaderboardsButton()
        {
            leaderboardsMenu.SetActive(true);
            mainMenuPanel.SetActive(false);
        }

        public void LeaderboardsBackButton()
        {
            leaderboardsMenu.SetActive(false);
            mainMenuPanel.SetActive(true);
        }

        public void CreditsButton()
        {
            creditsMenu.SetActive(true);
            mainMenuPanel.SetActive(false);
        }

        public void CreditsBackButton()
        {
            creditsMenu.SetActive(false);
            mainMenuPanel.SetActive(true);
        }

        public void ExitButton()
        {
            Application.Quit();
        }
    }
}
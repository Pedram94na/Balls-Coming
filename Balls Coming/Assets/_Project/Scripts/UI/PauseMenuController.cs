using UnityEngine;
using UnityEngine.UI;

namespace BallsComing
{
	public class PauseMenuController : MonoBehaviour
	{
		private GameObject exitQuestionPanel;

        private Button exitButton;

        private void Awake()
        {
            exitQuestionPanel = GameObject.Find("Exit Question Panel");

            exitButton = GameObject.Find("Exit Button").GetComponent<Button>();
        }

        private void Start()
        {
            exitQuestionPanel.SetActive(false);
        }

        public void ExitButton()
        {
            exitQuestionPanel.SetActive(true);

            exitButton.interactable = false;
        }

        public void NoButton()
        {
            exitQuestionPanel.SetActive(false);

            exitButton.interactable = true;
        }

        public void YesButton()
        {
            Application.Quit();
        }
    }
}
using UnityEngine;
using TMPro;
using System.Collections;

namespace BallsComing
{
	public class CountDown : MonoBehaviour
	{
		private GameObject countDownPanel;
        private TextMeshProUGUI countDownText;

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            countDownPanel = GameObject.Find("Count Down Panel");
            countDownText = countDownPanel.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            countDownText.text = null;

            StartCoroutine(StartCountDown());
        }

        private IEnumerator StartCountDown()
        {
            countDownText.text = "3";
            yield return new WaitForSeconds(1f);

            countDownText.text = "2";
            yield return new WaitForSeconds(1f);

            countDownText.text = "1";
            yield return new WaitForSeconds(1f);

            countDownText.text = "Let's Go!";
            yield return new WaitForSeconds(1f);

            countDownText.text = null;
            Destroy(gameObject);
        }
    }
}
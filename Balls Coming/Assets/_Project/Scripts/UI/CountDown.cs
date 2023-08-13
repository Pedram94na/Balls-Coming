using UnityEngine;
using UnityEngine.Events;
using TMPro;

using BallsComing.Core;

using System.Collections;

namespace BallsComing
{
	public class CountDown : MonoBehaviour
	{
        [SerializeField] private UnityEvent startGameEv;

        private PauseGame pauseGameScript;

		private GameObject countDownPanel;
        private TextMeshProUGUI countDownText;

        private AudioSource countDownAudio;

        private GameObject inGamePanel;

        private void Awake()
        {
            pauseGameScript = GameObject.Find("Game Manager").GetComponent<PauseGame>();

            countDownPanel = GameObject.Find("Count Down Panel");
            countDownText = countDownPanel.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();

            countDownAudio = GetComponent<AudioSource>();

            inGamePanel = GameObject.Find("In-Game Panel");
        }

        private void Start()
        {
            pauseGameScript.enabled = false;

            countDownText.text = null;

            inGamePanel.SetActive(false);

            StartCoroutine(StartCountDown());
        }

        private IEnumerator StartCountDown()
        {
            countDownAudio.Play();
            countDownText.text = "3";
            yield return new WaitForSeconds(1f);

            countDownAudio.Play();
            countDownText.text = "2";
            yield return new WaitForSeconds(1f);

            countDownAudio.Play();
            countDownText.text = "1";
            yield return new WaitForSeconds(1f);

            countDownAudio.Play();
            countDownText.text = "Let's Go!";
            yield return new WaitForSeconds(1f);

            inGamePanel.SetActive(true);
            pauseGameScript.enabled = true;

            countDownText.text = null;

            startGameEv.Invoke();

            Destroy(gameObject);
        }
    }
}
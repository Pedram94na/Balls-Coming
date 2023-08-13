using UnityEngine;
using System.Collections;

namespace BallsComing
{
	public class PowerUpProgressBar : MonoBehaviour
	{
        private GameObject powerUpProgressPanelChild;
        private Transform powerUpProgressBar;

        private readonly float time = 10f;

        private void Awake()
        {
            powerUpProgressPanelChild = gameObject.transform.GetChild(0).gameObject;
            powerUpProgressBar = powerUpProgressPanelChild.transform.GetChild(0);    
        }

        private void Start()
        {
            powerUpProgressPanelChild.SetActive(false);
        }

        public void StartCoroutineOnProgressBar()
        {
            StartCoroutine(AnimatePowerUpProgressBar());
        }

        private IEnumerator AnimatePowerUpProgressBar()
        {
            powerUpProgressPanelChild.SetActive(true);

            LeanTween.scaleX(powerUpProgressBar.gameObject, 0f, time);

            yield return new WaitForSeconds(time);

            powerUpProgressBar.localScale = new Vector3(1f, powerUpProgressBar.localScale.y, powerUpProgressBar.localScale.z);

            powerUpProgressPanelChild.SetActive(false);
        }
    }
}
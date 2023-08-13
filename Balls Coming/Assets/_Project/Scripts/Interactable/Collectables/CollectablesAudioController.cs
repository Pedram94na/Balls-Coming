using UnityEngine;

namespace BallsComing.Interactable.Collectables
{
	public class CollectablesAudioController : MonoBehaviour
	{
		[SerializeField] private AudioSource coinAudio;
        [SerializeField] private AudioSource powerUpAudio;

        public void PlayCoinAudio()
        {
            coinAudio.Play();
        }

        public void PlayPowerUpAudio()
        {
            powerUpAudio.Play();
        }
    }
}
using UnityEngine;

using BallsComing.Core;

namespace BallsComing
{
	public class InGamePanelMusicController : MonoBehaviour
	{
		private AudioSource inGamePanelAudio;

        private void Awake()
        {
            inGamePanelAudio = GetComponent<AudioSource>();
        }

        public void PlayMusic()
        {
            inGamePanelAudio.Play();
        }

        public void StopMusic()
        {
            inGamePanelAudio.Stop();
        }
    }
}
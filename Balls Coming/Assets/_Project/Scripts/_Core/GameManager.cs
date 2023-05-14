using UnityEngine;

namespace BallsComing.Core
{
	public class GameManager : MonoBehaviour
	{
        [SerializeField] private float powerUpTimer = 10f;

        public enum GameStats
        {
			playing = 0,
			paused = 1,
			gameover = 2
        }
		public static GameStats gameStats;

        public enum PlayerPowerUps
        {
            norm = 0,
            invincibile = 1,
            destroyer = 2
        }
        public static PlayerPowerUps playerPowerUpsStats;

        private void Awake()
        {
            gameStats = GameStats.paused;

            playerPowerUpsStats = PlayerPowerUps.norm;
        }

        #region Game Stats Setters
        public void SetPlayingStat()
        {
            gameStats = GameStats.playing;
        }

        public void SetPauseStat()
        {
            gameStats = GameStats.paused;
        }

        public void SetGameOverStat()
        {
            gameStats = GameStats.gameover;
        }
        #endregion

        #region Player Powerup Stats Setters
        private void SetNormStats()
        {
            playerPowerUpsStats = PlayerPowerUps.norm;
        }

        public void SetInvincibleStats()
        {
            playerPowerUpsStats = PlayerPowerUps.invincibile;

            StartCoroutine(PowerUpRest());
        }

        public void SetDestroyerStats()
        {
            playerPowerUpsStats = PlayerPowerUps.destroyer;

            StartCoroutine(PowerUpRest());
        }

        private System.Collections.IEnumerator PowerUpRest()
        {
            yield return new WaitForSeconds(powerUpTimer);

            SetNormStats();
        }
        #endregion
    }
}
using UnityEngine;

namespace BallsComing.Core
{
	public class GameManager : MonoBehaviour
	{
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
            destroyer = 2,
            slowdown = 3
        }
        public static PlayerPowerUps playerPowerUpsStats;

        public enum PlayerPowerDowns
        {
            norm = 0,
            inputInverter = 1,
            zeroGravity = 2,
            coinLoss = 3
        }
        public static PlayerPowerDowns playerPowerDownsStats;

        private readonly float powerUpTimer = 10f;

        private void Awake()
        {
            gameStats = GameStats.paused;

            playerPowerUpsStats = PlayerPowerUps.norm;
            playerPowerDownsStats = PlayerPowerDowns.norm;
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
        public void SetInvincibleStats()
        {
            playerPowerUpsStats = PlayerPowerUps.invincibile;

            StartCoroutine(PowerUpReset());
        }

        public void SetDestroyerStats()
        {
            playerPowerUpsStats = PlayerPowerUps.destroyer;

            StartCoroutine(PowerUpReset());
        }

        public void SetSlowdownStats()
        {
            playerPowerUpsStats = PlayerPowerUps.slowdown;

            StartCoroutine(PowerUpReset());
        }

        private System.Collections.IEnumerator PowerUpReset()
        {
            yield return new WaitForSeconds(powerUpTimer);

            playerPowerUpsStats = PlayerPowerUps.norm;
        }
        #endregion

        #region Player Powerup Stats Setters
        public void SetInputInverter()
        {
            playerPowerDownsStats = PlayerPowerDowns.inputInverter;

            StartCoroutine(PowerDownReset());
        }

        public void SetZeroGravity()
        {
            playerPowerDownsStats = PlayerPowerDowns.zeroGravity;

            StartCoroutine(PowerDownReset());
        }

        public void SetCoinLoss()
        {
            playerPowerDownsStats = PlayerPowerDowns.coinLoss;

            StartCoroutine(PowerDownReset());
        }

        private System.Collections.IEnumerator PowerDownReset()
        {
            yield return new WaitForSeconds(powerUpTimer);

            playerPowerDownsStats = PlayerPowerDowns.norm;
        }
        #endregion
    }
}
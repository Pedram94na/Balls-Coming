using UnityEngine;
using UnityEngine.Events;

using System.Collections;

namespace BallsComing.Core
{
	public class GameManager : MonoBehaviour
	{
        [SerializeField] private UnityEvent InvincibilityEffectEve;

        [SerializeField] private UnityEvent powerUpEndsEve;
        [SerializeField] private UnityEvent powerUpProgressBarEve;

        public enum GameState
        {
			playing = 0,
			paused = 1,
			gameover = 2
        }
        public static GameState gameState;

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
            gameState = GameState.paused;

            playerPowerUpsStats = PlayerPowerUps.norm;
            playerPowerDownsStats = PlayerPowerDowns.norm;
        }

        #region Game Stats Setters
        public void SetPlayingStat()
        {
            gameState = GameState.playing;
        }

        public void SetPauseStat()
        {
            gameState = GameState.paused;
        }

        public void SetGameOverStat()
        {
            gameState = GameState.gameover;
        }
        #endregion

        #region Player Powerup Stats Setters
        public void SetInvincibleStats()
        {
            playerPowerUpsStats = PlayerPowerUps.invincibile;

            InvincibilityEffectEve.Invoke();

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

        private IEnumerator PowerUpReset()
        {
            powerUpProgressBarEve.Invoke();

            yield return new WaitForSeconds(powerUpTimer);

            powerUpEndsEve.Invoke();
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

        private IEnumerator PowerDownReset()
        {
            yield return new WaitForSeconds(powerUpTimer);

            playerPowerDownsStats = PlayerPowerDowns.norm;
        }
        #endregion
    }
}
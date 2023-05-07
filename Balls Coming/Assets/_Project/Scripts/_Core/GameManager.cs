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

        private void Awake()
        {
            gameStats = GameStats.paused;
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
    }
}
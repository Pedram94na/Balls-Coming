using UnityEngine;

using BallsComing.Core;

namespace BallsComing.Player
{
	public class PlayerMovement : MonoBehaviour
	{
        private float speed = 10f;

        public enum PlayerMovementStats
        {
            idle = 0,
            moving = 1,
        }
        public static PlayerMovementStats playerMovementStats;

        private void Awake()
        {
            playerMovementStats = PlayerMovementStats.idle;
        }

        private void Update()
        {
            if (GetGameStats() != 2) InputCheck(GetMovementDirection());
        }

        private void InputCheck(float x)
        {
            if (x != 0) Move(x);

            if (x == 0) playerMovementStats = PlayerMovementStats.idle;
        }

        private void Move(float x)
        {
            Vector3 move = speed * Time.deltaTime * x * Vector3.right;
            transform.Translate(move);

            playerMovementStats = PlayerMovementStats.moving;
        }

        public void PlayerSpeedChange()
        {
            speed = 20f;
        }

        public void RestorePlayerSpeed()
        {
            speed = 10f;
        }

        #region Getters
        private static float GetMovementDirection() { return InputManager.Instance.HorizontalInput(); }

        private int GetGameStats() { return (int)GameManager.gameState; }
        #endregion
    }
}
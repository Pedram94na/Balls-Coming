using UnityEngine;

using BallsComing.Core;

namespace BallsComing.Player
{
	public class PlayerJumpingAnimation : MonoBehaviour
	{
        private bool IsJumping => PlayerJumpStatsGetter() == 1;
        private bool MovingRight => GetMovementDirection() >= 0;

        [SerializeField] private float rotationSpeed = 300f;

        private void Update()
        {
            if (IsJumping)  AnimateJump();
        }

        private void AnimateJump()
        {
            float zRotation = rotationSpeed * Time.deltaTime;

            if (!MovingRight) transform.Rotate(0, 0, zRotation);

            else transform.Rotate(0, 0, -zRotation);
        }

        #region Getters
        private static float GetMovementDirection() { return InputManager.Instance.HorizontalInput(); }

        private int PlayerJumpStatsGetter() { return (int)PlayerJump.playerJumpStats; }
        #endregion
    }
}
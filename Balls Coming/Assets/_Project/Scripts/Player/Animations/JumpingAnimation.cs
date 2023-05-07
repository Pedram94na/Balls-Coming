using UnityEngine;

namespace BallsComing.Player.Animations
{
	public class JumpingAnimation : MonoBehaviour
	{
        private bool IsJumping => PlayerJumpStatsGetter() == 1;
        private bool MovingRight => Input.GetAxis("Horizontal") >= 0;

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

        private int PlayerJumpStatsGetter() { return (int)PlayerJump.playerJumpStats; }
    }
}
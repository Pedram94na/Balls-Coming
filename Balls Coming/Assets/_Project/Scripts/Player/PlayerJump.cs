using UnityEngine;

using BallsComing.Core;

namespace BallsComing.Player
{
	public class PlayerJump : MonoBehaviour
	{
        private bool CanJump => IsJumping() && isGrounded;

        [SerializeField] private float jumpForce = 300f;

        private Rigidbody playerRb;
        private bool isGrounded = true;

        public enum PlayerJumpStats
        {
            grounded = 0,
            jumping = 1,
        }
        public static PlayerJumpStats playerJumpStats;

        private Transform playerGraphicsTr;

        private void Awake()
        {
            playerRb = GetComponent<Rigidbody>();
            playerJumpStats = PlayerJumpStats.grounded;

            playerGraphicsTr = transform.GetChild(0);
        }

        private void FixedUpdate()
        {
            if (GetGameStats() == 2) playerRb.constraints = RigidbodyConstraints.FreezePositionY;

            if (CanJump) Jump();
        }

        private void Jump()
        {
            isGrounded = false;
            playerJumpStats = PlayerJumpStats.jumping;

            playerRb.AddForce(jumpForce * Time.deltaTime * Vector3.up, ForceMode.Impulse);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;

                playerJumpStats = PlayerJumpStats.grounded;

                transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0f, 0f);
                playerGraphicsTr.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0f, 0f);
            }
        }

        #region Getters
        private int GetGameStats() { return (int)GameManager.gameState; }

        private static bool IsJumping() { return InputManager.Instance.JumpingInput(); }
        #endregion
    }
}
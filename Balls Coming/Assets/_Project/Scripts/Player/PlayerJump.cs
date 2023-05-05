using UnityEngine;

namespace BallsComing.Player
{
	public class PlayerJump : MonoBehaviour
	{
        private bool IsJumping => Input.GetButton("Jump") == true;

        [SerializeField] private float jumpForce = 300f;

        private Rigidbody playerRb;
        private bool isGrounded = true;

        public enum PlayerJumpStats
        {
            idle = 0,
            jumping = 1,
            falling = 2
        }
        public static PlayerJumpStats playerJumpStats;

        private void Awake()
        {
            playerRb = GetComponent<Rigidbody>();
            playerJumpStats = PlayerJumpStats.idle;
        }

        private void FixedUpdate()
        {
            Jumping();
        }

        private void Jumping()
        {
            if (IsJumping && isGrounded)
            {
                isGrounded = false;
                playerJumpStats = PlayerJumpStats.jumping;

                playerRb.AddForce(jumpForce * Time.deltaTime * Vector3.up, ForceMode.Impulse);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "Ground")
            {
                isGrounded = true;
                playerJumpStats = PlayerJumpStats.idle;
            }
        }
    }
}
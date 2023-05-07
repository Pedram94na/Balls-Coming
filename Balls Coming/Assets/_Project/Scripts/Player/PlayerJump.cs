using UnityEngine;

namespace BallsComing.Player
{
	public class PlayerJump : MonoBehaviour
	{
        private bool CanJump => Input.GetButton("Jump") && isGrounded;
        private bool IsJumping => playerJumpStats == PlayerJumpStats.jumping;

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

            playerGraphicsTr = GameObject.Find("Player GFX").transform;
        }

        private void FixedUpdate()
        {
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
            if (collision.gameObject.name == "Ground")
            {
                isGrounded = true;

                playerJumpStats = PlayerJumpStats.grounded;

                playerGraphicsTr.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0f, 0f);
            }
        }
    }
}
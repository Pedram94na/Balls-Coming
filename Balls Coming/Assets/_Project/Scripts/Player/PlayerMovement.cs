using UnityEngine;

namespace BallsComing.Player
{
	public class PlayerMovement : MonoBehaviour
	{
        private bool IsDashing => Input.GetButton("Dash");
        [SerializeField] private float speed = 10f;

        public enum PlayerMovementStats
        {
            idle = 0,
            slow = 1,
            fast = 2
        }
        public static PlayerMovementStats playerMovementStats;

        private void Awake()
        {
            playerMovementStats = PlayerMovementStats.idle;
        }

        private void Update()
        {
            InputCheck();
        }

        private void InputCheck()
        {
            SpeedSetter();

            float x = Input.GetAxis("Horizontal");

            if (x != 0) Movement(x);

            if (x == 0) playerMovementStats = PlayerMovementStats.idle;
        }

        private Vector3 Movement(float x)
        {
            Vector3 move = speed * Time.deltaTime * x * Vector3.right;
            transform.Translate(move);

            return move;
        }

        private float SpeedSetter()
        {
            if (IsDashing)
            {
                speed = 20f;
                playerMovementStats = PlayerMovementStats.fast;

                return speed;
            }
            
            speed = 10f;
            playerMovementStats = PlayerMovementStats.slow;

            return speed;
        }
    }
}
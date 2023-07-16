using UnityEngine;

namespace BallsComing.Player
{
	public class PlayerMovement : MonoBehaviour
	{
        [SerializeField] private float speed = 10f;

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
            InputCheck();
        }

        private void InputCheck()
        {
            float x = Input.GetAxis("Horizontal");

            if (x != 0) Move(x);

            if (x == 0) playerMovementStats = PlayerMovementStats.idle;
        }

        private Vector3 Move(float x)
        {
            if (PlayerPowerDownGetter() == 1) x = -x;

            speed = 10f;

            Vector3 move = speed * Time.deltaTime * x * Vector3.right;
            transform.Translate(move);

            playerMovementStats = PlayerMovementStats.moving;

            return move;
        }

        private int PlayerPowerDownGetter() { return (int)Core.GameManager.playerPowerDownsStats; }
    }
}
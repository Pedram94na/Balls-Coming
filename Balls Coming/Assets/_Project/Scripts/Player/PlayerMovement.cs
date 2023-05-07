using UnityEngine;
using System.Collections;

namespace BallsComing.Player
{
	public class PlayerMovement : MonoBehaviour
	{
        private bool IsDashing => Input.GetButton("Dash") && dashReady;

        [SerializeField] private float speed = 10f;
        private bool dashReady = true;

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

            if (x != 0) Move(x);

            if (x == 0) playerMovementStats = PlayerMovementStats.idle;
        }

        private float SpeedSetter()
        {
            if (IsDashing)
            {
                StartCoroutine(DashCoolDown());
                speed = 20f;
                playerMovementStats = PlayerMovementStats.fast;

                return speed;
            }
            
            speed = 10f;
            playerMovementStats = PlayerMovementStats.slow;

            return speed;
        }

        private IEnumerator DashCoolDown()
        {
            yield return new WaitForSeconds(1f);
            dashReady = false;
            yield return new WaitForSeconds(1f);
            dashReady = true;
        }

        private Vector3 Move(float x)
        {
            Vector3 move = speed * Time.deltaTime * x * Vector3.right;
            transform.Translate(move);

            return move;
        }
    }
}
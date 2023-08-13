using UnityEngine;

namespace BallsComing.Player
{
	public class PlayerBoundaries : MonoBehaviour
	{
        private void Update()
        {
            SetBoundary();
        }

        private void SetBoundary()
        {
            float boundX = 8.7f;
            float clampedX = Mathf.Clamp(transform.position.x, -boundX, boundX);

            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
        }
    }
}
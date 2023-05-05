using UnityEngine;

namespace BallsComing.Player
{
	public class PlayerBoundaries : MonoBehaviour
	{
        private void Update()
        {
            SetBounday();
        }

        private void SetBounday()
        {
            float boundX = 10f;
            float clampedX = Mathf.Clamp(transform.position.x, -boundX, boundX);

            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
        }
    }
}
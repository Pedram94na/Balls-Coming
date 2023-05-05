using UnityEngine;

namespace BallsComing.Balls
{
	public class BallsFalling : MonoBehaviour
	{
		[SerializeField] float speed;

        private void Awake()
        {
            if (this.CompareTag("Ball1")) speed = 10f;
            if (this.CompareTag("Ball2")) speed = 5f;
            if (this.CompareTag("Ball3")) speed = 3f;
        }

        private void Update()
        {
            Fall();
        }

        private void Fall()
        {
            transform.Translate(speed * Time.deltaTime * Vector3.down);
        }
    }
}
using UnityEngine;

namespace BallsComing.Balls
{
	public class BallsDespawner : MonoBehaviour
	{
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "Ground") Destroy(this.gameObject);

            if (collision.gameObject.CompareTag("Player"))
            {
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
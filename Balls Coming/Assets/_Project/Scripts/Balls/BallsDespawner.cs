using UnityEngine;
using UnityEngine.Events;

namespace BallsComing.Balls
{
	public class BallsDespawner : MonoBehaviour
	{
        [SerializeField] private UnityEvent GameOverEv;

        private GameObject ballsOriginal;

        private void Awake()
        {
            ballsOriginal = GameObject.Find("Balls Original");
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "Ground") Destroy(this.gameObject);

            if (collision.gameObject.CompareTag("Player"))
            {
                GameOverEv.Invoke();

                Destroy(ballsOriginal);
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
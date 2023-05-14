using UnityEngine;
using UnityEngine.Events;

namespace BallsComing.Balls
{
	public class BallsDespawner : MonoBehaviour
	{
        private bool IsFallingBall => gameObject.CompareTag("Ball1")|| gameObject.CompareTag("Ball2") || gameObject.CompareTag("Ball3");

        [SerializeField] private UnityEvent GameOverEv;

        private GameObject ballsOriginalFalling;
        private GameObject ballsOriginalRolling;
        private GameObject collectablesOriginal;

        private void Awake()
        {
            ballsOriginalFalling = GameObject.Find("Balls Original Falling");
            ballsOriginalRolling = GameObject.Find("Balls Original Rolling");
            collectablesOriginal = GameObject.Find("Collectables Original");
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (IsFallingBall && collision.gameObject.name == "Ground") Destroy(gameObject);

            if (collision.gameObject.CompareTag("Player"))
            {
                int i = PlayerPowerupsGetter();
                switch (i)
                {
                    case 0:
                        GameOverEv.Invoke();

                        Destroy(ballsOriginalFalling);
                        Destroy(ballsOriginalRolling);
                        Destroy(collectablesOriginal);

                        Destroy(collision.gameObject);
                        Destroy(gameObject);

                        break;

                    case 2:
                        Destroy(gameObject);

                        break;
                }
            }
        }

        private int PlayerPowerupsGetter() { return (int)Core.GameManager.playerPowerUpsStats; }
    }
}
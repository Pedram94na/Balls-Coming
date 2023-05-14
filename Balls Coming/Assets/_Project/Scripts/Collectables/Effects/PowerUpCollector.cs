using UnityEngine;
using UnityEngine.Events;

namespace BallsComing.Collectables.Effects
{
	public class PowerUpCollector : MonoBehaviour
	{
        [SerializeField] private UnityEvent PowerUpEve;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "Ground") Destroy(this.gameObject);

            if (collision.gameObject.CompareTag("Player"))
            {
                CollectableCheck();

                Destroy(this.gameObject);
            }
        }

        private void CollectableCheck()
        {
            if (this.gameObject.CompareTag("Invincibility Power"))
                PowerUpEve.Invoke();

            if (this.gameObject.CompareTag("Ball Destroyer"))
                PowerUpEve.Invoke();
        }
    }
}
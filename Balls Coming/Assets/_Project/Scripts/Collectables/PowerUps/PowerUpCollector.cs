using UnityEngine;

namespace BallsComing.Collectables.PowerUps
{
	public class PowerUpCollector : MonoBehaviour
	{
        public enum PowerUpStats
        {
            norm = 0,
            invincible = 1,
            destroyBalls = 2
        }
        public static PowerUpStats powerUpStats;

        private void Awake()
        {
            powerUpStats = PowerUpStats.norm;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "Ground") Destroy(this.gameObject);

            if (collision.gameObject.CompareTag("Player"))
            {
                CollectableCheck();

                Destroy(this.gameObject);
            }
        }

        private PowerUpStats CollectableCheck()
        {
            if (this.gameObject.CompareTag("Invincibility Power"))
            {
                powerUpStats = PowerUpStats.invincible;

                return powerUpStats;
            }

            if (this.gameObject.CompareTag("Ball Destroyer"))
            {
                powerUpStats = PowerUpStats.destroyBalls;

                return powerUpStats;
            }

            // Add coin

            return powerUpStats;
        }
    }
}
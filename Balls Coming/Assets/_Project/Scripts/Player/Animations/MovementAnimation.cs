using UnityEngine;

namespace BallsComing.Player.Animations
{
	public class MovementAnimation : MonoBehaviour
	{
		private ParticleSystem dustParticle;

        private void Start()
        {
            dustParticle = GetComponent<ParticleSystem>();
            dustParticle.Stop();
        }

        private void Update()
        {
            int i = PlayerMovementStatsGetter();
            Debug.Log(i);
            switch (i)
            {
                case 0:
                    dustParticle.Stop();

                    break;

                case 1:
                case 2:
                    dustParticle.Play();

                    break;

                default:
                    break;
            }
        }

        private int PlayerMovementStatsGetter() { return (int)PlayerMovement.playerMovementStats; }
    }
}
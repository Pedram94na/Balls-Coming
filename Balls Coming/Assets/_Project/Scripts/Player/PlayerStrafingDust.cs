using UnityEngine;

namespace BallsComing.Player
{
	public class PlayerStrafingDust : MonoBehaviour
	{
		private ParticleSystem dustParticle;

        private void Awake()
        {
            dustParticle = GetComponent<ParticleSystem>();
        }

        private void Start()
        {
            dustParticle.Stop();
        }

        private void Update()
        {
            MovementCheck();
        }

        private void MovementCheck()
        {
            int i = GetPlayerMovementStats();
            switch (i)
            {
                case 0:
                    dustParticle.Stop();

                    break;

                case 1:
                    JumpingCheck();

                    break;

                default:
                    break;
            }
        }

        private void JumpingCheck()
        {
            if (GetPlayerJumpStats() == 0)  dustParticle.Play();
        }

        #region Getters
        private int GetPlayerMovementStats() { return (int)PlayerMovement.playerMovementStats; }

        private int GetPlayerJumpStats() { return (int)PlayerJump.playerJumpStats; }
        #endregion
    }
}
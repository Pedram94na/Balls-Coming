using UnityEngine;

namespace BallsComing.Player.Animations
{
	public class JumpingAnimation : MonoBehaviour
	{
        private void Update()
        {
            int i = PlayerJumpStatsGetter();
            switch (i)
            {
                case 0:
                    break;

                case 1:
                    transform.Rotate(0, 0, 60f * Time.deltaTime);

                    break;

                case 2:

                    break;

                default:
                    break;
            }
        }

        private int PlayerJumpStatsGetter() { return (int)PlayerJump.playerJumpStats; }
    }
}
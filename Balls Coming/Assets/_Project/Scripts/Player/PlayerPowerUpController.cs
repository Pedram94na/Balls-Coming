using UnityEngine;
using System.Collections;

namespace BallsComing.Player
{
	public class PlayerPowerUpController : MonoBehaviour
	{
		public enum PlayerPowerUps
        {
			norm = 0,
			invincibile = 1,
			destroyer = 2
		}
		public static PlayerPowerUps playerPowerUps;

        private void Awake()
        {
			playerPowerUps = PlayerPowerUps.norm;
        }
    }
}
using UnityEngine;

using BallsComing.Interactable.Balls.BallsData;

namespace BallsComing.Interactable.Balls
{
	public class OtherBallsCollision : MonoBehaviour
	{
		private BallsParent ball;

        private void Awake()
        {
            ball = GetBallInstance();
        }

        private BallsParent GetBallInstance()
        {
            BallsParent ball = name.Split(" ")[0] switch
            {
                "Red" => RedBall.GetInstance(),

                "Green" => GreenBall.GetInstance(),

                "Yellow" => YellowBall.GetInstance(),

                "Blue" => BlueBall.GetInstance(),

                _ => null,
            };

            return ball;
        }

        private void OnCollisionEnter(Collision collision)
        {
            bool redBallCollisionCheck = !BlueBallCollisionCheck(collision.gameObject.name.Split(" ")[0]) && RedBallCollisionCheck(collision.gameObject.name.Split(" ")[0]);

            bool greenBallCollisionCheck = !YellowBallCollisionCheck(collision.gameObject.name.Split(" ")[0]) && !BlueBallCollisionCheck(collision.gameObject.name.Split(" ")[0]) && GreenBallCollisionCheck(collision.gameObject.name.Split(" ")[0]);

            bool blueBallCollisionCheck = BlueBallCollisionCheck(collision.gameObject.name.Split(" ")[0]);

            if (redBallCollisionCheck) Destroy(collision.gameObject);

            if (greenBallCollisionCheck) Destroy(collision.gameObject);

            if (blueBallCollisionCheck)   Destroy(collision.gameObject);
        }

        #region Getters
        private bool RedBallCollisionCheck(string collidedBallName) { return ball.CheckRedBallCollision(collidedBallName); }

        private bool GreenBallCollisionCheck(string collidedBallName) { return ball.CheckGreenBallCollision(collidedBallName); }

        private bool YellowBallCollisionCheck(string collidedBallName) { return ball.CheckYellowBallCollision(collidedBallName); }

        private bool BlueBallCollisionCheck(string collidedBallName) { return ball.CheckBlueBallCollision(collidedBallName); }
        #endregion
    }
}
using UnityEngine;

namespace BallsComing.Balls.Falling
{
	public class FallingBallsSpawner : MonoBehaviour
	{
		private GameObject[] ballsArr;
        private int ballsArrLength;

        private void Awake()
        {
            BallsArrSetter();
        }

        private void BallsArrSetter()
        {
            ballsArrLength = gameObject.transform.childCount;
            ballsArr = new GameObject[ballsArrLength];

            for (int i = 0; i < ballsArrLength; i++)
                ballsArr[i] = gameObject.transform.GetChild(i).gameObject;
        }

        private void Start()
        {
            InvokeRepeating(nameof(SpawnBalls), 5f, 1f);
        }

        private void SpawnBalls()
        {
            int ballsArrIndex = Random.Range(0, ballsArrLength);
            GameObject newBall = ballsArr[ballsArrIndex];

            float spawnPosX = Random.Range(-10f, 10f);
            float spawnPosY = 7f;
            Vector3 spawnPos = new(spawnPosX, spawnPosY, 0);

            Quaternion spawnRot = transform.rotation;

            Instantiate(newBall, spawnPos, spawnRot);
        }
    }
}
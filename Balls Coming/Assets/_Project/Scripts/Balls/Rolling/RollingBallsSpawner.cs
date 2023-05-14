using UnityEngine;

namespace BallsComing.Balls.Rolling
{
	public class RollingBallsSpawner : MonoBehaviour
	{
        private GameObject ball4;

        private void Awake()
        {
            ball4 = GameObject.Find("Ball4");
        }

        private void Start()
        {
            InvokeRepeating(nameof(SpawnBalls), 5f, 3f);
        }

        private void SpawnBalls()
        {
            float spawnPosX = 12f;
            float spawnPosY = -3.8f;
            Vector3 spawnPos = new(spawnPosX, spawnPosY, 0);

            Quaternion spawnRot = transform.rotation;

            Instantiate(ball4, spawnPos, spawnRot);
        }
    }
}
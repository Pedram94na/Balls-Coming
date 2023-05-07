using UnityEngine;

namespace BallsComing.Collectables.PowerUps
{
	public class PowerUpSpawner : MonoBehaviour
	{
        private GameObject[] powerUpsArr;
        private int powerUpsArrLength;

        private void Awake()
        {
            CollectablesArrSetter();
        }

        private void CollectablesArrSetter()
        {
            powerUpsArrLength = gameObject.transform.childCount - 1;
            powerUpsArr = new GameObject[powerUpsArrLength];

            for (int i = 0; i < powerUpsArrLength; i++)
                powerUpsArr[i] = gameObject.transform.GetChild(i).gameObject;

            for (int i = 0; i < powerUpsArrLength; i++)
                Debug.Log(powerUpsArr[i].name);
        }

        private void Start()
        {
            InvokeRepeating(nameof(SpawnpowerUps), 5f, 1f);
        }

        private void SpawnpowerUps()
        {
            int powerUpsArrIndex = Random.Range(0, powerUpsArrLength);
            GameObject newpowerUp = powerUpsArr[powerUpsArrIndex];

            float spawnPosX = Random.Range(-10f, 10f);
            float spawnPosY = 7f;
            Vector3 spawnPos = new(spawnPosX, spawnPosY, 0);

            Quaternion spawnRot = transform.rotation;

            Instantiate(newpowerUp, spawnPos, spawnRot);
        }
    }
}
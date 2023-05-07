using UnityEngine;

namespace BallsComing.Collectables.Coins
{
	public class CoinSpawner : MonoBehaviour
	{
		private GameObject coin;

        private void Awake()
        {
            coin = transform.Find("Coin").gameObject;
        }

        private void Start()
        {
            InvokeRepeating(nameof(SpawnCoins), 5f, 3f);
        }

        private void SpawnCoins()
        {
            float spawnPosX = Random.Range(-10f, 10f);
            float spawnPosY = 7f;
            Vector3 spawnPos = new(spawnPosX, spawnPosY, 0);

            Quaternion spawnRot = transform.rotation;

            Instantiate(coin, spawnPos, spawnRot);
        }
    }
}
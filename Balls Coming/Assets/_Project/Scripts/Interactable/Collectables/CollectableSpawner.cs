using UnityEngine;

using BallsComing.Interactable.Collectables.CollectablesData;

namespace BallsComing.Interactable.Collectables
{
	public class CollectableSpawner : MonoBehaviour
	{
        private readonly CollectablesParent collectables;

        private CollectablesParent[] collectablesArr;
        private int collectablesArrLength;

        private CollectablesParent newCollectables;

        private Transform spawnsTr;

        private void Awake()
        {
            SetBallsArr();

            spawnsTr = GameObject.Find("Spawns").transform;
        }

        private void SetBallsArr()
        {
            collectablesArrLength = transform.childCount;
            collectablesArr = new CollectablesParent[collectablesArrLength];

            for (int i = 0; i < collectablesArrLength; i++)
            {
                GameObject collectableObj = gameObject.transform.GetChild(i).gameObject;

                collectablesArr[i] = CreatingCollectables(collectableObj);
            }
        }

        private CollectablesParent CreatingCollectables(GameObject collectableObj)
        {
            string name = collectableObj.name;

            return name switch
            {
                "Coin" => Coin.Instance(collectableObj, 5f),

                "Invincibility" => Invincibility.Instance(collectableObj, 5f),

                "Destroyer" => Destroyer.Instance(collectableObj, 5f),

                "Slowdown" => Slowdown.Instance(collectableObj, 5f),

                _ => null,
            };
        }

        private void Start()
        {
            InvokeRepeating(nameof(SpawnCoins), 5f, 3f);
            InvokeRepeating(nameof(SpawnPowerups), 30f, 50f);
        }

        private void SpawnCoins()
        {
            newCollectables = collectablesArr[0];

            if (newCollectables != null)
            {
                newCollectables.SpawnPreparation(out Vector3 spawnPos, out Quaternion spawnRot);

                GameObject newCollectableObj = Instantiate(newCollectables.GetCollectableObj(), spawnPos, spawnRot);
                newCollectableObj.transform.parent = spawnsTr;
            }
        }

        private void SpawnPowerups()
        {
            int collectablesArrIndex = Random.Range(1, collectablesArrLength);
            newCollectables = collectablesArr[collectablesArrIndex];

            if (newCollectables != null)
            {
                newCollectables.SpawnPreparation(out Vector3 spawnPos, out Quaternion spawnRot);

                GameObject newCollectableObj = Instantiate(newCollectables.GetCollectableObj(), spawnPos, spawnRot);
                newCollectableObj.transform.parent = spawnsTr;
            }
        }
    }
}
using UnityEngine;

using BallsComing.Interactable.Collectables.CollectablesData;

namespace BallsComing.Interactable.Collectables
{
	public class CollectablesMovement : MonoBehaviour
	{
        private bool ExcludingOriginals => OriginalBallsCheck();
        private bool OriginalBallsCheck()
        {
            try
            {
                return gameObject != originalCollectablesArr[0] && gameObject != originalCollectablesArr[1] && gameObject != originalCollectablesArr[2];
            }
            catch
            {
                return true;
            }
        }

        private CollectablesParent collectables;

        private static GameObject[] originalCollectablesArr;

        private void Awake()
        {
            SetOriginalBallsArray();
        }

        private static void SetOriginalBallsArray()
        {
            Transform originalCollectablesTr = GameObject.Find("Collectables Original").transform;

            int originalCollectablesArrLength = originalCollectablesTr.childCount;
            originalCollectablesArr = new GameObject[originalCollectablesArrLength];

            for (int i = 0; i < originalCollectablesArrLength; i++)
                originalCollectablesArr[i] = originalCollectablesTr.GetChild(i).gameObject;
        }

        private void Start()
        {
            if (ExcludingOriginals) GetCollectablesInstance();
        }

        private void GetCollectablesInstance()
        {
            collectables = name.Split("(")[0] switch
            {
                "Coin" => Coin.GetInstance(),

                "Invincibility" => Invincibility.GetInstance(),

                "Destroyer" => Destroyer.GetInstance(),

                "Slowdown" => Slowdown.GetInstance(),

                _ => null,
            };
        }

        private void Update()
        {
            if (ExcludingOriginals) MoveCollectables();
        }

        private void MoveCollectables()
        {
            transform.Translate(collectables.Move());
        }
    }
}
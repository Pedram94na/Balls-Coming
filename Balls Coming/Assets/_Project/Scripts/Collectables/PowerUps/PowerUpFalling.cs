using UnityEngine;

namespace BallsComing.Collectables.PowerUps
{
	public class PowerUpFalling : MonoBehaviour
	{
        private bool ExcludingOriginals => OriginalPowerUpsCheck();

        [SerializeField] float speed = 5f;
        [SerializeField] float speedAddition = 2f;

        private static GameObject[] originalPowerUpsArr;

        private void Awake()
        {
            SetOriginalPowerUpsArray();
        }

        private static void SetOriginalPowerUpsArray()
        {
            Transform originalCollectablesTr = GameObject.Find("Collectables Original").transform;

            int originalPowerUpsArrLength = originalCollectablesTr.childCount;
            originalPowerUpsArr = new GameObject[originalPowerUpsArrLength];

            for (int i = 0; i < originalPowerUpsArrLength; i++)
                originalPowerUpsArr[i] = originalCollectablesTr.GetChild(i).gameObject;
        }

        private bool OriginalPowerUpsCheck()
        {
            try
            {
                return gameObject.name != originalPowerUpsArr[0].name && gameObject.name != originalPowerUpsArr[1].name && gameObject.name != originalPowerUpsArr[2].name;
            }
            catch
            {
                return true;
            }
        }

        private void Update()
        {
            if (ExcludingOriginals) Fall();
        }

        private void Fall()
        {
            transform.Translate(speed * Time.deltaTime * Vector3.down);
        }

        public void UpgradeSpeed()
        {
            speed += speedAddition;
        }
    }
}
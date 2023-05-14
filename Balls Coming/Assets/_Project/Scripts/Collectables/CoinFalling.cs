using UnityEngine;

namespace BallsComing.Collectables
{
	public class CoinFalling : MonoBehaviour
	{
        private bool ExcludingOriginals => OriginalCoinsCheck();

        [SerializeField] float speed = 5f;
        [SerializeField] float speedAddition = 2f;

        private static GameObject originalCoin;

        private void Awake()
        {
            SetOriginalCoinsArray();
        }

        private static void SetOriginalCoinsArray()
        {
            Transform originalCollectablesTr = GameObject.Find("Collectables Original").transform;

            originalCoin = originalCollectablesTr.Find("Coin").gameObject;
        }

        private bool OriginalCoinsCheck()
        {
            try
            {
                return gameObject.name != originalCoin.name;
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
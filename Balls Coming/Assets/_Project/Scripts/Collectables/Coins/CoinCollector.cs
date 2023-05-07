using UnityEngine;
using UnityEngine.Events;

namespace BallsComing.Collectables.Coins
{
	public class CoinCollector : MonoBehaviour
	{
        [SerializeField] private UnityEvent coinCollectionEv;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "Ground") Destroy(this.gameObject);

            if (collision.gameObject.CompareTag("Player"))
            {
                coinCollectionEv.Invoke();

                Destroy(this.gameObject);
            }
        }
    }
}
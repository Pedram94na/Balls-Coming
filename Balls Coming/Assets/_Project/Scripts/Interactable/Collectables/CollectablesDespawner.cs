using UnityEngine;
using UnityEngine.Events;

using BallsComing.Interactable.Collectables.CollectablesData;

namespace BallsComing.Interactable.Collectables
{
	public class CollectablesDespawner : MonoBehaviour
	{
        [SerializeField] private UnityEvent collectabelEve;

        private CollectablesParent collectable;

        private void Awake()
        {
            GetCollectablesInstance();
        }
        
        private void GetCollectablesInstance()
        {
            collectable = name.Split("(")[0] switch
            {
                "Coin" => Coin.GetInstance(),

                "Invincibility" => Invincibility.GetInstance(),

                "Destroyer" => Destroyer.GetInstance(),

                "Slowdown" => Slowdown.GetInstance(),

                _ => null,
            };
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground")) Destroy(gameObject);

            if (collision.gameObject.CompareTag("Player"))
            {
                collectabelEve.Invoke();

                Destroy(gameObject);
            }
        }
    }
}
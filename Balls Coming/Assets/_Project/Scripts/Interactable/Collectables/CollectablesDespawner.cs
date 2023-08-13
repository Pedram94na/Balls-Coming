using UnityEngine;
using UnityEngine.Events;

namespace BallsComing.Interactable.Collectables
{
	public class CollectablesDespawner : MonoBehaviour
	{
        [SerializeField] private UnityEvent collectableEve;
        
        private AudioSource collectableAudio;

        private void Awake()
        {
            collectableAudio = GetComponent<AudioSource>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground")) Destroy(gameObject);

            if (collision.gameObject.CompareTag("Player"))
            {
                collectableEve.Invoke();

                Destroy(gameObject);
            }
        }
    }
}
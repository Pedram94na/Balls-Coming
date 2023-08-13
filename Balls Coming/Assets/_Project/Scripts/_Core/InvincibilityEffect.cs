using UnityEngine;
using UnityEngine.Events;

namespace BallsComing.Core
{
	public class InvincibilityEffect : MonoBehaviour
	{
        [SerializeField] private Material playerMat;
        [SerializeField] private Texture invincibleTexture;

        [SerializeField] private UnityEvent InvincibilityStartsEve;
        [SerializeField] private UnityEvent InvincibilityEndsEve;

        private Texture originalTexture;

        private void Awake()
        {
            originalTexture = playerMat.mainTexture;
        }

        public void InvincibleTexture()
        {
            playerMat.mainTexture = invincibleTexture;

            InvincibilityStartsEve.Invoke();
        }

        public void RestoreOriginalTexture()
        {
            playerMat.mainTexture = originalTexture;

            InvincibilityEndsEve.Invoke();
        }
    }
}
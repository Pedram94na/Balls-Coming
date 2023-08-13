using UnityEngine;

namespace BallsComing.Interactable.Collectables.CollectablesData
{
	public abstract class CollectablesParent
	{
		protected GameObject collectable;
        protected float speed = 5f;

		public CollectablesParent(GameObject collectable, float speed)
        {
            SetFields(collectable, speed);
        }

        public CollectablesParent() { }

        public void SetFields(GameObject collectable, float speed)
        {
            this.collectable = collectable;
            this.speed = speed;
        }

        #region Getters
        public GameObject GetCollectableObj() { return collectable; }

        public float GetCollectableSpeed() { return speed; }
        #endregion

        public void SpawnPreparation(out Vector3 spawnPos, out Quaternion spawnRot)
        {
            float spawnPosX = Random.Range(-8.7f, 8.7f);
            float spawnPosY = 7f;
            spawnPos = new Vector3(spawnPosX, spawnPosY, 0);

            spawnRot = Quaternion.identity;
        }

        public Vector3 Move() { return speed * Time.deltaTime * Vector3.down; }

        public void UpgradeSpeed() { speed += 1; }

        #region Checkers
        public virtual bool IsCoin() { return false; }

        public virtual bool IsInvincibility() { return false; }

        public virtual bool IsDestroyer() { return false; }

        public virtual bool IsSlowedowner() { return false; }
        #endregion
    }
}
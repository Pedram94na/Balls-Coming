using UnityEngine;
using System.Collections.Generic;

namespace BallsComing.Interactable.Balls.BallsData
{
    public abstract class BallsParent
    {
        protected static HashSet<string> otherBallCollisionSet = new()
        {
            "Red",
            "Green",
            "Yellow",
            "Coin(Clone)",
            "Invincibility(Clone)",
            "Destroyer(Clone)",
            "Slowdown(Clone)"
        };

        protected GameObject ball;
        protected float speed;

        public BallsParent(GameObject ball, float speed)
        {
            SetFields(ball, speed);
        }

        public void SetFields(GameObject ball, float speed)
        {
            this.ball = ball;
            this.speed = speed;
        }

        #region Getters
        public GameObject GetBallObj() { return ball; }

        public float GetSpeed() { return speed; }
        #endregion

        public abstract void SpawnPreparation(out Vector3 spawnPos, out Quaternion spawnRot);

        public abstract Vector3 Move();

        public abstract Vector3 MoveSlow();

        public void UpgradeSpeed() { speed += 1; }

        #region Checkers
        public virtual bool IsRedBall() { return false; }

        public virtual bool IsGreenBall() { return false; }

        public virtual bool IsYellowBall() { return false; }

        public virtual bool IsBlueBall() { return false; }

        public virtual bool IsFallingBall() { return false; }

        public virtual bool CheckRedBallCollision(string otherBallName) { return false; }

        public virtual bool CheckGreenBallCollision(string otherBallName) { return false; }

        public virtual bool CheckYellowBallCollision(string otherBallName) { return false; }

        public virtual bool CheckBlueBallCollision(string otherBallName) { return false; }
        #endregion
    }
}
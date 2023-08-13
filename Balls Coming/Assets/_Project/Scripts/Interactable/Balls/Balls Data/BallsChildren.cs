using UnityEngine;

namespace BallsComing.Interactable.Balls.BallsData
{
    public class RedBall : BallsParent
    {
        private RedBall(GameObject redBall, float speed) : base(redBall, speed) { }

        private static RedBall instance;
        public static RedBall Instance(GameObject coin, float speed)
        {
            if (instance == null) instance = new(coin, speed);
            else instance.SetFields(coin, speed);

            return instance;
        }

        public static RedBall GetInstance() { return instance; }

        public override void SpawnPreparation(out Vector3 spawnPos, out Quaternion spawnRot)
        {
            float spawnPosX = Random.Range(-8.7f, 8.7f);
            float spawnPosY = 7f;
            spawnPos = new Vector3(spawnPosX, spawnPosY, 0);

            spawnRot = Quaternion.identity;
        }

        public override Vector3 Move() { return speed * Time.deltaTime * Vector3.down; }

        public override Vector3 MoveSlow() { return (speed - 1f) * Time.deltaTime * Vector3.down; }

        public override bool IsRedBall() { return true; }

        public override bool IsFallingBall() { return true; }

        public override bool CheckRedBallCollision(string otherBallName) { return otherBallCollisionSet.Contains(otherBallName); }
    }

    public class GreenBall : BallsParent
    {
        private GreenBall(GameObject greenBall, float speed) : base(greenBall, speed) { }

        private static GreenBall instance;
        public static GreenBall Instance(GameObject coin, float speed)
        {
            if (instance == null) instance = new(coin, speed);
            else instance.SetFields(coin, speed);

            return instance;
        }

        public static GreenBall GetInstance() { return instance; }

        public override void SpawnPreparation(out Vector3 spawnPos, out Quaternion spawnRot)
        {
            float spawnPosX = Random.Range(-8.7f, 8.7f);
            float spawnPosY = 7f;
            spawnPos = new Vector3(spawnPosX, spawnPosY, 0);

            spawnRot = Quaternion.identity;
        }

        public override Vector3 Move() { return speed * Time.deltaTime * Vector3.down; }

        public override Vector3 MoveSlow() { return (speed - 1f) * Time.deltaTime * Vector3.down; }

        public override bool IsGreenBall() { return true; }

        public override bool IsFallingBall() { return true; }

        public override bool CheckGreenBallCollision(string otherBallName) { return otherBallCollisionSet.Contains(otherBallName); }
    }

    public class YellowBall : BallsParent
    {
        private YellowBall(GameObject yellowBall, float speed) : base(yellowBall, speed) { }

        private static YellowBall instance;
        public static YellowBall Instance(GameObject coin, float speed)
        {
            if (instance == null) instance = new(coin, speed);
            else instance.SetFields(coin, speed);

            return instance;
        }

        public static YellowBall GetInstance() { return instance; }

        public override void SpawnPreparation(out Vector3 spawnPos, out Quaternion spawnRot)
        {
            float spawnPosX = Random.Range(-8.7f, 8.7f);
            float spawnPosY = 7f;
            spawnPos = new Vector3(spawnPosX, spawnPosY, 0);

            spawnRot = Quaternion.identity;
        }

        public override Vector3 Move() { return speed * Time.deltaTime * Vector3.down; }

        public override Vector3 MoveSlow() { return (speed - 1f) * Time.deltaTime * Vector3.down; }

        public override bool IsYellowBall() { return true; }

        public override bool IsFallingBall() { return true; }

        public override bool CheckYellowBallCollision(string otherBallName) { return otherBallCollisionSet.Contains(otherBallName); }
    }

    public class BlueBall : BallsParent
    {
        private BlueBall(GameObject redBall, float speed) : base(redBall, speed) { }

        private static BlueBall instance;
        public static BlueBall Instance(GameObject coin, float speed)
        {
            if (instance == null) instance = new(coin, speed);
            else instance.SetFields(coin, speed);

            return instance;
        }

        public static BlueBall GetInstance() { return instance; }

        public override void SpawnPreparation(out Vector3 spawnPos, out Quaternion spawnRot)
        {
            float spawnPosX = 12f;
            float spawnPosY = -3.8f;
            spawnPos = new(spawnPosX, spawnPosY, 0);

            spawnRot = Quaternion.identity;
        }

        public override Vector3 Move() { return speed * Time.deltaTime * Vector3.left; }

        public override Vector3 MoveSlow() { return (speed - 1f) * Time.deltaTime * Vector3.left; }

        public override bool IsBlueBall() { return true; }

        public override bool CheckBlueBallCollision(string otherBallName) { return otherBallCollisionSet.Contains(otherBallName); }
    }
}
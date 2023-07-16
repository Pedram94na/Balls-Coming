using UnityEngine;

using BallsComing.Interactable.Balls.BallsData;

namespace BallsComing.Balls
{
	public class BallSpawner : MonoBehaviour
	{
        private BallsParent[] ballsArr;
        private int ballsArrLength;

        BallsParent newBall;
        int ballsArrIndex;

        private void Awake()
        {
            SetBallsArr();
        }

        private void SetBallsArr()
        {
            ballsArrLength = transform.childCount;
            ballsArr = new BallsParent[ballsArrLength];

            for (int i = 0; i < ballsArrLength; i++)
            {
                GameObject ballObj = gameObject.transform.GetChild(i).gameObject;

                ballsArr[i] = CreatingBalls(ballObj);
            }
        }

        private BallsParent CreatingBalls(GameObject ballObj)
        {
            string name = ballObj.name;

            return name switch
            {
                "Red Ball" => RedBall.Instance(ballObj, 10),

                "Green Ball" => GreenBall.Instance(ballObj, 5),

                "Yellow Ball" => YellowBall.Instance(ballObj, 3),

                "Blue Ball" => BlueBall.Instance(ballObj, 3),

                _ => null,
            };
        }

        private void Start()
        {
            InvokeRepeating(nameof(SpawnBalls), 5f, 1f);
        }

        private void SpawnBalls()
        {
            ballsArrIndex = Random.Range(0, ballsArrLength);
            newBall = ballsArr[ballsArrIndex];

            if (newBall != null)
            {
                newBall.SpawnPreparation(out Vector3 spawnPos, out Quaternion spawnRot);
                
                Instantiate(newBall.GetBallObj(), spawnPos, spawnRot);
            }
        }
    }
}
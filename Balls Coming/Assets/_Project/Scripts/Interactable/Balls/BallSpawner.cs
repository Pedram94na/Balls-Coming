using UnityEngine;

using BallsComing.Interactable.Balls.BallsData;
using BallsComing.Core;

namespace BallsComing.Balls
{
	public class BallSpawner : MonoBehaviour
	{
        private BallsParent[] ballsArr;
        private int ballsArrLength;

        private Transform spawnsTr;

        private void Awake()
        {
            SetBallsArr();

            spawnsTr = GameObject.Find("Spawns").transform;
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
            int ballsArrIndex = Random.Range(0, ballsArrLength);
            BallsParent newBall = ballsArr[ballsArrIndex];

            if (GetGameStats() == 0 && newBall != null)
            {
                newBall.SpawnPreparation(out Vector3 spawnPos, out Quaternion spawnRot);

                GameObject newBallObj = Instantiate(newBall.GetBallObj(), spawnPos, spawnRot);
                newBallObj.transform.parent = spawnsTr;
            }
        }

        private int GetGameStats() { return (int)GameManager.gameStats; }
    }
}
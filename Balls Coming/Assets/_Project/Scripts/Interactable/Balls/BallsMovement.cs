using UnityEngine;

using BallsComing.Interactable.Balls.BallsData;
using BallsComing.Core;

namespace BallsComing.Balls
{
    public class BallsMovement : MonoBehaviour
    {
        private bool ExcludingOriginals => OriginalBallsCheck();
        private bool OriginalBallsCheck()
        {
            try
            {
                return gameObject != originalBallsArr[0] && gameObject != originalBallsArr[1] && gameObject != originalBallsArr[2] && gameObject != originalBallsArr[3];
            }
            catch
            {
                return true;
            }
        }

        private BallsParent ball;

        private static GameObject[] originalBallsArr;

        private void Awake()
        {
            SetOriginalBallsArray();
        }

        private static void SetOriginalBallsArray()
        {
            Transform originalBallsTr = GameObject.Find("Balls Original").transform;

            int originalBallsArrLength = originalBallsTr.childCount;
            originalBallsArr = new GameObject[originalBallsArrLength];

            for (int i = 0; i < originalBallsArrLength; i++)
                originalBallsArr[i] = originalBallsTr.GetChild(i).gameObject;
        }

        private void Start()
        {
            if (ExcludingOriginals) GetBallInstance();
        }

        private void GetBallInstance()
        {
            ball = name.Split(" ")[0] switch
            {
                "Red" => RedBall.GetInstance(),

                "Green" => GreenBall.GetInstance(),

                "Yellow" => YellowBall.GetInstance(),

                "Blue" => BlueBall.GetInstance(),

                _ => null,
            };
        }

        private void Update()
        {
            if (ExcludingOriginals && GetGameStats() == 0) MoveBalls();
        }

        private void MoveBalls()
        {
            if (GetPlayerPowerupsStats() == 3) transform.Translate(ball.MoveSlow());

            else transform.Translate(ball.Move());
        }

        #region Getters
        private int GetPlayerPowerupsStats() { return (int)GameManager.playerPowerUpsStats; }

        private int GetGameStats() { return (int)GameManager.gameState; }
        #endregion
    }
}